//<Snippet1>
using System;
using System.Management;

public class EventSample 
{
    public static void Main(string[] args) 
    {
        // Full query string specified to the constructor
        WqlEventQuery q = 
            new WqlEventQuery("SELECT * FROM Win32_ComputerShutdownEvent");
   
        // Only relevant event class name specified to the constructor   
        // Results in the same query as above.
        WqlEventQuery query =
            new WqlEventQuery("Win32_ComputerShutdownEvent ");

        Console.WriteLine(query.QueryString);
        return;
    }
}
//</Snippet1>