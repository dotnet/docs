using System;
using System.Data;
using System.Data.Common;

class Program
{
    // <Snippet1>
    static void Main()
    {
        DbConnectionStringBuilder builder = new
            DbConnectionStringBuilder();
        builder.ConnectionString =
            @"Provider=Microsoft.Jet.OLEDB.4.0;Data 
                Source=C:\Demo.mdb;" +
            "Jet OLEDB:System Database=system.mdw;";

        // Try to remove an existing item.
        TryRemove(builder, "Provider");

        // Try to remove a nonexistent item.
        TryRemove(builder, "User ID");

        // Try to remove an existing item, 
        // demonstrating that the search isn't 
        // case sensitive.
        TryRemove(builder, "DATA SOURCE");
        Console.ReadLine();
    }

    static void TryRemove(DbConnectionStringBuilder builder, string itemToRemove)
    {
        if (builder.Remove(itemToRemove))
        {
            Console.WriteLine(@"Removed '{0}'", itemToRemove);
        }
        else
        {
            Console.WriteLine(@"Unable to remove '{0}'", itemToRemove);
        }
        Console.WriteLine(builder.ConnectionString);
    }
    // </Snippet1>
}

