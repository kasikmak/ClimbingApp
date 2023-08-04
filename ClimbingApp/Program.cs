
using ClimbingApp;
using ClimbingApp.Components.CsvReader;
using ClimbingApp.Components.DataProviders;
using ClimbingApp.Components.XmlProcessor;
using ClimbingApp.Data;
using ClimbingApp.Data.Entity;
using ClimbingApp.Data.Repositories;
using ClimbingApp.Data.Repositories.Extensions;
using ClimbingApp.Services;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Climber>, ListRepository<Climber>>();
services.AddSingleton<IRepository<Climber>, FileRepository<Climber>>();
services.AddSingleton<IRepository<Route>, ListRepository<Route>> ();
services.AddSingleton<IRepository<Route>, FileRepository<Route>>();
services.AddSingleton<IClimberProvider, ClimberProvider>();
services.AddSingleton<IRouteProvider, RouteProvider>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<ISpecificInfoProvider, SpecificInfoProvider>();
services.AddSingleton<IEventHandlerService, EventHandlerService>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IXmlProcessor, XmlProcessor>();
services.AddSingleton<ICsvProvider, CsvProvider>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
app.Run();




