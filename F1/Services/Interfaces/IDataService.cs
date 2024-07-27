using F1.Data.DTO;

namespace F1.Services.Interfaces {
    public interface IDataService {
        public bool UpdateDriversByRaceInfoAsync(RaceDto raceInfo);
    }
}