using System.Runtime.CompilerServices;
using F1.Data.DTO;
using Microsoft.EntityFrameworkCore;

namespace F1.Data
{
    public class DAL() : IDAL
    {
        private readonly F1Context _F1Context;

        public DAL(F1Context context) : this()
        {
            _F1Context = context;
        }

        public List<Questions> GetAllQuestions()
        {
            List<Questions> result = _F1Context.Questions.ToList();

            return result;
        }

        public List<String?>? GetResponsesFromQuestionId(int questionId)
        {
            var question = _F1Context.Questions.Find(questionId);

            if(question != null && question.Query != null)
            {
                var responses = _F1Context.Pilots.FromSql(FormattableStringFactory.Create(question.Query));

                return responses.Select(resp => resp.Name).ToList();
            }

            return null;
        }

        public Games? GetGameByDate(DateTime date)
        {
            List<Games> game = _F1Context.Games
                                            .Include(g => g.Question1)
                                            .Include(g => g.Question2)
                                            .Include(g => g.Question3)
                                            .Include(g => g.Question4)
                                            .Include(g => g.Question5)
                                            .Include(g => g.Question6)
                                            .Where(g => g.ReferenceDate == date)
                                            .ToList();

            if(game != null && game.Count == 1)
            {
                return game.FirstOrDefault();
            }

            return null;
        }

        public Games? GetGameById(int id)
        {
            Games? game = _F1Context.Games
                                        .Include(g => g.Question1)
                                        .Include(g => g.Question2)
                                        .Include(g => g.Question3)
                                        .Include(g => g.Question4)
                                        .Include(g => g.Question5)
                                        .Include(g => g.Question6)
                                        .FirstOrDefault(game => game.Id == id);

            return game;
        }

        public void SaveGame(Games game)
        {
            _F1Context.Games.Add(game);
            _F1Context.SaveChanges();
        }
    }
}