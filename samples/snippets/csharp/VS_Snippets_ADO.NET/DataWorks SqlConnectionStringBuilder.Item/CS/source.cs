using System;
using System.Data;
using System.Data.SqlClient;

// <Snippet1>
class Program
{
    static void Main()
    {
        SqlConnectionStringBuilder builder = 
            new SqlConnectionStringBuilder();
        builder["Data Source"] = "(local)";
        builder["Integrated Security"] = true;
        builder["Initial Catalog"] = "AdventureWorks";

        // Overwrite the existing value for the Data Source value.
        builder["Data Source"] = ".";

        Console.WriteLine(builder.ConnectionString);
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
}
// </Snippet1>

