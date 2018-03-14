using System;
using System.Data;
// <Snippet1>
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        SqlConnectionStringBuilder builder =
            new SqlConnectionStringBuilder(GetConnectionString());
        Console.WriteLine("Connection string = " + builder.ConnectionString);

        // Keys you have provided return true.
        Console.WriteLine(builder.ContainsKey("Server"));

        // Comparison is case insensitive, and synonyms
        // are automatically converted to their "well-known"
        // names.
        Console.WriteLine(builder.ContainsKey("Database"));

        // Keys that are valid but have not been set return true.
        Console.WriteLine(builder.ContainsKey("Max Pool Size"));

        // Keys that do not exist return false.
        Console.WriteLine(builder.ContainsKey("MyKey"));

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();

    }

    private static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file. 
        return "Server=(local);Integrated Security=SSPI;" +
            "Initial Catalog=AdventureWorks";
    }
}
// </Snippet1>

