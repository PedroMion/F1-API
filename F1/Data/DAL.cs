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
    }
}