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
        builder.DataSource = @"C:\Sample.mdb";
        builder.Provider = "Microsoft.Jet.Oledb.4.0";
        Console.WriteLine(builder.ConnectionString);

        // This sample assumes that you have a database named
        // C:\Sample.mdb available.
        using (OleDbConnection connection = new
                   OleDbConnection(builder.ConnectionString))
        {
            try
            {
                connection.Open();
                // Do something with the database here.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine("Press Enter to finish.");
        Console.ReadLine();
    }
}
// </Snippet1>

