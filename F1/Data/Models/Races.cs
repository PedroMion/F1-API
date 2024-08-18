public class Races {
    public Races() {}
    
    public Races(DateTime date, Circuits? circuit, Seasons? season, Pilots? winner_pilot)
    {
        Date = date;
        Circuit = circuit;
        Season = season;
        Winner_Pilot = winner_pilot;
    }
    
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public Circuits? Circuit { get; set; }

    public Seasons? Season { get; set; }

    public Pilots? Winner_Pilot { get; set; }
}