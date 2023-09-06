using ClimbingApp.ApplicationServices.Components.CsvReader.Models;
using ClimbingApp.DataAccess.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClimbingApp.ApplicationServices.Components.CsvReader;

public interface ICsvReader
{
    List<Car> ProcessCars(string filePath);

    List<Manufacturer> ProcessManufacturers(string filePath);

    List<Climber> ProcessClimbers(string filePath);
}
