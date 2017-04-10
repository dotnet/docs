using System;
using System.Data;
// <Snippet1>
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        SqlConnectionStringBuilder builder =
            new SqlConnectionStringBuilder();
        builder.DataSource = "(local)";
        builder.IntegratedSecurity = true;
        builder.InitialCatalog = "AdventureWorks";

        // Loop through the collection of keys, displaying 
        // the key and value for each item:
        foreach (string key in builder.Keys)
            Console.WriteLine("{0}={1}", key, builder[key]);

        Console.WriteLine();
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
}
// </Snippet1>

