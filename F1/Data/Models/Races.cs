public class Races {
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public Circuits? Circuit { get; set; }

    public Seasons? Season { get; set; }

    public Pilots? Winner_Pilot { get; set; }
}