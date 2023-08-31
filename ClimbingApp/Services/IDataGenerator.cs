using ClimbingApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.Services;

public interface IDataGenerator
{
    //public List<Route> GetRoutes();
    public void AddClimbers();

    public void AddRoutes();

}
