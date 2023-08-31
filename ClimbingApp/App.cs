using ClimbingApp.Components.CsvReader;
using ClimbingApp.Components.DataProviders;
using ClimbingApp.Components.XmlProcessor;
using ClimbingApp.Services;

namespace ClimbingApp;

public class App : IApp
{
    private readonly IUserCommunication _userCommunication;
    private readonly IEventHandlerService _eventHandlerService;
    private readonly ICsvProvider _csvProvider;
    private readonly IXmlProcessor _xmlProcessor;
    private readonly IDataGenerator _dataGenerator;

    public App(IUserCommunication userCommunication, IEventHandlerService eventHandlerService, ICsvProvider csvProvider, IXmlProcessor xmlProcessor, IDataGenerator dataGenerator)
    {
       _userCommunication = userCommunication;
       _eventHandlerService = eventHandlerService;
       _csvProvider = csvProvider;
       _xmlProcessor = xmlProcessor;
       _dataGenerator = dataGenerator;
    }

 
    public void Run()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.BackgroundColor = ConsoleColor.Blue;        
        Console.WriteLine("Welcome to application for climbers to log their climbs.");        
        Console.ResetColor();
        Console.WriteLine("--------------------------------------------------------");

        
        _eventHandlerService.SubscribeToEvents();

        _dataGenerator.AddRoutes();

        //_csvProvider.GeneratDataFromCsvFiles();
        //_xmlProcessor.ProcessXml();

        _userCommunication.ChooseWhatToDo();
        
    }
}
