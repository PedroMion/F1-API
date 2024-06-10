public class Teams {
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Race_Starts { get; set; }

    public int Race_Wins { get; set; }

    public int Constructors_Championships { get; set; }

    public int Pilots_Championships { get; set; }

    public virtual ICollection<PilotsTeams>? Pilots { get; set; }

}