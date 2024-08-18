using F1.Data;
using F1.Services.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;


namespace F1.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDAL _dal;
        private readonly IDistributedCache _distributedCache;

        public CacheService(IDAL dal, IDistributedCache distributedCache)
        {
            _dal = dal;
            _distributedCache = distributedCache;
        }

        public async Task SaveGameInCacheAsync(Games game, string key, CancellationToken token = default)
        {
            await _distributedCache.SetStringAsync(
                key,
                JsonConvert.SerializeObject(game),
                token
            );
        }

        private async Task<Games?> GetFromSqlDatabaseAndStoresInCacheAsync(int id, string key, CancellationToken token)
        {
            Games? gameFromDatabase = _dal.GetGameById(id);

            if (gameFromDatabase == null)
            {
                return gameFromDatabase;
            }

            await SaveGameInCacheAsync(gameFromDatabase, key, token);

            return gameFromDatabase;
        }

        public async Task<Games?> GetGameFromCacheByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            string key = $"game-{id}";

            string? gameJson = await _distributedCache.GetStringAsync(key, cancellationToken);

            if (string.IsNullOrEmpty(gameJson))
            {
                return await GetFromSqlDatabaseAndStoresInCacheAsync(id, key, cancellationToken);
            }

            var game = JsonConvert.DeserializeObject<Games>(gameJson);
            return game;
        }
    }
}