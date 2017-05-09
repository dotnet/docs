using System;
using System.Data;
// <Snippet1>
using System.Data.Odbc;

class Program
{
    static void Main()
    {
        OdbcConnectionStringBuilder builder = 
            new OdbcConnectionStringBuilder();
        builder.ConnectionString = GetConnectionString();

        // Call TryGetValue method for multiple
        // key names. Demonstrate that the search is not
        // case sensitive.
        DisplayValue(builder, "Driver");
        DisplayValue(builder, "SERVER");
        // How about a property you did not set?
        DisplayValue(builder, "DNS");
        // Invalid keys?
        DisplayValue(builder, "Invalid Key");
        // Null values?
        DisplayValue(builder, null);

        Console.WriteLine("Press any key to continue.");
        Console.ReadLine();
    }

    private static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file using the 
        // System.Configuration.ConfigurationSettings.AppSettings property. 
        return "Driver={SQL Server};Server=(local);" +
            "Database=AdventureWorks;Trusted_Connection=yes;";
    }

    private static void DisplayValue(OdbcConnectionStringBuilder builder, string key)
    {
        object value = null;

        // Although TryGetValue handles missing keys,
        // it does not handle passing in a null (Nothing in Visual Basic)
        // key. This example traps for that particular error, but
        // throws any other unknown exceptions back out to the
        // caller. 
        try
        {
            if (builder.TryGetValue(key, out value))
            {
                Console.WriteLine("{0}='{1}'", key, value);
            }
            else
            {
                Console.WriteLine("Unable to retrieve value for '{0}'", key);
            }
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Unable to retrieve value for null key.");
        }
    }
}
// </Snippet1>

