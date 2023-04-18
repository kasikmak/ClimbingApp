using ClimbingApp.Data;
using ClimbingApp.Entity;
using ClimbingApp.Repositories;

var climberRepository = new SqlRepository<Climber>(new ClimbingAppDbContext());

AddClimber(climberRepository);
AddRouteSetter(climberRepository);
WriteAllToConsole(climberRepository);

static void AddClimber(IRepository<Climber> climberRepository)
{
    climberRepository.Add(new Climber { FirstName = "Adam", LastName = "Ondra" });
    climberRepository.Add(new Climber { FirstName = "Chris", LastName = "Sharma" });
    climberRepository.Add(new Climber { FirstName = "Janja", LastName = "Garnbret" });
    climberRepository.Save();
}

static void AddRouteSetter(IWriteRepository<RouteSetter> routeSetterRepository)
{
    routeSetterRepository.Add(new RouteSetter { FirstName = "Alex", LastName = "Megos" });
    routeSetterRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach(var item in items)
    {
        Console.WriteLine(item);
    }
}
