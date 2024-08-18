using F1.Data.DTO;
using F1.Services.Interfaces;
using F1.Data;

namespace F1.Services
{
    public class GameService() : IGameService 
    {
        private readonly IDAL _dal;
        private readonly ICacheService _cacheService;

        public GameService(IDAL dal, ICacheService cacheService) : this()
        {
            _dal = dal;
            _cacheService = cacheService;
        }

        private List<Questions> GetQuestionsFromGame(Games game)
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

            return questions;
        }

        private GameDto? GameToGameDto(Games game)
        {
            try
            {
                List<Questions> questions = GetQuestionsFromGame(game);
                List<List<String?>?> responses = GetResponsesFromQuestions(questions);

                GameDto? gameDto = MapQuestionsToGameDto(questions, responses);
                gameDto.Id = game.Id;

                return gameDto;
            } 
            catch(Exception)
            {
                return null;
            }
        }

        private GameDto? MapQuestionsToGameDto(List<Questions> selectedQuestions, List<List<String?>?> responsesForQuestions) {
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

            return MapQuestionsToGameDto(selectedQuestions, responsesForQuestions);
        }

        private Games SaveGame(List<Questions> selectedQuestions, DateTime date)
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

            return _dal.SaveGame(game);
        }

        private List<int> GetQuestionsIdsFromGame(Games? games) 
        {
            List<int> ids = new List<int>();
            
            if(games == null) {
                return ids;
            }

            ids.Add(games.Question1.Id);
            ids.Add(games.Question2.Id);
            ids.Add(games.Question3.Id);
            ids.Add(games.Question4.Id);
            ids.Add(games.Question5.Id);
            ids.Add(games.Question6.Id);

            return ids;
        }

        private List<Questions> GetAllQuestionsFiltered()
        {
            List<Questions> allQuestions = _dal.GetAllQuestions();
            
            Games? latestGame = _dal.GetMostRecentGame();

            if(latestGame != null) {
                List<int> questionsIds = GetQuestionsIdsFromGame(latestGame);

                allQuestions = allQuestions.Where(x => !questionsIds.Contains(x.Id)).ToList();
            }

            return allQuestions;        
        }

        private GameDto? GenerateNewGame(DateTime date)
        {
            GameDto? newGame = null;
            bool invalidGame = true;

            List<Questions> allQuestions = GetAllQuestionsFiltered();
            List<Questions> selectedQuestions;

            while(invalidGame)
            {
                selectedQuestions = GetRandomQuestions(allQuestions);

                newGame = GameFromQuestionsIfValid(selectedQuestions);

                if(newGame != null)
                {
                    invalidGame = false;

                    Games savedGame = SaveGame(selectedQuestions, date);
                    newGame.Id = savedGame.Id;
                }
            }

            _cacheService.SaveGameInCacheAsync(newGame, newGame.Id);

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

        private async Task<GameDto?> RetrieveGameFromDatabaseAndAddToCacheAsync(int id)
        {
            var game = _dal.GetGameById(id);

            if (game != null)
            {
                var mappedGame = await Task.FromResult(GameToGameDto(game));
                
                await _cacheService.SaveGameInCacheAsync(mappedGame, id);

                return mappedGame;
            }

            return null;
        }

        public bool InvalidDate(String? date)
        {
            if(date == null) {
                return false;
            }

            DateTime currentDate = DateTime.Now;
            DateTime nextDate = currentDate.AddDays(1);
            DateTime previousDate = currentDate.AddDays(-1);
            DateTime referenceDate = DateTime.Parse(date);

            return referenceDate.CompareTo(previousDate) < 0 || referenceDate.CompareTo(nextDate) > 0;
        }

        public Task<GameDto?> GetGameByDate(String dateStr)
        {
            GameDto? game = GetGameIfExists(dateStr);
            
            return Task.FromResult(game);
        }

        public async Task<GameDto?>? GetGameById(int id)
        {
            GameDto? gameDto = await _cacheService.GetGameFromCacheByIdAsync(id);

            if (gameDto != null)
            {
                return gameDto;
            }

            return await RetrieveGameFromDatabaseAndAddToCacheAsync(id);
        }
    }
}