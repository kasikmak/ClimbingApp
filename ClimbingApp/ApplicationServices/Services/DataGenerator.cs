﻿using ClimbingApp.ApplicationServices.Components.CsvReader;
using ClimbingApp.ApplicationServices.Components.DataProviders;
using ClimbingApp.DataAccess.Data;
using ClimbingApp.DataAccess.Data.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.ApplicationServices.Services;

public class DataGenerator : IDataGenerator
{
    private readonly ClimbingAppDbContext _dbContext;
    private readonly ICsvReader _csvReader;

    public DataGenerator(ClimbingAppDbContext dbContext, ICsvReader csvReader)
    {
        _dbContext = dbContext;
        _csvReader = csvReader;
        _dbContext.Database.EnsureCreated();
    }

   public void AddClimbers()
    {
        var climbers = _csvReader.ProcessClimbers("DataAccess\\Resources\\Files\\climbers.csv");

        if (_dbContext.Database.CanConnect() && !_dbContext.Climbers.Any())
        {
            foreach (var climber in climbers)
            {
                _dbContext.Climbers.Add(climber);
            }

            _dbContext.SaveChanges();
        }
    }


    public void AddRoutes()
    {
        var routes = GetRoutes();

        if (_dbContext.Database.CanConnect() && !_dbContext.Routes.Any())
        {
            foreach (var route in routes)
            {
                _dbContext.Routes.Add(route);
            }

            _dbContext.SaveChanges();
        }
    }

    public IEnumerable<Route> GetRoutes()
    {
        var routes = new List<Route>()
        {
            new Route()
            {
                Name = "Hopsaki".ToUpper(),
                Grade = "5+",
                GradeAsFloat = 5.2f,
                Length = 8,
                Rating = 0,
                IsClimbed = false
            },

            new Route()
            {
                Name = "Dziaders Plus".ToUpper(),
                Grade = "6.1",
                GradeAsFloat = 6.3f,
                Length = 15,
                Rating = 5,
                IsClimbed = false
            },

            new Route()
            {
                Name = "Strefa Zgniotu".ToUpper(),
                Grade = "6-",
                GradeAsFloat = 6f,
                Length = 15,
                Rating = 4,
                IsClimbed = true
            },

            new Route()
            {
                Name = "Pył Znad Sahary".ToUpper(),
                Grade = "5+",
                GradeAsFloat = 5.2f,
                Length = 15  ,
                Rating = 4,
                IsClimbed = true
            },

            new Route()
            {
                Name = "Kieszonkowy Dyktator".ToUpper(),
                Grade = "VI",
                GradeAsFloat = 6.1f,
                Length = 15,
                Rating = 5,
                IsClimbed = true
            },

            new Route()
            {
                Name = "Mały Skos".ToUpper(),
                Grade = "5",
                GradeAsFloat = 5.1f,
                Length = 12,
                Rating = 3,
                IsClimbed = true
            },

            new Route()
            {
                Name = "Kant Urwiska".ToUpper(),
                Grade = "6.1",
                GradeAsFloat = 6.3f,
                Length = 10,
                Rating = 0,
                IsClimbed = false
            },

            new Route()
            {
                Name = "Rysy Dziadersów".ToUpper(),
                Grade = "6",
                GradeAsFloat = 6.1f,
                Length = 15,
                Rating = 5,
                IsClimbed = true
            },

            new Route()
            {
                Name = "Truściński".ToUpper(),
                Grade = "6",
                GradeAsFloat = 6.1f,
                Length = 15,
                Rating = 4,
                IsClimbed = true
            },
        };

        return routes;
    }
}


