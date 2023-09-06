using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.ApplicationServices.Services;

public abstract class UserCommunicationBase
{
    protected string GetInfoFromUser(string info)
    {
        Console.WriteLine(info);
        string userInfo = Console.ReadLine();
        return userInfo;
    }

    protected int GetInfoFromUserInt(string info)
    {
        Console.WriteLine(info);
        int userInt;
        bool isParsable = int.TryParse(Console.ReadLine(), out userInt);
        return userInt;
    }

    protected void WriteInColor(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}
