// <Snippet1>
using System;
using System.Resources;

public class ShowTimeEx
{
    public static void Main()
    {
        ResourceManager rm = new ResourceManager("Strings",
                                 typeof(Example).Assembly);
        string timeString = rm.GetString("TimeHeader");
        Console.WriteLine($"{timeString} {DateTime.Now:T}");
    }
}
// The example displays output like the following:
//        The current time is 2:03:14 PM
// </Snippet1>
