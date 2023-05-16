
using ClimbingApp.Data;
using ClimbingApp.Entity;
using ClimbingApp.Repositories;
using ClimbingApp.Repositories.Extensions;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

Console.WriteLine("Welcome to application for climbers to log their climbs.");
Console.WriteLine("--------------------------------------------------------");

bool ExitApp = false;
//var climberRepository = new SqlRepository<Climber>(new ClimbingAppDbContext());
//var routeRepository = new SqlRepository<Route>(new ClimbingAppDbContext());
var climberRepository = new FileRepository<Climber>();
var routeRepository = new FileRepository<Route>();

climberRepository.ReadRepository();
routeRepository.ReadRepository();
climberRepository.ItemAdded += ClimberAdded;
climberRepository.ItemRemoved += ClimberRemoved;
routeRepository.ItemAdded += RouteAdded;
routeRepository.ItemRemoved += RouteRemoved;

while (!ExitApp)
{
    Console.WriteLine("You have following options:");
    Console.WriteLine("1 - Display all data");
    Console.WriteLine("2 - Enter new data");
    Console.WriteLine("3 - Find data by Id");
    Console.WriteLine("4 - Remove some data");
    Console.WriteLine("X - Close the app and save changes");
    var userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            var userChoiceWhatToShow = GetInfoFromUser("Choose C to view all climbers\nChoose R to view all routes").ToUpper();
            if(userChoiceWhatToShow == "C")
            {
                WriteAllToConsole(climberRepository);
                break;
            }
            if(userChoiceWhatToShow == "R")
            {
                WriteAllToConsole(routeRepository);
                break;
            }
            break;
        case "2":
            var userChoiceWhatToEnter = GetInfoFromUser("Choose C to enter new climber\nChoose R to enter new route").ToUpper();
            if (userChoiceWhatToEnter == "C")
            {
                AddClimber(climberRepository);
                break;
            }
            if(userChoiceWhatToEnter == "R")
            {
                AddRoute(routeRepository);
                break;
            }
            break;
        case "3":
            var userChoiceToFind = GetInfoFromUser("C - Find climber by id\nR - Find route by id\nQ - go back to the menu.").ToUpper();
            if (userChoiceToFind == "C")
            {
                FindDataById(climberRepository);
                break;
            }
            if (userChoiceToFind == "R")
            {
                FindDataById(routeRepository);
                break;
            }
            break;
        case "4":
            var userChoiceWhatToRemove = GetInfoFromUser("Choose C to remove the climber\n Choose R to remove the route").ToUpper();
            if (userChoiceWhatToRemove == "C")
            {
                RemoveData(climberRepository);
                break;
            }
            if (userChoiceWhatToRemove == "R")
            {
                RemoveData(routeRepository);
                break;
            }
            break;
        case "x" or "X":
            ExitApp = CloseAppAndSave(climberRepository,routeRepository);
            break;
        default: Console.WriteLine("You have to type 1,2,3 or X");
            continue;
    }
}


static void ClimberAdded(object? sender, Climber e)
{
    AddInfoInFile(e, "Climber added");
    Console.WriteLine($"Added climber {e.FirstName} {e.LastName} from {sender?.GetType().Name}");

}

static void RouteAdded(object? sender, Route e)
{
    AddInfoInFile(e, "Route added");
    Console.WriteLine($"Added route {e.Name} {e.Grade} from {sender?.GetType().Name}");
}

static void ClimberRemoved(object? sender, Climber climber)
{
    Console.WriteLine($"Removed climber {climber.FirstName} {climber.LastName} from {sender?.GetType().Name}");
}

static void RouteRemoved(object? sender, Route route)
{
    Console.WriteLine($"Removed route {route.Name} {route.Grade} from {sender?.GetType().Name}");
}

static void AddInfoInFile<T>(T e, string info) where T : class, IEntity, new()
{
    using (var writer = File.AppendText(IRepository<T>.auditFileName))
    {
        writer.WriteLine($"[{DateTime.UtcNow}]\t{info} :\n[{e}]");
    }
}

void AddClimber(IRepository<Climber> climberRepository)
{
    string firstName = GetInfoFromUser("Enter climber's first name").ToUpper();
    string lastName = GetInfoFromUser("Enter climber's last name").ToUpper();
    if(! string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
    {
        var newClimber = new Climber { FirstName = firstName, LastName = lastName  };
        climberRepository.Add(newClimber);
    }   
}

void AddRoute(IRepository<Route> routeRepository)
{
    string name = GetInfoFromUser("Enter route's name").ToUpper();
    string grade = GetInfoFromUser("Enter route's grade").ToUpper();
    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(grade))
    {
        while (true)
        {
            var userChoiceRouteType = GetInfoFromUser("Is it a sport route or a boulder.\nChoose S for sport and B for boulder").ToUpper();
            if(userChoiceRouteType == "S")
            {
                var newSportRoute = new SportRoute { Name = name, Grade = grade };
                routeRepository.Add(newSportRoute);
                break;
            }
            if (userChoiceRouteType == "B")
            {
                var newBoulder = new Boulder { Name = name, Grade = grade };
                routeRepository.Add(newBoulder);
                break;
            }
            else
            {
                Console.WriteLine("Please write S or B");
            }
            break;
        }
    }
}

static T? FindDataById<T>(IRepository<T> repository) where T : class, IEntity, new()
{
    while (true)
    {
        Console.WriteLine($"Enter the ID of the {typeof(T).Name} you want to find.");
        var userChoiceId = Console.ReadLine();
        int userChoiceIdValue;
        var choiceIsParsed = int.TryParse(userChoiceId, out userChoiceIdValue);
        if (!choiceIsParsed)
        {
            Console.WriteLine("You need to enter whole number for ID");
        }
        else
        {
            var data = repository.GetById(userChoiceIdValue);
            if (data != null)
            {
                Console.WriteLine($"{data.ToString()}");
            }
            return data;
        }
    }
}
void RemoveData<T>(IRepository<T> repository)
    where T : class, IEntity, new()
{
    var dataFound = FindDataById(repository);
    if (dataFound != null)
    {
        while (true)
        {
            var userChoiceIfRemove = GetInfoFromUser($"Do you really want to remove {typeof(T).Name}? Write Y for YES\t\tPress N for NO.").ToUpper();
            if (userChoiceIfRemove == "Y")
            {
                repository.Remove(dataFound);
                break;
            }
            else if (userChoiceIfRemove == "N")
            {
                break;
            }
            else 
            {
                Console.WriteLine("");
            }
        }
    }
}


/*static void AddRouteSetter(IWriteRepository<RouteSetter> routeSetterRepository)
{
    routeSetterRepository.Add(new RouteSetter { FirstName = "Alex", LastName = "Megos" });
    routeSetterRepository.Save();
}*/

static void WriteAllToConsole<T>(IReadRepository<T> repository)
    where T : class, IEntity, new()
{
    var items = repository.GetAll();
    if (items.ToList().Count == 0)
    {
        Console.WriteLine("No data found");
    }
    foreach(var item in items)
    {
        Console.WriteLine(item);
    }   
}

bool CloseAppAndSave(FileRepository<Climber> climberRepository, FileRepository<Route> routeRepository)
{
    while (true)
    {
        var userChoise = GetInfoFromUser("Do you want to save changes?\nY for YES\nN for No").ToUpper();
        if (userChoise == "Y")
        {
            climberRepository.Save();
            routeRepository.Save();
            Console.WriteLine("Changes saved");
            return true;
        }
        else if (userChoise == "N")
        {
            return true;
        }
        else
        {
            Console.WriteLine("You have to choose YES or NO");
        }
    }
}

string GetInfoFromUser(string info)
{
    Console.WriteLine(info);
    string userInfo = Console.ReadLine();
    return userInfo;
}