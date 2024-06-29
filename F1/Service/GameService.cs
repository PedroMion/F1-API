using F1.Data.DTO;
using F1.Services.Interfaces;
using F1.Data;
using F1.Migrations;

namespace F1.Services
{
    public class GameService() : IGameService 
    {
        private readonly DAL _dal;

        public GameService(DAL dal) : this()
        {
            _dal = dal;
        }

        public Task<GameDto?> GetGameByDate(DateTime date)
        {
            List<Questions> questions = _dal.GetAllQuestions();

            GameDto? game = new GameDto();

            game.Question = questions.FirstOrDefault().Question;
            
            return Task.FromResult(game);
        }
    }
}