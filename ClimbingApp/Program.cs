
using ClimbingApp;
using ClimbingApp.Components.CsvReader;
using ClimbingApp.Components.DataProviders;
using ClimbingApp.Components.XmlProcessor;
using ClimbingApp.Data;
using ClimbingApp.Data.Entity;
using ClimbingApp.Data.Repositories;
using ClimbingApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
//services.AddSingleton<IRepository<Climber>, ListRepository<Climber>>();
services.AddSingleton<IRepository<Climber>, SqlRepository<Climber>>();
//services.AddSingleton<IRepository<Route>, ListRepository<Route>> ();
services.AddSingleton<IRepository<Route>, SqlRepository<Route>>();
services.AddSingleton<IClimberProvider, ClimberProvider>();
services.AddSingleton<IRouteProvider, RouteProvider>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<ISpecificInfoProvider, SpecificInfoProvider>();
services.AddSingleton<IEventHandlerService, EventHandlerService>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IXmlProcessor, XmlProcessor>();
services.AddSingleton<ICsvProvider, CsvProvider>();
services.AddSingleton<IDataGenerator,  DataGenerator>();
services.AddDbContext<ClimbingAppDbContext>(options => options
    .UseSqlServer("Data source=DESKTOP-KSU5O1R\\SQLEXPRESS;Initial Catalog=ClimbingAppStorage;Integrated Security=True;Trust Server Certificate=True"));

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
app.Run();
