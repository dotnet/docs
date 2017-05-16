using System;
using System.Data;
using System.Data.SqlClient;

class Program1
{
    static void Main()
    {
        string s = GetConnectionString();

        ChangeSqlDatabase(s);
        Console.ReadLine();
    }

    // <Snippet1>
    private static void ChangeSqlDatabase(string connectionString)
    {
        // Assumes connectionString represents a valid connection string
        // to the AdventureWorks sample database.
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
            Console.WriteLine("Database: {0}", connection.Database);

            connection.ChangeDatabase("Northwind");
            Console.WriteLine("Database: {0}", connection.Database);
        }
    }
    // </Snippet1>

    static private string GetConnectionString()
    {
        // To avoid storing the connection string in your code, 
        // you can retrieve it from a configuration file, using the 
        // System.Configuration.ConfigurationSettings.AppSettings property 
        return "Data Source=(local);Initial Catalog=AdventureWorks;"
            + "Integrated Security=SSPI;";
    }

}

