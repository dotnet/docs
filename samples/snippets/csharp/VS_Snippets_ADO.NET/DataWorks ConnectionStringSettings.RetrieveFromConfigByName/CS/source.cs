using System;
using System.Configuration;

class Program
{
    static void Main()
    {
        string? s = GetConnectionStringByName("NorthwindSQL");
        Console.WriteLine(s);
        Console.ReadLine();
    }
    // <Snippet1>
    // Retrieves a connection string by name.
    // Returns null if the name is not found.
    static string? GetConnectionStringByName(string name)
    {
        // Look for the name in the connectionStrings section.
        ConnectionStringSettings? settings =
            ConfigurationManager.ConnectionStrings[name];

        // If found, return the connection string (otherwise return null)
        return settings?.ConnectionString;
    }
    // </Snippet1>
}
