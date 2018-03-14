using System;
using System.Data;
// <Snippet1>
using System.Data.OleDb;

class Program
{
    static void Main()
    {
        OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder();
        builder.Provider = "Microsoft.Jet.Oledb.4.0";
        builder.DataSource = @"C:\Sample.mdb";
        // Set properties using the Item property (the indexer, in C#).
        builder["Jet OLEDB:Database Password"] = "DataPassword";
        builder["Jet OLEDB:Encrypt Database"] = true;
        builder["Jet OLEDB:System database"] = @"C:\Workgroup.mdw";

        Console.WriteLine(builder.ConnectionString);
        Console.WriteLine();

        // Use the Item property to retrieve values as well.
        Console.WriteLine(builder["Jet OLEDB:System database"]);
        Console.WriteLine(builder["Jet OLEDB:Encrypt Database"]);

        // You can set or retrieve any of the "default" values for the 
        // provider, even if you didn't set their values.
        Console.WriteLine(builder["Jet OLEDB:Database Locking Mode"]);
        Console.WriteLine(builder["Jet OLEDB:Global Partial Bulk Ops"]);

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();

    }
}
// </Snippet1>

