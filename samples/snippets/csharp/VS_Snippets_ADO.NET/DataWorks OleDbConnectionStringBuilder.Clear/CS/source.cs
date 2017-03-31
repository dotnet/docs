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
        builder.ConnectionString = @"Data Source=c:\Sample.mdb";

        // Call the Add method to explicitly add key/value
        // pairs to the internal collection.
        builder.Add("Provider", "Microsoft.Jet.Oledb.4.0");
        builder.Add("Jet OLEDB:Database Password", "MyPassword!");
        builder.Add("Jet OLEDB:System Database", @"C:\Workgroup.mdb");

        // set up row-level locking.
        builder.Add("Jet OLEDB:Database Locking Mode", 1);

        // Dump the contents of the "filled-in" 
        // OleDbConnectionStringBuilder
        // to the console window.
        DumpBuilderContents(builder);

        // Clear current values and reset known keys to their
        // default values.
        builder.Clear();

        // Dump the contents of the newly emptied 
        // OleDbConnectionStringBuilder
        // to the console window.
        DumpBuilderContents(builder);

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();

    }

    private static void DumpBuilderContents(OleDbConnectionStringBuilder builder)
    {
        Console.WriteLine("=================");
        Console.WriteLine("builder.ConnectionString = " + builder.ConnectionString);
        foreach (string key in builder.Keys)
        {
            Console.WriteLine(key + "=" + builder[key].ToString());
        }
    }
}
// </Snippet1>

