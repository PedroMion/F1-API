namespace F1.Data.DTO
{
    public class RaceDto
    {
        public List<int> FinalGrid { get; set; }
        public int PolePositionId { get; set;}
        public int FastestLapId { get; set; }
        public int CircuitId { get; set; }
        public DateTime RaceDate { get; set; }
    }
}