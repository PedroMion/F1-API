using F1.Data.DTO;

namespace F1.Services.Interfaces {
    public interface IDataService {
        public Task UpdateDataByRaceInfoTreatInputAsync(RaceDto raceInfo);

        public Pilots? GetPilotById(int id);

        public Pilots? GetPilotByName(string name);

        public Task<Pilots> CreateNewPilot(NewPilotDto pilotInformation);
    }
}