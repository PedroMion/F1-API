using F1.Constants;
using F1.Data;
using F1.Data.DTO;
using F1.Mappers;
using F1.Services.Interfaces;
using F1.Utils;

namespace F1.Services
{
    public class DataService : IDataService
    {
        private readonly IDAL _dal;

        public DataService(IDAL dal)
        {
            _dal = dal;
        }

        private async Task<Seasons> RetrieveSeasonByRaceInfo(RaceDto raceInfo)
        {
            DateTime raceDate = raceInfo.RaceDate;
            var year = raceDate.Year;

            var seasonDate = new DateTime(year, 1, 1);

            return await _dal.GetSeasonByDateAsync(seasonDate);
        }

        private async Task CreateNewRaceByRaceInfo(RaceDto raceInfo)
        {
            Seasons raceSeason = await RetrieveSeasonByRaceInfo(raceInfo);
            Pilots? winnerPilot = _dal.GetPilotById(raceInfo.FinalGrid[0]);
            Circuits? circuit = _dal.GetCircuitById(raceInfo.CircuitId);

            Races newRace = new Races(raceInfo.RaceDate, circuit, raceSeason, winnerPilot);

            await _dal.SaveNewRaceAsync(newRace);
        }

        private void UpdatePolePositionAndFastestLap(int polePositionId, int fastestLapId)
        {
            var polePositionPilot = _dal.GetPilotById(polePositionId);
            var fastestLapPilot = _dal.GetPilotById(fastestLapId);

            polePositionPilot.Pole_Positions += 1;
            fastestLapPilot.Fastest_Laps += 1;

            _dal.UpdatePilot(polePositionPilot);
            _dal.UpdatePilot(fastestLapPilot);
        }

        private void UpdatePilotsInformationByGrid(List<int> gridOrder)
        {
            int position = 0;
            
            foreach (int pilotId in gridOrder)
            {
                var pilot = _dal.GetPilotById(pilotId);
                
                pilot = RaceUtils.UpdatePilotByPositionInGrid(pilot, position);
                _dal.UpdatePilot(pilot);

                position++;
            }
        }

        private async Task UpdateDataByRaceInfoAsync(RaceDto raceInfo)
        {
            var gridOrder = raceInfo.FinalGrid;

            UpdatePilotsInformationByGrid(gridOrder);
            UpdatePolePositionAndFastestLap(raceInfo.PolePositionId, raceInfo.FastestLapId);
            await CreateNewRaceByRaceInfo(raceInfo);
        }

        public async Task UpdateDataByRaceInfoTreatInputAsync(RaceDto raceInfo)
        {
            try
            {
                await UpdateDataByRaceInfoAsync(raceInfo);
            }
            catch(Exception)
            {
                throw new Exception("Input data not in the right format");
            }
        }

        public Pilots? GetPilotById(int id)
        {
            return _dal.GetPilotById(id);
        }

        public Pilots? GetPilotByName(string name)
        {
            return _dal.GetPilotByName(name);
        }

        public async Task<Pilots> CreateNewPilot(NewPilotDto pilotInformation)
        {
            Pilots newPilot = PilotMapper.GetPilotInformationFromNewPilotDto(pilotInformation);

            newPilot = await _dal.SaveNewPilotAsync(newPilot);
            
            return newPilot;
        }
    }
}