using ClimbingApp.DataProviders;
using ClimbingApp.Entity;
using ClimbingApp.Repositories;
using ClimbingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp;

public class App : IApp
{
    private readonly IUserCommunication _userCommunication;
    private readonly IEventHandlerService _eventHandlerService;

    public App(IUserCommunication userCommunication, IEventHandlerService eventHandlerService)
    {
       _userCommunication = userCommunication;
       _eventHandlerService = eventHandlerService;
    }

 
    public void Run()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.BackgroundColor = ConsoleColor.Blue;        
        Console.WriteLine("Welcome to application for climbers to log their climbs.");        
        Console.ResetColor();
        Console.WriteLine("--------------------------------------------------------");

        _eventHandlerService.SubscribeToEvents();

        _userCommunication.ChooseWhatToDo();
        
    }
}
