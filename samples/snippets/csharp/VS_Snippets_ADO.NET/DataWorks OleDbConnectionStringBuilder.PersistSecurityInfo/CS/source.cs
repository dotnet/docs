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
        builder.PersistSecurityInfo = true;
        builder.Provider = "Microsoft.Jet.Oledb.4.0";
        builder.DataSource = @"C:\Sample.mdb";

        // Store the connection string.
        string savedConnectionString = builder.ConnectionString;
        Console.WriteLine(savedConnectionString);

        // Reset the object. This resets all the properties to their
        // default values.
        builder.Clear();

        // Investigate the PersistSecurityInfo property before
        // and after assigning a connection string value.
        Console.WriteLine("Default : " + builder.PersistSecurityInfo);
        builder.ConnectionString = savedConnectionString;
        Console.WriteLine("Modified: " + builder.PersistSecurityInfo);

        Console.WriteLine("Press Enter to finish.");
        Console.ReadLine();
    }
}
// </Snippet1>

