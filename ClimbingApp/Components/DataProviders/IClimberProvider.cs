using ClimbingApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.Components.DataProviders;

public interface IClimberProvider
{
    List<string> GetUniqueNationality();

    List<Climber> OrderByLastNameAndFirstName();
    List<Climber> OrderByNationality();

    List<Climber> WhereNationalityIs(string nationality);
    List<Climber> WhereStartsWith(string prefix);

    Climber FirstByNationality(string nationality);
    Climber FirstOrDefaultByNationalityOrDefault(string nationality);
    Climber LastByNationality(string nationality);
    Climber LastOrDefaultByNationalityOrDefault(string nationality);
    Climber SingleOrDefaultById(int id);

    List<Climber> TakeClimbers(int howMany);
    List<Climber> TakeClimbers(Range range);
    List<Climber> TakeClimbersWhileNameStartsWith(string prefix);
    List<Climber> SkipClimbers(int howMany);
    List<Climber> SkipClimbersWhileNameStartsWith(string prefix);








}
