using ClimbingApp.Entity;
using ClimbingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.Services;

public class EventHandlerService : IEventHandlerService
{
    private readonly IRepository<Climber> _climberRepository;
    private readonly IRepository<Route> _routeRepository;

    public EventHandlerService(IRepository<Climber> climberRepository, IRepository<Route> routeRepository)
    {
        _climberRepository = climberRepository;
        _routeRepository = routeRepository;
    }

    public void SubscribeToEvents()
    {
        _routeRepository.ItemAdded += RouteRepositoryItemAdded;
        _routeRepository.ItemRemoved += RouteRepositoryItemRemoved;
        _climberRepository.ItemAdded += ClimberRepositoryItemAdded;
        _climberRepository.ItemRemoved += ClimberRepositoryItemRemoved;
        _routeRepository.HighRating += HighRatingRouteAdded;
    }

    private void ClimberRepositoryItemRemoved(object? sender, Climber e)
    {
        AddInfoInFile(e, "Climber removed");
        Console.WriteLine($"Removed climber {e.FirstName} {e.LastName} from {sender?.GetType().Name}");
    }

    private void ClimberRepositoryItemAdded(object? sender, Climber e)
    {
        AddInfoInFile(e, "Climber added");
        Console.WriteLine($"Added climber {e.FirstName} {e.LastName} from {sender?.GetType().Name}");
    }

    private void RouteRepositoryItemRemoved(object? sender, Route e)
    {
        AddInfoInFile(e, "Route removed");
        Console.WriteLine($"Removed route {e.Name} {e.Grade} from {sender?.GetType().Name}");
    }

    private void RouteRepositoryItemAdded(object? sender, Route e)
    {
        AddInfoInFile(e, "Route added");
        Console.WriteLine($"Added route {e.Name} {e.Grade} from {sender?.GetType().Name}");
    }


    private void AddInfoInFile<T>(T e, string info) where T : class, IEntity, new()
    {
        using (var writer = File.AppendText(IRepository<T>.auditFileName))
        {
            writer.WriteLine($"[{DateTime.UtcNow}]\t{info} :\n[{e}]");
        }
    }

    private void HighRatingRouteAdded(object? sender, Route route)
    {
        if (route.Rating == 5)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Rating 5 - highly recommended route!");
            Console.ResetColor();
        }

    }
}
