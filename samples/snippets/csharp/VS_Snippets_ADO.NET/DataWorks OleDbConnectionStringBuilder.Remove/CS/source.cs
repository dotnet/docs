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
        builder.ConnectionString =
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Sample.mdb;" +
            "Jet OLEDB:System Database=C:\\system.mdw;";

        Console.WriteLine(builder.ConnectionString);

        // Try to remove an existing item.
        TryRemove(builder, "Provider");

        // Try to remove a nonexistent item.
        TryRemove(builder, "User ID");

        // try to remove an existing item, 
        // demonstrating that the search isn't 
        // case sensitive.
        TryRemove(builder, "DATA SOURCE");

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    static void TryRemove(OleDbConnectionStringBuilder builder, 
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

