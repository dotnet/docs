using System;
using System.Data;
using System.Data.OracleClient;

class Class1
{
    static void Main()
    {
    }

    // <Snippet1>
    public void CreateOracleConnection()
    {
        string connectionString = "Data Source=Oracle8i;Integrated Security=yes";
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("ServerVersion: " + connection.ServerVersion
                + "\nDataSource: " + connection.DataSource);
        }
    }
    // </Snippet1>
}


