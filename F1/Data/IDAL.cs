namespace F1.Data 
{
    public interface IDAL
    {
        public List<Questions> GetAllQuestions();

        public List<String?>? GetResponsesFromQuestionId(int questionId);
    }
}