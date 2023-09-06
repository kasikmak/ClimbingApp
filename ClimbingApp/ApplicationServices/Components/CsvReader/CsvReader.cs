using ClimbingApp.ApplicationServices.Components.CsvReader.Extensions;
using ClimbingApp.ApplicationServices.Components.CsvReader.Models;
using ClimbingApp.DataAccess.Data.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClimbingApp.ApplicationServices.Components.CsvReader;

public class CsvReader : ICsvReader
{
    public List<Car> ProcessCars(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Car>();
        }

        var cars = File.ReadAllLines(filePath)
             .Skip(1)
             .Where(x => x.Length > 0)
             .ToCar();

        return cars.ToList();
    }

    public List<Manufacturer> ProcessManufacturers(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Manufacturer>();
        }

        var manufacturers = File.ReadAllLines(filePath)
            .Where(x => x.Length > 0)
            .Select(x =>
            {
                var columns = x.Split(',');
                return new Manufacturer()
                {
                    Name = columns[0],
                    Country = columns[1],
                    Year = int.Parse(columns[2])
                };
            });

        return manufacturers.ToList();
    }

    public List<Climber> ProcessClimbers(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Climber>();
        }

        var climbers = File.ReadAllLines(filePath)
            .Where(x => x.Length > 0)
            .Select(x =>
            {
                var columns = x.Split(',');
                return new Climber()
                {
                    FirstName = columns[0],
                    LastName = columns[1],
                    Nationality = columns[2]
                };
            });

        return climbers.ToList();
    }
}
