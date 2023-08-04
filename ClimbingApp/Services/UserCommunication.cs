using ClimbingApp.Components.CsvReader;
using ClimbingApp.Components.DataProviders;
using ClimbingApp.Components.DataProviders.Extensions;
using ClimbingApp.Components.XmlProcessor;
using ClimbingApp.Data.Entity;
using ClimbingApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.Services;

public class UserCommunication : UserCommunicationBase, IUserCommunication
{
    private readonly IRepository<Climber> _climberRepository;
    private readonly IRepository<Route> _routeRepository;
    private readonly IClimberProvider _climberProvider;
    private readonly IRouteProvider _routeProvider;
    private readonly ISpecificInfoProvider _specificInfoProvider;
    private readonly ICsvReader _csvReader;
    

    public UserCommunication(
        IRepository<Climber> climberRepository,
        IRepository<Route> routeRepository,
        IClimberProvider ClimberProvider,
        IRouteProvider routeProvider,
        ISpecificInfoProvider specificInfoProvider,
        ICsvReader csvReader       
        )
   
    {
        _climberRepository = climberRepository;
        _routeRepository = routeRepository;
        _climberProvider = ClimberProvider;
        _routeProvider = routeProvider;
        _specificInfoProvider = specificInfoProvider;
        _csvReader = csvReader;
        
    }

    

    public void ChooseWhatToDo()
    {
        
        bool ExitApp = false;


        while (!ExitApp)
        {

            WriteInColor(ConsoleColor.DarkCyan, "------------MAIN MENU------------\n+" +
                "You have following options:\n" +
                "1 - Display all data\n" +
                "2 - Enter new data\n" +
                "3 - Find data by Id\n" +
                "4 - Remove some data\n" +
                "5 - Get specific information\n" +
                "X - Close the app and save changes");

            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    var userChoiceWhatToShow = GetInfoFromUser("Choose C to view all climbers\nChoose R to view all routes").ToUpper();
                    if (userChoiceWhatToShow == "C")
                    {
                        WriteAllToConsole(_climberRepository);
                        break;
                    }
                    if (userChoiceWhatToShow == "R")
                    {
                        WriteAllToConsole(_routeRepository);
                        break;
                    }
                    break;
                case "2":
                    var userChoiceWhatToEnter = GetInfoFromUser("Choose C to enter new climber\nChoose R to enter new route").ToUpper();
                    if (userChoiceWhatToEnter == "C")
                    {
                        AddClimber(_climberRepository);
                        break;
                    }
                    if (userChoiceWhatToEnter == "R")
                    {
                        AddRoute(_routeRepository);
                        break;
                    }
                    break;
                case "3":
                    var userChoiceToFind = GetInfoFromUser("C - Find climber by id\nR - Find route by id\nQ - go back to the menu.").ToUpper();
                    if (userChoiceToFind == "C")
                    {
                        FindDataById(_climberRepository);
                        break;
                    }
                    if (userChoiceToFind == "R")
                    {
                        FindDataById(_routeRepository);
                        break;
                    }
                    break;
                case "4":
                    var userChoiceWhatToRemove = GetInfoFromUser("Choose C to remove the climber\nChoose R to remove the route").ToUpper();
                    if (userChoiceWhatToRemove == "C")
                    {
                        RemoveData(_climberRepository);
                        break;
                    }
                    if (userChoiceWhatToRemove == "R")
                    {
                        RemoveData(_routeRepository);
                        break;
                    }
                    break;
                case "5":
                    _specificInfoProvider.GetSpecificInfo();
                    break;
                case "x" or "X":
                    ExitApp = CloseAppAndSave(_climberRepository, _routeRepository);
                    break;
                default:
                    WriteInColor(ConsoleColor.DarkRed, "You have to type 1,2,3 or X");
                    continue;
            }
        }
    }

    private bool CloseAppAndSave(IRepository<Climber> climberRepository, IRepository<Route> routeRepository)
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
                WriteInColor(ConsoleColor.DarkRed, "You have to choose YES or NO");
            }
        }
    }

    private void WriteAllToConsole<T>(IReadRepository<T> repository) where T : class, IEntity, new()
    {
        var items = repository.GetAll();
        if (items.ToList().Count == 0)
        {
            WriteInColor(ConsoleColor.DarkGreen, "No data found");
        }
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    private void RemoveData<T>(IRepository<T> repository) where T : class, IEntity, new()
    {
        var dataFound = FindDataById(repository);
        if (dataFound != null)
        {
            while (true)
            {
                var userChoiceIfRemove = GetInfoFromUser($"Do you really want to remove {typeof(T).Name}? Write Y for YES\t\tWrite N for NO.").ToUpper();
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
                    WriteInColor(ConsoleColor.DarkRed, "Please enter Y or N");
                }
            }
        }
    }

    private T? FindDataById<T>(IRepository<T> repository) where T : class, IEntity, new()
    {
        while (true)
        {
            Console.WriteLine($"Enter the ID of the {typeof(T).Name} you want to find.");
            var userChoiceId = Console.ReadLine();
            int userChoiceIdValue;
            var choiceIsParsed = int.TryParse(userChoiceId, out userChoiceIdValue);
            if (!choiceIsParsed)
            {
                WriteInColor(ConsoleColor.DarkRed, "You need to enter whole number for ID");
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

    private void AddClimber(IRepository<Climber> climberRepository)
    {
        string firstName = GetInfoFromUser("Enter climber's first name").ToUpper();
        string lastName = GetInfoFromUser("Enter climber's last name").ToUpper();
        string nationality = GetInfoFromUser("Enter climber's nationality").ToUpper();
        if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
        {
            var newClimber = new Climber { FirstName = firstName, LastName = lastName, Nationality = nationality };
            climberRepository.Add(newClimber);
        }
    }

    private void AddRoute(IRepository<Route> routeRepository)
    {
        string name = GetInfoFromUser("Enter route's name").ToUpper();
        string grade = AddGrade();
        float gradeAsFloat = grade.ConvertGrades();
        int length = GetInfoFromUserInt("Enter route's length");
        int rating = GetInfoFromUserInt("Enter your rating of the route in the scale 1-5. Enter 0 if you do not want to rate the route.");

        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(grade))
        {
            while (true)
            {

                var userChoiceRouteType = GetInfoFromUser("Is it a sport route or a boulder.\nChoose S for sport and B for boulder").ToUpper();
                if (userChoiceRouteType == "S")
                {
                    var newSportRoute = new SportRoute { Name = name, Grade = grade, GradeAsFloat = gradeAsFloat, Length = length, Rating = rating };

                    routeRepository.Add(newSportRoute);
                    /*if (newSportRoute.Rating == 5)
                    {
                        
                            //.Invoke(this, newSportRoute);
                    }*/
                    break;
                }
                if (userChoiceRouteType == "B")
                {
                    var newBoulder = new Boulder { Name = name, Grade = grade, GradeAsFloat = gradeAsFloat, Length = length, Rating = rating };
                    routeRepository.Add(newBoulder);
                    break;
                }
                else
                {
                    WriteInColor(ConsoleColor.DarkRed, "Please write S or B");
                }
                break;
            }
        }
    }

    /*private void HighRatingRouteAdded(object sender, Route route)
    {
        Console.WriteLine("Rating 5 - highly recommended route!");
    } */

    private string AddGrade()
    {
        while (true)
        {
            string grade = GetInfoFromUser("Enter route's grade in French (4a-9c) or Polish (IV-VI.9) scale").ToUpper();
            var gradeAsFloat = grade.ConvertGrades();
            if (gradeAsFloat >= 4 && gradeAsFloat <= 9.3)
            {
                return grade;
            }
            else
            {
                WriteInColor(ConsoleColor.DarkRed, "You entered wrong grade. Try again");
            }
        }
    }


}
