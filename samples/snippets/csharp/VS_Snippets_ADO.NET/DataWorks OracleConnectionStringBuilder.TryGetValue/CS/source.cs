using System;
using System.Data;
// <Snippet1>
// You may need to set a reference to the System.Data.OracleClient
// assembly before you can run this sample.
using System.Data.OracleClient;

class Program
{
    static void Main()
    {
        OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder();
        builder.ConnectionString = GetConnectionString();

        // Call TryGetValue method for multiple
        // key names. Note that these keys are converted
        // to well-known synonynms for data retrieval.
        DisplayValue(builder, "Data Source");
        DisplayValue(builder, "Trusted_Connection");
        DisplayValue(builder, "InvalidKey");
        DisplayValue(builder, null);

        Console.WriteLine("Press any key to continue.");
        Console.ReadLine();
    }

    private static void DisplayValue(OracleConnectionStringBuilder builder, string key)
    {
        object value = null;

        // Although TryGetValue handles missing keys,
        // it does not handle passing in a null
        // key. This example traps for that particular error, but
        // passes any other unknown exceptions back out to the
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
        catch (ArgumentNullException)
        {
            Console.WriteLine("Unable to retrieve value for null key.");
        }
    }

    private static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file. 
        return "Server=OracleDemo;Integrated Security=True";
    }
}
// </Snippet1>

