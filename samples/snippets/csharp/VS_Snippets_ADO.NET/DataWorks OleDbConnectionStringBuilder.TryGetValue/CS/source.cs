using System;
using System.Data;
// <Snippet1>
using System.Data.OleDb;

class Program
{
    static void Main()
    {
        OleDbConnectionStringBuilder builder =
            new OleDbConnectionStringBuilder();
        builder.ConnectionString = GetConnectionString();

        // Call TryGetValue method for multiple
        // key names. 
        DisplayValue(builder, "Data Source");
        DisplayValue(builder, "Extended Properties");
        // How about implicitly added key/value pairs?
        DisplayValue(builder, "Jet OLEDB:System database");
        // Invalid keys?
        DisplayValue(builder, "Invalid Key");
        // Null values?
        DisplayValue(builder, null);

        Console.WriteLine("Press any key to continue.");
        Console.ReadLine();
    }

    static private void DisplayValue(OleDbConnectionStringBuilder builder, string key)
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
        catch (ArgumentNullException)
        {
            Console.WriteLine("Unable to retrieve value for null key.");
        }
    }

    static private string GetConnectionString()
    {
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file using the 
        // System.Configuration.ConfigurationSettings.AppSettings property. 
        return "Provider=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=C:\\ExcelDemo.xls;" +
            "Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
    }
}
// </Snippet1>

