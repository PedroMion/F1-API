using F1.Migrations;

namespace F1.Data 
{
    public interface IDAL
    {
        public List<Questions> GetAllQuestions();

        public List<String?>? GetResponsesFromQuestionId(int questionId);

        public Games? GetGameByDate(DateTime date);

        public Games? GetGameById(int id);

        public Games? GetMostRecentGame();

        public Games SaveGame(Games game);

        public Pilots? GetPilotById(int id);

        public Pilots? GetPilotByName(string name);

        public Task<Pilots> SaveNewPilotAsync(Pilots pilot);

        public void UpdatePilot(Pilots pilot);

        public Task<Seasons?> GetSeasonByDateAsync(DateTime date);

        public Task<Races> SaveNewRaceAsync(Races race);

        public Circuits? GetCircuitById(int id);
    }
}