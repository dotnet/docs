using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        OpenSqlConnection();
        Console.ReadLine();
    }

    // <Snippet1>
    private static void OpenSqlConnection()
    {
        string connectionString = GetConnectionString();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            Console.WriteLine("State: {0}", connection.State);
            Console.WriteLine("ConnectionString: {0}",
                connection.ConnectionString);
        }
    }

    static private string GetConnectionString()
    {
        // To avoid storing the connection string in your code, 
        // you can retrieve it from a configuration file, using the 
        // System.Configuration.ConfigurationSettings.AppSettings property 
        return "Data Source=(local);Initial Catalog=AdventureWorks;"
            + "Integrated Security=SSPI;";
    }
    // </Snippet1>

}

