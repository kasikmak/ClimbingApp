﻿using ClimbingApp.ApplicationServices.Components.CsvReader.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.ApplicationServices.Components.CsvReader.Extensions;

public static class CarExtensions
{
    public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
    {
        foreach (var line in source)
        {
            var columns = line.Split(',');

            yield return new Car
            {
                Year = int.Parse(columns[0]),
                Manufacturer = columns[1],
                Name = columns[2],
                Displacement = double.Parse(columns[3], CultureInfo.InvariantCulture),
                Cylinders = int.Parse(columns[4]),
                City = int.Parse(columns[5]),
                Highway = int.Parse(columns[6]),
                Combined = int.Parse(columns[7]),
            };
        }
    }
}
