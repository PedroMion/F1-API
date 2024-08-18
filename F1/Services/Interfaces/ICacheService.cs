using F1.Data;

namespace F1.Services.Interfaces
{
    public interface ICacheService
    {
        public Task<Games?> GetGameFromCacheByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}