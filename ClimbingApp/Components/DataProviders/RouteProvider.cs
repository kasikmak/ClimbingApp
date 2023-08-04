using ClimbingApp.Data.Entity;
using ClimbingApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using ClimbingApp.Components.DataProviders.Extensions;

namespace ClimbingApp.Components.DataProviders;

public class RouteProvider : IRouteProvider
{
    private readonly IRepository<Route> _routeRepository;

    public RouteProvider(IRepository<Route> routeRepository)
    {
        _routeRepository = routeRepository;
    }



    public List<Route[]> ChunkRoutes(int size)
    {
        var routes = _routeRepository.GetAll();
        return routes.Chunk(size).ToList();
    }

    public List<Route> DistinctByGrade()
    {
        var routes = _routeRepository.GetAll();
        return routes
            .DistinctBy(x => x.Grade)
            .OrderBy(x => x.Grade)
            .ToList();
    }

    public Route FirstByGrade(string grade)
    {
        var routes = _routeRepository.GetAll();
        grade.ToUpper();
        return routes.First(x => x.Grade == grade);
    }

    public Route FirstOrDefaultByGradeOrDefault(string grade)
    {
        var routes = _routeRepository.GetAll();
        grade.ToUpper();
        return routes
            .FirstOrDefault(
             x => x.Grade == grade,
             new Route { Id = -1, Name = "Not found" });
    }

    public string GetMaximumGrade()
    {
        var routes = _routeRepository.GetAll();
        return routes.Select(x => x.Grade).Max();
    }

    public int GetMaximumRating()
    {
        var routes = _routeRepository.GetAll();
        return routes.Select(x => x.Rating).Max();
    }

    public List<Route> GetSpecificColumns()
    {
        var routes = _routeRepository.GetAll();
        var list = routes.Select(route => new Route
        {
            Id = route.Id,
            Name = route.Name,
            Rating = route.Rating,
            Grade = route.Grade,
        }).ToList();

        return list;
    }

    public List<string> GetUniqueGrade()
    {
        var routes = _routeRepository.GetAll();
        return routes.Select(x => x.Grade).Distinct().ToList();
    }

    public Route LastByGrade(string grade)
    {
        var routes = _routeRepository.GetAll();
        grade.ToUpper();
        return routes.Last(x => x.Grade == grade);
    }

    public Route LastOrDefaultByGradeOrDefault(string grade)
    {
        var routes = _routeRepository.GetAll();
        grade.ToUpper();
        return routes
            .LastOrDefault(
            x => x.Grade == grade,
            new Route { Id = -1, Name = "Not Found" });
    }

    public Route LastOrDefaultByRating(int rating)
    {
        var routes = _routeRepository.GetAll();
        var route = routes.LastOrDefault(x => x.Rating == rating);
        if (route is null)
        {
            Console.WriteLine($"There is no route with rating {rating}");
        }
        return route!;
    }

    public List<Route> OrderByGradeAndName()
    {
        var routes = _routeRepository.GetAll();
        return routes
            .OrderBy(x => x.GradeAsFloat)
            .ThenBy(x => x.Name)
            .ToList();
    }

    public List<Route> OrderByGradeAndNameDescending()
    {
        var routes = _routeRepository.GetAll();
        return routes
            .OrderByDescending(x => x.GradeAsFloat)
            .ThenByDescending(x => x.Name)
            .ToList();
    }

    public List<Route> OrderByLength()
    {
        var routes = _routeRepository.GetAll();
        return routes.OrderBy(x => x.Length).ToList();
    }

    public List<Route> OrderByLengthDescending()
    {
        var routes = _routeRepository.GetAll();
        return routes.OrderByDescending(x => x.Length).ToList();
    }

    public List<Route> OrderByName()
    {
        var routes = _routeRepository.GetAll();
        return routes.OrderBy(x => x.Name).ToList();
    }

    public List<Route> OrderByNameDescending()
    {
        var routes = _routeRepository.GetAll();
        return routes.OrderByDescending(x => x.Name).ToList();
    }

    public List<Route> OrderByRating()
    {
        var routes = _routeRepository.GetAll();
        return routes.OrderBy(x => x.Rating).ToList();
    }

    public List<Route> RoutesLongerThan(int length)
    {
        var routes = _routeRepository.GetAll();
        return routes.Where(x => x.Length > length).ToList();
    }

    public Route SingleOrDefaultById(int id)
    {
        var routes = _routeRepository.GetAll();
        var route = routes.SingleOrDefault(x => x.Id == id);
        if (route is null)
        {
            Console.WriteLine($"There is no route with id {id}");
        }
        return route!;
    }

    public List<Route> SkipRouteWhileLenghtLowerThan(int length)
    {
        var routes = _routeRepository.GetAll();
        return routes.SkipWhile(x => x.Length < length).ToList();
    }

    public List<Route> SkipRouteWhileRatingLowerThan(int rating)
    {
        var routes = _routeRepository.GetAll();
        return routes.SkipWhile(x => x.Rating < rating).ToList();
    }

    public List<Route> TakeRoute(int howMany)
    {
        var routes = _routeRepository.GetAll();
        return routes.Take(howMany).ToList();
    }

    public List<Route> TakeRoute(Range range)
    {
        var routes = _routeRepository.GetAll();
        return routes.Take(range).ToList();
    }

    public List<Route> TakeRouteWhileGradeLowerThan(string grade)
    {
        var routes = _routeRepository.GetAll();
        var gradeAsFloat = grade.ConvertGrades();
        return routes
          .OrderBy(x => x.GradeAsFloat)
          .TakeWhile(x => x.GradeAsFloat < gradeAsFloat)
          .ToList();
    }

    public List<Route> TakeRouteWhileRatingHigherThan(int rating)
    {
        var routes = _routeRepository.GetAll();
        return routes.Where(x => x.Rating > rating).ToList();
    }

    public List<Route> WhereGradeIs(string grade)
    {
        var routes = _routeRepository.GetAll();
        var gradeAsFloat = grade.ConvertGrades();
        return routes.Where(x => x.GradeAsFloat == gradeAsFloat).ToList();
    }

    public List<Route> WhereRatingIs(int rating)
    {
        var routes = _routeRepository.GetAll();
        return routes.Where(x => x.Rating == rating).ToList();
    }

    public List<Route> WhereStartsWith(string prefix)
    {
        var routes = _routeRepository.GetAll();
        return routes.Where(x => x.Name.StartsWith(prefix)).ToList();
    }

}
