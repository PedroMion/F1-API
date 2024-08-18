using F1.Data;
using F1.Data.DTO;
using F1.Services.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;


namespace F1.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task SaveGameInCacheAsync(GameDto game, int id, CancellationToken token = default)
        {
            string key = $"game-{id}";
            
            await _distributedCache.SetStringAsync(
                key,
                JsonConvert.SerializeObject(game),
                token
            );
        }

        public async Task<GameDto?> GetGameFromCacheByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            string key = $"game-{id}";

            string? gameJson = await _distributedCache.GetStringAsync(key, cancellationToken);

            if (string.IsNullOrEmpty(gameJson))
            {
                return null;
            }

            var game = JsonConvert.DeserializeObject<GameDto>(gameJson);
            return game;
        }
    }
}