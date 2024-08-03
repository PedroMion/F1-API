namespace F1.Data.DTO
{
    public class NewPilotDto
    {
        public required string Name { get; set; }

        public required Countries Nationality { get; set; }

        public bool F2_Champion { get; set; }
    }
}