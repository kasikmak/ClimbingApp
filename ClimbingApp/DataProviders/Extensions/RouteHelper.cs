using ClimbingApp.Entity;
using ClimbingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.DataProviders.Extensions;

public static class RouteHelper
{

    public static float ConvertGrades(this string grade)
    {
        float gradeAsFloat;
        grade.ToUpper();
        switch (grade)  
        {            
            case "4A" or "IV-":
                return gradeAsFloat = 4f;
            case "4B" or "IV":
                return gradeAsFloat = 4.1f;
            case "4C" or "IV+":
                return gradeAsFloat = 4.2f;
            case "5A" or "V-":
                return gradeAsFloat = 5f;
            case "5B" or "V":
                return gradeAsFloat = 5.1f;
            case "5C" or "V+":
                return gradeAsFloat = 5.2f;
            case "5C+" or "VI-":
                return gradeAsFloat = 6f;
            case "6A" or "VI":
                return gradeAsFloat = 6.1f;
            case "6A+" or "VI+":
                return gradeAsFloat = 6.2f;
            case "6B" or "VI.1":
                return gradeAsFloat = 6.3f;
            case "6B+" or "VI.1+":
                return gradeAsFloat = 6.4f;
            case "6C" or "VI.2":
                return gradeAsFloat = 6.5f;
            case "6C+" or "VI.2+":
                return gradeAsFloat = 6.6f;
            case "7A" or "VI.3":
                return gradeAsFloat = 7f;
            case "7A+" or "VI.3+":
                return gradeAsFloat = 7.1f;
            case "7B" or "VI.4":
                return gradeAsFloat = 7.2f;
            case "7C" or "VI.4+":
                return gradeAsFloat = 7.3f;
            case "7C+" or "VI.5":
                return gradeAsFloat = 7.4f;
            case "8A" or "VI.5+":
                return gradeAsFloat = 8f;
            case "8B" or "VI.6":
                return gradeAsFloat = 8.1f;
            case "8B+" or "VI.6+":
                return gradeAsFloat = 8.2f;
            case "8C" or "VI.7":
                return gradeAsFloat = 8.3f;
            case "8C+" or "VI.7+":
                return gradeAsFloat = 8.4f;
            case "9A" or "VI.8":
                return gradeAsFloat = 9f;
            case "9A+" or "9b" or "VI.8+":
                return gradeAsFloat = 9.1f;
            case "9B+" or "VI.9":
                return gradeAsFloat = 9.2f;
            case "9C" or "VI.9+":
                return gradeAsFloat = 9.3f;
            default:
                return gradeAsFloat = 0f;
        }
    }
}
