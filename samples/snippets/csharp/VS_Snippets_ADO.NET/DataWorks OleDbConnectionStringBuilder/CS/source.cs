using System;
using System.Data;
// <Snippet1>
using System.Data.OleDb;

class Program
{
    static void Main(string[] args)
    {
        OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder();
        builder.ConnectionString = @"Data Source=C:\Sample.mdb";

        // Call the Add method to explicitly add key/value
        // pairs to the internal collection.
        builder.Add("Provider", "Microsoft.Jet.Oledb.4.0");
        builder.Add("Jet OLEDB:Database Password", "MyPassword!");
        builder.Add("Jet OLEDB:System Database", @"C:\Workgroup.mdb");

        // Set up row-level locking.
        builder.Add("Jet OLEDB:Database Locking Mode", 1);

        Console.WriteLine(builder.ConnectionString);
        Console.WriteLine();

        // Clear current values and reset known keys to their
        // default values.
        builder.Clear();

        // Pass the OleDbConnectionStringBuilder an existing 
        // connection string, and you can retrieve and
        // modify any of the elements.
        builder.ConnectionString =
            "Provider=DB2OLEDB;Network Transport Library=TCPIP;" +
            "Network Address=192.168.0.12;Initial Catalog=DbAdventures;" +
            "Package Collection=SamplePackage;Default Schema=SampleSchema;";

        Console.WriteLine("Network Address = " + builder["Network Address"].ToString());
        Console.WriteLine();

        // Modify existing items.
        builder["Package Collection"] = "NewPackage";
        builder["Default Schema"] = "NewSchema";

        // Call the Remove method to remove items from 
        // the collection of key/value pairs.
        builder.Remove("User ID");

        // Note that calling Remove on a nonexistent item does not
        // throw an exception.
        builder.Remove("BadItem");
        Console.WriteLine(builder.ConnectionString);
        Console.WriteLine();

        // Setting the indexer adds the value, if 
        // necessary.
        builder["User ID"] = "SampleUser";
        builder["Password"] = "SamplePassword";
        Console.WriteLine(builder.ConnectionString);

        Console.WriteLine("Press Enter to finish.");
        Console.ReadLine();
    }
}
// </Snippet1>

