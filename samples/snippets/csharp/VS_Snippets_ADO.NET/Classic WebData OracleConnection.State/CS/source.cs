using System;
using System.Data;
using System.Data.OracleClient;

class Class1
{
    static void Main()
    {
    }

    // <Snippet1>
    public void createOracleConnection()
    {
        using (OracleConnection connection = new OracleConnection())
        {
            connection.ConnectionString = "Data Source=Oracle8i;Integrated Security=yes";
            connection.Open();
            Console.WriteLine("Connection State: " + connection.State);
        }
    }
    // </Snippet1>
}


