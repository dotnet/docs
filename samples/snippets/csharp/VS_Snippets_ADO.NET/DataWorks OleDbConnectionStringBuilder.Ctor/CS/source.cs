using System;
using System.Data;
// <Snippet1>
using System.Data.OleDb;

class Program
{
    static void Main()
    {
        try
        {
            // Build an empty instance, just to see
            // the contents of the keys.
            DumpBuilderContents("");

            // Create a SQL Server connection string.
            DumpBuilderContents("Provider=sqloledb;Data Source=(local);" +
                "Initial Catalog=AdventureWorks;" +
                "User Id=ab;Password=Password@1");

            // Create an Access connection string.
            DumpBuilderContents("Provider=Microsoft.Jet.OLEDB.4.0;" +
                @"Data Source=C:\Sample.mdb");

            // Create an Oracle connection string.
            DumpBuilderContents("Provider=msdaora;Data Source=SomeOracleDb;" +
                "User Id=userName;Password=Pass@word1;");

            // Create an Sybase connection string.
            DumpBuilderContents("Provider=ASAProv;Data source=myASA");

            Console.WriteLine("Press any key to finish.");
            Console.ReadLine();

        }
        catch (System.ArgumentException ex)
        {

            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static void DumpBuilderContents(string connectString)
    {
        OleDbConnectionStringBuilder builder =
            new OleDbConnectionStringBuilder(connectString);
        Console.WriteLine("=================");
        Console.WriteLine("Original connectString   = " + connectString);
        Console.WriteLine("builder.ConnectionString = " + builder.ConnectionString);
        foreach (string key in builder.Keys)
        {
            Console.WriteLine(key + "=" + builder[key].ToString());
        }
    }
}
// </Snippet1>

