using ClimbingApp.Data;
using ClimbingApp.Entity;
using ClimbingApp.Repositories;

//var climberRepository = new SqlRepository<Climber>(new ClimbingAppDbContext());
var routeRepository = new SqlRepository<Route>(new ClimbingAppDbContext());

//AddClimber(climberRepository);
AddRoute(routeRepository);
AddBoulder(routeRepository);
//AddRouteSetter(climberRepository);
WriteAllToConsole(routeRepository);

/*static void AddClimber(IRepository<Climber> climberRepository)
{
    climberRepository.Add(new Climber { FirstName = "Adam", LastName = "Ondra" });
    climberRepository.Add(new Climber { FirstName = "Chris", LastName = "Sharma" });
    climberRepository.Add(new Climber { FirstName = "Janja", LastName = "Garnbret" });
    climberRepository.Save();
}*/

static void AddRoute(IRepository<Route> routeRepository)
{
    routeRepository.Add(new Route { Name = "Silence", Grade = "9c" });
    routeRepository.Add(new Route { Name = "La Rambla", Grade = "9a+" });
    routeRepository.Save();
}

static void AddBoulder(IWriteRepository<Boulder> routeRepository)
{
    routeRepository.Add(new Boulder { Name = "Midnight Lightning", Grade = "7b+" });
    routeRepository.Save();
}

/*static void AddRouteSetter(IWriteRepository<RouteSetter> routeSetterRepository)
{
    routeSetterRepository.Add(new RouteSetter { FirstName = "Alex", LastName = "Megos" });
    routeSetterRepository.Save();

}*/

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach(var item in items)
    {
        Console.WriteLine(item);
    }
}
