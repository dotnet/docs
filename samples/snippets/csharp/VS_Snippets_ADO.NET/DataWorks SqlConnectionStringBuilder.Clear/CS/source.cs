using System;
using System.Data;
// <Snippet1>
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = "(local)";
        builder.IntegratedSecurity = true;
        builder.InitialCatalog = "AdventureWorks";
        Console.WriteLine("Initial connection string: " + builder.ConnectionString);

        builder.Clear();
        Console.WriteLine("After call to Clear, count = " + builder.Count);
        Console.WriteLine("Cleared connection string: " + builder.ConnectionString);
        Console.WriteLine();

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
}
// </Snippet1>

