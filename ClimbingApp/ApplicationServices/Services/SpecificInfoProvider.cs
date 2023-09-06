using ClimbingApp.ApplicationServices.Components.DataProviders;
using ClimbingApp.DataAccess.Data.Entity;
using ClimbingApp.DataAccess.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.ApplicationServices.Services;

public class SpecificInfoProvider : UserCommunicationBase, ISpecificInfoProvider
{
    private readonly IRouteProvider _routeProvider;
    private readonly IClimberProvider _climberProvider;

    public SpecificInfoProvider(IRouteProvider routeProvider, IClimberProvider climberProvider)
    {
        _routeProvider = routeProvider;
        _climberProvider = climberProvider;
    }

    public void GetSpecificInfo()
    {
        bool closeQuery = false;

        while (!closeQuery)
        {
            WriteInColor(ConsoleColor.DarkYellow,
                "You can view different kind of information:\n" +
                "1 - Order climber by <LastName and FirstName>\n" +
                "2 - Order routes by <rating>\n" +
                "3 - Order routes by <Grade>\n" +
                "4 - Routes where <Grade> is lower than....\n" +
                "5 - Recommended routes: where <Rating> is higher than...\n" +
                "6 - Routes longer than <Length>\n" +
                "X - Back to main menu");

            var infoFromUser = GetInfoFromUser("What do you want to do?\n Choose 1,2,3,4,5,6 or X").ToUpper();

            switch (infoFromUser)
            {
                case "1":
                    OrederClimberByLastNameAndFirstName();
                    break;

                case "2":
                    OrderRoutesByRating();
                    break;

                case "3":
                    OrderRoutesByGradeAndName();
                    break;

                case "4":
                    GetRoutesWhereGradeIsLowerThan();
                    break;

                case "5":
                    GetRoutesWhereRatingIsHigherThan();
                    break;

                case "6":
                    GetRoutesLongerThan();
                    break;

                case "X":
                    closeQuery = true;
                    break;

                default:
                    WriteInColor(ConsoleColor.DarkRed, "You have to type 1-6 or x.");
                    continue;

            }
        }
    }

    private void GetRoutesLongerThan()
    {
        WriteInColor(ConsoleColor.Blue, "--Routes longer than--");
        int input6 = GetInfoFromUserInt("Enter the <Length> value");
        var routeLongerThan = _routeProvider.RoutesLongerThan(input6);
        foreach (var route in routeLongerThan)
        {
            Console.WriteLine(route);
        }

    }

    private void GetRoutesWhereRatingIsHigherThan()
    {
        WriteInColor(ConsoleColor.Blue, "--Routes with rating higher than--");
        int input5 = GetInfoFromUserInt("Enter number 1-5 for <Rating>");
        if (input5 >= 1 && input5 <= 5)
        {
            var routeWithRating = _routeProvider.TakeRouteWhileRatingHigherThan(input5);
            foreach (var route in routeWithRating)
            {
                Console.WriteLine(route);
            }
        }
        else
        {
            WriteInColor(ConsoleColor.DarkRed, "You have to enter numbers 1-5.");
        }
    }

    private void GetRoutesWhereGradeIsLowerThan()
    {
        WriteInColor(ConsoleColor.Blue, "--Routes with grade lower than--");
        var input4 = GetInfoFromUser("Enter <Grade>").ToUpper();
        var routeWithGrade = _routeProvider.TakeRouteWhileGradeLowerThan(input4);
        foreach (var route in routeWithGrade)
        {
            Console.WriteLine(route);
        }
    }

    private void OrederClimberByLastNameAndFirstName()
    {
        WriteInColor(ConsoleColor.Blue, "--Climbers by LastName and FirstName");
        var climbersByLastAndFirstName = _climberProvider.OrderByLastNameAndFirstName();
        foreach (var climber in climbersByLastAndFirstName)
        {
            Console.WriteLine(climber);
        }
    }

    private void OrderRoutesByRating()
    {
        WriteInColor(ConsoleColor.Blue, "--Routes by rating--");
        var routesByRating = _routeProvider.OrderByRating();
        foreach (var route in routesByRating)
        {
            Console.WriteLine(route);
        }
    }

    private void OrderRoutesByGradeAndName()
    {
        WriteInColor(ConsoleColor.Blue, "--Routes by grade and name--");
        var routesByGrade = _routeProvider.OrderByGradeAndName();
        foreach (var route in routesByGrade)
        {
            Console.WriteLine(route);
        }
    }
}
