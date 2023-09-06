using ClimbingApp.ApplicationServices.Components.CsvReader;
using ClimbingApp.ApplicationServices.Components.CsvReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.ApplicationServices.Components.DataProviders;

public class CsvProvider : ICsvProvider
{
    private readonly ICsvReader _csvReader;

    public CsvProvider(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public void GenerateDataFromCsvFiles()
    {
       
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturers = _csvReader.ProcessManufacturers("Resources\\Files\\manufacturers.csv");

        //Group by 

        GroupByManufactureresByName(cars);
        GroupByManufacturersAndCity(cars);

        //Join
        JoinManufactureresAndCars(manufacturers, cars);

        //GrouoJoin
        GroupJoinManufacturersAndCarsByManufacturers(manufacturers, cars);


    }

    private void GroupByManufacturersAndCity(List<Car> cars)
    {
        var carsInCity = cars
            .GroupBy(x => x.Manufacturer)
            .OrderBy(x => x.Key);


        foreach (var car in carsInCity)
        {
            Console.WriteLine(car.Key);

            foreach (var c in car.OrderBy(x => x.City).Where(x => x.City < 20).Take(3))
            {
                Console.WriteLine($"Car: {c.Name} Fuel in city: {c.City}");
            }
        }

    }

    private void GroupJoinManufacturersAndCarsByManufacturers(List<Manufacturer> manufacturers, List<Car> cars)
    {
        var joinedGroups = manufacturers.GroupJoin(cars,
            manufacturer => manufacturer.Name,
            car => car.Manufacturer,
            (m, g) => new
            {
                Manufacturer = m,
                Car = g
            })
            .OrderBy(x => x.Manufacturer.Name);

        foreach (var car in joinedGroups)
        {
            Console.WriteLine($"Manufacturer: {car.Manufacturer.Name}");
            Console.WriteLine($"Number of cars: {car.Car.Count()}");
            Console.WriteLine($"Max combined: {car.Car.Max(x => x.Combined)}");
            Console.WriteLine($"Min combined: {car.Car.Min(x => x.Combined)}");

        }
    }

    private void JoinManufactureresAndCars(List<Manufacturer> manufacturers, List<Car> cars)
    {
        var carsInCountry = manufacturers.Join(cars,
            x => x.Name,
            x => x.Manufacturer,
            (m, c) => new
            {
                m.Country,
                c.Manufacturer,
                c.Name,
                c.Combined
            })
            .OrderBy(x => x.Country)
            .ThenBy(x => x.Combined)
            .ThenBy(x => x.Name);

        foreach (var car in carsInCountry)
        {
            Console.WriteLine($"Country: {car.Country}");
            Console.WriteLine($"Car: {car.Manufacturer} {car.Name}");
            Console.WriteLine($"Combined: {car.Combined}");
        }
    }

    private void GroupByManufactureresByName(List<Car> cars)
    {
        var groups = cars
            .GroupBy(x => x.Manufacturer)
            .Select(g => new
            {
                Name = g.Key,
                Max = g.Max(c => c.Combined),
                Min = g.Min(c => c.Combined),
                Average = g.Average(c => c.Combined),
            })
            .OrderBy(x => x.Name);

        foreach (var group in groups)
        {
            Console.WriteLine($"Car: {group.Name}");
            Console.WriteLine($"Max combined: {group.Max}");
            Console.WriteLine($"Min combined: {group.Min}");
            Console.WriteLine($"Average combined: {group.Average}");
        }
    }
}
