public class Seasons {
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string? Decade { get; set; }

    public Pilots? Season_Champion { get; set; }

    public virtual ICollection<PilotsSeasons>? Pilots { get; set; }
}