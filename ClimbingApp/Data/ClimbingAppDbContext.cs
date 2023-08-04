using ClimbingApp.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClimbingApp.Data;

public class ClimbingAppDbContext : DbContext
{
    public DbSet<Climber> Climbers => Set<Climber>();

    public DbSet<Route> Routes => Set<Route>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("ClimbingAppStorage");
    }
}
