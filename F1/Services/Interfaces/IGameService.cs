using F1.Data;
using F1.Data.DTO;

namespace F1.Services.Interfaces {
    public interface IGameService {
        public Task<GameDto?> GetGameByDate(String dateStr);

        public bool InvalidDate(String? date);

        public Task<GameDto?>? GetGameById(int id);
    }
}