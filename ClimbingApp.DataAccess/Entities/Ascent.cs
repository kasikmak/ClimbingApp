using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.DataAccess.Entities;

public class Ascent : EntityBase
{
    public int? Rating { get; set; }
    public bool IsClimbed { get; set; }
    [MaxLength(250)]
    public string? Notes { get; set; }

    public int RouteId { get; set; }

}
