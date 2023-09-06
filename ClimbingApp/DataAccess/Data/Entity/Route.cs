namespace ClimbingApp.DataAccess.Data.Entity;

public class Route : EntityBase
{
    public string Name { get; set; }

    public string Grade { get; set; }

    public float GradeAsFloat { get; set; }

    public int Length { get; set; }

    public int Rating { get; set; }

    public bool IsClimbed { get; set; }

    public override string ToString() => $"Id: {Id} Name: {Name} Grade: {Grade} Length: {Length}m Rating: {Rating} Climbed: {IsClimbed}";

}
