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
        builder.ConnectionString =
            "Driver={SQL Server};Server=(local);" +
            "Database=AdventureWorks;Trusted_Connection=yes;";

        Console.WriteLine(builder.ConnectionString);

        // Try to remove an existing item.
        TryRemove(builder, "Server");

        // Try to remove a nonexistent item.
        TryRemove(builder, "User ID");

        // Try to remove an existing item, 
        // demonstrating that the search is not 
        // case sensitive.
        TryRemove(builder, "DATABASE");

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    static void TryRemove(OdbcConnectionStringBuilder builder, 
        string itemToRemove)
    {

        if (builder.Remove(itemToRemove))
        {
            Console.WriteLine("Removed '{0}'", itemToRemove);
        }
        else
        {
            Console.WriteLine("Unable to remove '{0}'", itemToRemove);
        }
        Console.WriteLine(builder.ConnectionString);
    }
}
// </Snippet1>

