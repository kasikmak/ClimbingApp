using ClimbingApp.Entity;
using ClimbingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.DataProviders;

public class ClimberProvider : IClimberProvider
{
    private readonly IRepository<Climber> _climberRepository;

    public ClimberProvider(IRepository<Climber> climberRepository)
    {
        _climberRepository = climberRepository;
    }

    public Climber FirstByNationality(string nationality)
    {
        var climbers = _climberRepository.GetAll();
        return climbers.First(x=>x.Nationality == nationality);
    }

    public Climber FirstOrDefaultByNationalityOrDefault(string nationality)
    {
        var climbers = _climberRepository.GetAll();
        return climbers
            .FirstOrDefault(
            x => x.Nationality == nationality,
            new Climber { Id = -1, FirstName = "Not found" });
    }

    public List<string> GetUniqueNationality()
    {
        var climbers = _climberRepository.GetAll();
        return climbers.Select(x=>x.Nationality).Distinct().ToList();
    }

    public Climber LastByNationality(string nationality)
    {
        var climbers = _climberRepository.GetAll();
        return climbers.Last(x=>x.Nationality == nationality);
    }

    public Climber LastOrDefaultByNationalityOrDefault(string nationality)
    {
        var climbers = _climberRepository.GetAll();
        return climbers
            .LastOrDefault(x => x.Nationality == nationality,
            new Climber { Id = -1, FirstName = "Not found" });
    }

    public List<Climber> OrderByLastNameAndFirstName()
    {
        var climbers = _climberRepository.GetAll();
        return climbers
            .OrderBy(x=>x.LastName)
            .ThenBy(x => x.FirstName)
            .ToList();
    }

    public List<Climber> OrderByNationality()
    {
        var climbers = _climberRepository.GetAll();
        return climbers.OrderBy(x=>x.Nationality).ToList();
    }

    public Climber SingleOrDefaultById(int id)
    {
        var climbers = _climberRepository.GetAll();
        var climber = climbers.SingleOrDefault(x => x.Id == id);
        if (climber == null)
        {
            Console.WriteLine($"Climber with Id {id} not found");
        }
        return climber;
    }

    public List<Climber> SkipClimbers(int howMany)
    {
        var climbers = _climberRepository.GetAll();
        return climbers
            .OrderBy(x => x.LastName)
            .ThenBy(x=>x.FirstName)
            .Skip(howMany)
            .ToList();
    }


    public List<Climber> SkipClimbersWhileNameStartsWith(string prefix)
    {
        var climbers = _climberRepository.GetAll();
        return climbers
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .SkipWhile(x => x.LastName.StartsWith(prefix))
            .ToList();
    }

    public List<Climber> TakeClimbers(int howMany)
    {
        var climbers = _climberRepository.GetAll();
        return climbers
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .Take(howMany)
            .ToList();
    }

    public List<Climber> TakeClimbers(Range range)
    {
        var climbers = _climberRepository.GetAll();
        return climbers
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .Take(range)
            .ToList();
    }

    public List<Climber> TakeClimbersWhileNameStartsWith(string prefix)
    {
        var climbers = _climberRepository.GetAll();
        return climbers
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .TakeWhile(x => x.LastName.StartsWith(prefix))
            .ToList();
    }

    public List<Climber> WhereNationalityIs(string nationality)
    {
        var climbers = _climberRepository.GetAll();
        return climbers.Where(x => x.Nationality == nationality).ToList();
    }

    public List<Climber> WhereStartsWith(string prefix)
    {
        var climbers = _climberRepository.GetAll();
        return climbers.Where(x => x.LastName == prefix).ToList();
    }
}
