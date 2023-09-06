using ClimbingApp.DataAccess.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClimbingApp.DataAccess.Data;

public class ClimbingAppDbContext : DbContext
{

    public ClimbingAppDbContext(DbContextOptions<ClimbingAppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Climber> Climbers { get; set; }

    public DbSet<Route> Routes { get; set; }

}
