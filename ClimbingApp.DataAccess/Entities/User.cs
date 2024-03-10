using System.ComponentModel.DataAnnotations;

namespace ClimbingApp.DataAccess.Entities;

public class User : EntityBase
{
    [Required]
    [MaxLength(25)]
    public string UserName { get; set; }
    [Required]
    [MaxLength(25)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(25)]
    public string LastName { get; set; }  
    [MaxLength(25)]
    public string Nationality { get; set; }

    public enum Role
    {
        Admin = 0,
        Climber = 1,
        Equiper = 2,
        Guest = 3
    };

    public Role Permission { get; set; }
    [Required]
    [MinLength(8)]
    public string PasswordHash { get; set; }

    public List<Route> Routes { get; set; }

   // public override string ToString() => $"Id: {Id} Name: {FirstName} {LastName}";

}
