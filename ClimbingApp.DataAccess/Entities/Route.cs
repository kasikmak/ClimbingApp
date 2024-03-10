using System.ComponentModel.DataAnnotations;

namespace ClimbingApp.DataAccess.Entities;

public class Route : EntityBase
{

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(5)]
    public string Grade { get; set; }

    public float GradeAsFloat { get; set; }

    public int? Length { get; set; }

    public enum RouteType
    {
        Sport = 0,
        Boulder = 1
    };

    public RouteType Type {  get; set; } 

    public List<User> Climbers { get; set; }

    public int EquiperId {  get; set; }

    public Ascent Ascent { get; set; }
   // public override string ToString() => $"Id: {Id} Name: {Name} Grade: {Grade} Length: {Length}m Rating: {Rating} Climbed: {IsClimbed}";

}
