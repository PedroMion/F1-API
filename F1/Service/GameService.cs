using F1.Data.DTO;
using F1.Services.Interfaces;
using F1.Data;

namespace F1.Services
{
    public class GameService() : IGameService 
    {
        private readonly IDAL _dal;

        public GameService(IDAL dal) : this()
        {
            _dal = dal;
        }

        private GameDto GameToGameDto(Games game)
        {
            return new GameDto();
        }

        private GameDto? GetGameIfExists(String dateStr)
        {
            var date = DateTime.Parse(dateStr);

            var game = _dal.GetGameByDate(date);

            if (game != null)
            {
                return GameToGameDto(game);
            }

            return null;
        }

        public Task<GameDto?> GetGameByDate(String dateStr)
        {
            GameDto? game = GetGameIfExists(dateStr);
            
            return Task.FromResult(game);
        }
    }
}