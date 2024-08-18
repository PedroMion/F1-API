using F1.Data;
using F1.Data.DTO;

namespace F1.Services.Interfaces
{
    public interface ICacheService
    {
        public Task SaveGameInCacheAsync(GameDto game, int id, CancellationToken token = default);
        public Task<GameDto?> GetGameFromCacheByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}