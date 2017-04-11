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
        builder["Data Source"] = "(local)";

        // Note that Item is the indexer, so 
        // you do not include it in the reference.
        builder["integrated security"] = true;
        builder["Initial Catalog"] = "AdventureWorks";

        // Overwrite the existing value for the Data Source key, 
        // because it already exists within the collection.
        builder["Data Source"] = ".";

        Console.WriteLine(builder.ConnectionString);
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
    // </Snippet1>
}
