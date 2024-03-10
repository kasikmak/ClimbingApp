using System.ComponentModel.DataAnnotations;

namespace ClimbingApp.DataAccess.Entities;

public abstract class EntityBase
{
    [Key]
    public int Id { get; set; }
}
