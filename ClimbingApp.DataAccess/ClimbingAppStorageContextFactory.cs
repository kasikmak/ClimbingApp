using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.DataAccess;

public class ClimbingAppStorageContextFactory : IDesignTimeDbContextFactory<ClimbingAppStorageContext>
{
    public ClimbingAppStorageContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ClimbingAppStorageContext>();
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-KSU5O1R\\SQLEXPRESS;Initial Catalog=ClimbingAppStorage;Integrated Security=True;Trust Server Certificate=True");
        return new ClimbingAppStorageContext(optionsBuilder.Options);
    }   
}
