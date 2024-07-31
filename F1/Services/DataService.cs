using F1.Data;
using F1.Data.DTO;
using F1.Services.Interfaces;

namespace F1.Services
{
    public class DataService : IDataService
    {
        private readonly IDAL _dal;

        public DataService(IDAL dal)
        {
            _dal = dal;
        }

        public bool UpdateDriversByRaceInfoAsync(RaceDto raceInfo)
        {
            return true;
        }

        public Pilots? GetPilotById(int id)
        {
            return _dal.GetPilotById(id);
        }

        public Pilots? GetPilotByName(string name)
        {
            return _dal.GetPilotByName(name);
        }

        public Pilots? CreateNewPilot(NewPilotDto pilotInformation)
        {
            return new Pilots();
        }
    }
}