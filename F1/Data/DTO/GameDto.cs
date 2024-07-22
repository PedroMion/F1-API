namespace F1.Data.DTO;

public class GameDto {
    public int Id { get; set;}

    public String? Question1 { get; set; }

    public String? Question2 { get; set; }

    public String? Question3 { get; set; }

    public String? QuestionA { get; set; }

    public String? QuestionB { get; set; }

    public String? QuestionC { get; set; }

    public List<String?>? Square1A { get; set; }

    public List<String?>? Square1B { get; set; }

    public List<String?>? Square1C { get; set; }

    public List<String?>? Square2A { get; set; }

    public List<String?>? Square2B { get; set; }

    public List<String?>? Square2C { get; set; }

    public List<String?>? Square3A { get; set; }

    public List<String?>? Square3B { get; set; }

    public List<String?>? Square3C { get; set; }
}