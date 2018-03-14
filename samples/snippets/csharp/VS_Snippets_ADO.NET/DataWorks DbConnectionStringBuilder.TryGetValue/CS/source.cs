using System;
using System.Data;
using System.Data.Common;

class Program
{
    // <Snippet1>
    static void Main()
    {
        DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
        builder.ConnectionString = 
            "Provider=sqloledb;Data Source=192.168.168.1,1433;" +
            "Network Library=DBMSSOCN;Initial Catalog=pubs;" +
            "Integrated Security=SSPI;";

        // Call TryGetValue method for multiple
        // key names.
        DisplayValue(builder, "Provider");
        DisplayValue(builder, "DATA SOURCE");
        DisplayValue(builder, "InvalidKey");
        DisplayValue(builder, null);

        Console.ReadLine();
    }

    private static void DisplayValue(
        DbConnectionStringBuilder builder, string key)
    {
        object value = null;

        // Although TryGetValue handles missing keys,
        // it doesn't handle passing in a null 
        // key. This example traps for that particular error, but
        // bubbles any other unknown exceptions back out to the
        // caller. 
        try
        {
            if (builder.TryGetValue(key, out value))
            {
                Console.WriteLine("{0}={1}", key, value);
            }
            else
            {
                Console.WriteLine(@"Unable to retrieve value for '{0}'", key);
            }
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Unable to retrieve value for null key.");
        }
    }
    // </Snippet1>
}

