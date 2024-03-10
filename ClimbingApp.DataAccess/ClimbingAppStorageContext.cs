using ClimbingApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.DataAccess;

public class ClimbingAppStorageContext : DbContext
{
    public ClimbingAppStorageContext(DbContextOptions<ClimbingAppStorageContext> options) : base(options)
    {
            
    }

    public DbSet<User> Users { get; set;}

    public DbSet<Route> Routes { get; set;}

    public DbSet<Ascent> Ascents { get; set;}
}
