public class Pilots {
    public int Id { get; set; }

    public string? Name { get; set; }

    public Countries? Nationality { get; set; }

    public virtual ICollection<PilotsSeasons>? Seasons { get; set; }

    public int Championships { get; set; }

    public int Race_Entries { get; set; }

    public int Race_Starts { get; set; }

    public int Pole_Positions { get; set; }

    public int Race_Wins { get; set; }

    public int Podiums { get; set; }

    public int Fastest_Laps { get; set; }

    public int Points  { get; set; }

    public bool Active { get; set; }

    public string? Decade { get; set; }

    public double Pole_Rate { get; set; }

    public double Start_Rate { get; set; }

    public double Win_Rate { get; set; }

    public double Podium_Rate { get; set; }

    public double FastLap_Rate { get; set; }

    public double Points_Per_Entry { get; set; }

    public string? Years_Active { get; set; }

    public bool Champion { get; set; }
}