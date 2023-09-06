using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.ApplicationServices.Components.DataProviders;

public interface ICsvProvider
{
    public void GenerateDataFromCsvFiles();
}
