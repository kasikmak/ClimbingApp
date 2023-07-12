using ClimbingApp.Entity;
using ClimbingApp.DataProviders.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.DataProviders;

public interface IRouteProvider
{

    List<string> GetUniqueGrade();
    List<Route> GetSpecificColumns();
    string GetMaximumGrade();
    int GetMaximumRating();

    List<Route> OrderByName();
    List<Route> OrderByNameDescending();
    List<Route> OrderByGradeAndName();
    List<Route> OrderByGradeAndNameDescending();
    List<Route> OrderByLength();
    List<Route> OrderByLengthDescending();
    List<Route> OrderByRating();


    List<Route> WhereGradeIs(string grade);
    List<Route> WhereStartsWith(string prefix);
    List<Route> WhereRatingIs(int rating);
    List<Route> RoutesLongerThan(int length);


    Route FirstByGrade (string grade);
    Route FirstOrDefaultByGradeOrDefault (string grade);
    Route LastByGrade (string grade);
    Route LastOrDefaultByGradeOrDefault (string grade);
    Route LastOrDefaultByRating(int rating);
    Route SingleOrDefaultById(int id);


    List<Route> TakeRoute(int howMany);
    List<Route> TakeRoute(Range range);
    List<Route> TakeRouteWhileRatingHigherThan(int rating);
    List<Route> TakeRouteWhileGradeLowerThan(string grade);

    List<Route> SkipRouteWhileRatingLowerThan(int rating);
    List<Route> SkipRouteWhileLenghtLowerThan(int lenght);

    List<Route> DistinctByGrade();

    List<Route[]> ChunkRoutes(int size);
    

}
