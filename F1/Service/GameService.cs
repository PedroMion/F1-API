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

        public Task<GameDto?> GetGameByDate()
        {
            List<Questions> questions = _dal.GetAllQuestions();

            GameDto? game = new GameDto();

            if(questions.Count > 0)
            {
                game.Question = questions.FirstOrDefault().Question;
            }
            
            return Task.FromResult(game);
        }
    }
}