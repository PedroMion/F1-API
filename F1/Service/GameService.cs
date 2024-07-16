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

        private GameDto? GameToGameDto(Games game)
        {
            List<Questions> questions =
            [
                game.Question1,
                game.Question2,
                game.Question3,
                game.Question4,
                game.Question5,
                game.Question6,
            ];

            List<List<String?>?> responses = GetResponsesFromQuestions(questions);

            return MapGameToGameDto(questions, responses);
        }

        private GameDto? MapGameToGameDto(List<Questions> selectedQuestions, List<List<String?>?> responsesForQuestions) {
            var gameDto = new GameDto();

            gameDto.Question1 = selectedQuestions[0].Question;
            gameDto.Question2 = selectedQuestions[1].Question;
            gameDto.Question3 = selectedQuestions[2].Question;
            gameDto.QuestionA = selectedQuestions[3].Question;
            gameDto.QuestionB = selectedQuestions[4].Question;
            gameDto.QuestionC = selectedQuestions[5].Question;

            gameDto.Square1A = responsesForQuestions[0].Intersect(responsesForQuestions[3]).ToList();
            gameDto.Square1B = responsesForQuestions[0].Intersect(responsesForQuestions[4]).ToList();
            gameDto.Square1C = responsesForQuestions[0].Intersect(responsesForQuestions[5]).ToList();
            gameDto.Square2A = responsesForQuestions[1].Intersect(responsesForQuestions[3]).ToList();
            gameDto.Square2B = responsesForQuestions[1].Intersect(responsesForQuestions[4]).ToList();
            gameDto.Square2C = responsesForQuestions[1].Intersect(responsesForQuestions[5]).ToList();
            gameDto.Square3A = responsesForQuestions[2].Intersect(responsesForQuestions[3]).ToList();
            gameDto.Square3B = responsesForQuestions[2].Intersect(responsesForQuestions[4]).ToList();
            gameDto.Square3C = responsesForQuestions[2].Intersect(responsesForQuestions[5]).ToList();

            return gameDto;
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

        private bool VerifyValidSquare(List<String?>? rowResponses, List<String?>? columnResponses)
        {
            List<String?>? result = rowResponses.Intersect(columnResponses).ToList();

            return result.Count >= 3 && result.Count <= 30;
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

                    if(!VerifyValidSquare(lineResponses, columnResponses))
                    {
                        return null;
                    }
                }
            }

            return MapGameToGameDto(selectedQuestions, responsesForQuestions);
        }

        private void SaveGame(List<Questions> selectedQuestions, DateTime date)
        {
            var game = new Games
            {
                Question1 = selectedQuestions[0],
                Question2 = selectedQuestions[1],
                Question3 = selectedQuestions[2],
                Question4 = selectedQuestions[3],
                Question5 = selectedQuestions[4],
                Question6 = selectedQuestions[5],
                ReferenceDate = date
            };

            _dal.SaveGame(game);
        }

        private GameDto? GenerateNewGame(DateTime date)
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

                    SaveGame(selectedQuestions, date);
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

            return GenerateNewGame(date);
        }

        public bool InvalidDate(String? date)
        {
            return date == null || DateTime.Parse(date).CompareTo(Constants.Constants.DATE_LIMIT) < 0;
        }

        public Task<GameDto?> GetGameByDate(String dateStr)
        {
            GameDto? game = GetGameIfExists(dateStr);
            
            return Task.FromResult(game);
        }

        public Task<GameDto?>? GetGameById(int id)
        {
            var game = _dal.GetGameById(id);

            if (game != null) {
                return Task.FromResult(GameToGameDto(game));
            }

            return null;
        }
    }
}