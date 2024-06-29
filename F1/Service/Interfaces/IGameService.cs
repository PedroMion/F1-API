using F1.Data.DTO;

namespace F1.Services.Interfaces {
    public interface IGameService {
        public Task<GameDto?> GetGameByDate(DateTime date);
    }
}