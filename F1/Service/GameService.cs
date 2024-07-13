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

        private List<Questions> GetRandomQuestions(List<Questions> allQuestions)
        {
            List<Questions> result = new List<Questions>();
            Random rnd = new Random();
            
            for(int i = 0; i < Constants.Constants.GRID_SIZE; i++) 
            {
                int index  = rnd.Next(0, allQuestions.Count);

                Questions selected = allQuestions[index];
                result.Add(selected);

                allQuestions = allQuestions.Where(question => question.Group != selected.Group).ToList();
            }

            return result;
        }

        private List<List<String?>?> GetResponsesFromQuestions(List<Questions> questions)
        {
            List<List<String?>?> responsesForQuestions = new List<List<String?>?>();

            foreach(var question in questions)
            {
                List<String?>? answers = _dal.GetResponsesFromQuestionId(question.Id);
                responsesForQuestions.Add(answers);
            }

            return responsesForQuestions;
        }

        private GameDto? GameFromQuestionsIfValid(List<Questions> selectedQuestions)
        {
            List<List<String?>?> responsesForQuestions = GetResponsesFromQuestions(selectedQuestions);

            for(int i = 0; i < 3; i++)
            {
                List<String?>? lineResponses = responsesForQuestions[i];
                for(int j = 3; j < 6; j++)
                {
                    List<String?>? columnResponses = responsesForQuestions[j];
                }
            }

            return new GameDto();
        }

        private GameDto? GenerateNewGame(String dateStr)
        {
            GameDto? newGame = null;
            bool invalidGame = true;

            List<Questions> allQuestions = _dal.GetAllQuestions();
            List<Questions> selectedQuestions;

            while(invalidGame)
            {
                selectedQuestions = GetRandomQuestions(allQuestions);

                newGame = GameFromQuestionsIfValid(selectedQuestions);

                if(newGame != null)
                {
                    invalidGame = false;
                }
            }

            return newGame;
        }

        private GameDto? GetGameIfExists(String dateStr)
        {
            var date = DateTime.Parse(dateStr);

            var game = _dal.GetGameByDate(date);

            if (game != null)
            {
                return GameToGameDto(game);
            }

            return GenerateNewGame(dateStr);
        }

        public Task<GameDto?> GetGameByDate(String dateStr)
        {
            GameDto? game = GetGameIfExists(dateStr);
            
            return Task.FromResult(game);
        }
    }
}