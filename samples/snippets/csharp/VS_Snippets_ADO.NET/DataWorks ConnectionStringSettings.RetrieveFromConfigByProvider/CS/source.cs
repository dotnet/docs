using System;
using System.Configuration;

internal static class Program
{
    static void Main()
    {
        var s = GetConnectionStringByProvider("System.Data.SqlClient");
        Console.WriteLine(s);
        Console.ReadLine();
    }

    // <Snippet1>
    // Retrieve a connection string by specifying the providerName.
    // Assumes one connection string per provider in the config file.
    static string? GetConnectionStringByProvider(string providerName)
    {
        // Get the collection of connection strings.
        ConnectionStringSettingsCollection? settings =
            ConfigurationManager.ConnectionStrings;

        // Walk through the collection and return the first
        // connection string matching the providerName.
        if (settings != null)
        {
            foreach (ConnectionStringSettings cs in settings)
            {
                if (cs.ProviderName == providerName)
                {
                    return cs.ConnectionString;
                }
            }
        }
        return null;
    }
    // </Snippet1>
}
