using ClimbingApp.DataAccess.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.ApplicationServices.Services;

public interface IDataGenerator
{
    public void AddClimbers();

    public void AddRoutes();

}
