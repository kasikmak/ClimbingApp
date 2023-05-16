namespace ClimbingApp.Entity;

public class Route : EntityBase
{
    public string Name { get; set; }

    public string Grade { get; set; }

    public override string ToString() => $"Id: {Id} Name: {Name} Grade: {Grade}";

}
