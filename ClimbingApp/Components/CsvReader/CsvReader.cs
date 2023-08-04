using ClimbingApp.Components.CsvReader.Extensions;
using ClimbingApp.Components.CsvReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.Components.CsvReader;

public class CsvReader : ICsvReader
{
    public List<Car> ProcessCars(string filePath)
    {
       if(!File.Exists(filePath))
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
        if(!File.Exists(filePath))
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
}
