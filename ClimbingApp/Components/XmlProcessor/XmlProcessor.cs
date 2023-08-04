using ClimbingApp.Components.CsvReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClimbingApp.Components.XmlProcessor;

public class XmlProcessor : IXmlProcessor
{
    private readonly ICsvReader _csvReader;

    public XmlProcessor(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }
   
    public void ProcessXml()
    {
        CreateXml();
        JoinCsvFilesInXml();
        ReadXml();

        void JoinCsvFilesInXml()
        {
            var carsFromCsvFile = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
            var manufacturersFromCsvFile = _csvReader.ProcessManufacturers("Resources\\Files\\manufacturers.csv");

            var joinedFiles = manufacturersFromCsvFile.GroupJoin(
                carsFromCsvFile,
                manufacturersFromCsvFile => manufacturersFromCsvFile.Name,
                carsFromCsvFile => carsFromCsvFile.Manufacturer,
                (m, c) =>
                new
                {
                    Manufacturer = m,
                    Car = c
                })
                .OrderBy(x => x.Manufacturer.Name);

            var document = new XDocument();
            var manufacturers = new XElement("Manufacturers",
                joinedFiles.Select(x =>
                new XElement("Manufacturer",
                new XAttribute("Name", x.Manufacturer.Name),
                new XAttribute("Country", x.Manufacturer.Country),
                    new XElement("Cars",
                    new XAttribute("Country", x.Manufacturer.Country),
                    new XAttribute("CombinedSum", x.Car.Sum(c => c.Combined)),
                        new XElement("Car", x.Car
                        .Select(c =>
                        new XElement("Car",
                        new XAttribute("Model", c.Name),
                        new XAttribute("Combined", c.Combined)
                    )))))));

            document.Add(manufacturers);
            document.Save("joinedFiles.xml");

        }

        void ReadXml()
        {
            var document = XDocument.Load("fuel.xml");

            var names = document
                .Element("Cars")?
                .Elements("Car")
                .Where(x => x.Attribute("Manufacturer").Value == "Jaguar")
                .Select(x => x.Attribute("Name")?.Value);

            Console.WriteLine("Jaguar cars:");
            foreach (var name in names)
            {                
                Console.WriteLine(name);
            }

        }

        void CreateXml()
        {
            var carsFromCsvFile = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");

            var document = new XDocument();
            var carsXml = new XElement("Cars", carsFromCsvFile
                .Select(x =>
                new XElement("Car",
                    new XAttribute("Name", x.Name),
                    new XAttribute("Combined", x.Combined),
                    new XAttribute("Manufacturer", x.Manufacturer))));

            document.Add(carsXml);
            document.Save("cars.xml");

            var manufacturersFromCsvFile = _csvReader.ProcessManufacturers("Resources\\Files\\manufacturers.csv");

            var document2 = new XDocument();
            var manufacturersXml = new XElement("Manufacturers",
                manufacturersFromCsvFile.Select(x =>
                new XElement("Manufacturer",
                    new XAttribute("Name", x.Name),
                    new XAttribute("Year", x.Year),
                    new XAttribute("Country", x.Country))));

            document2.Add(manufacturersXml);
            document2.Save("producers.xml");
        }
    }

   


}
