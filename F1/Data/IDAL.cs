using F1.Migrations;

namespace F1.Data 
{
    public interface IDAL
    {
        public List<Questions> GetAllQuestions();

        public List<String?>? GetResponsesFromQuestionId(int questionId);

        public Games? GetGameByDate(DateTime date);

        public Games? GetGameById(int id);

        public Games SaveGame(Games game);
    }
}