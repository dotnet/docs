using System;
using System.Data;
using System.Data.OracleClient;

class Class1
{
    static void Main()
    {
    }

    // <Snippet1>
    public void CreateOracleCommand(string queryString, string connectionString)
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            OracleCommand command = new OracleCommand(queryString, connection);
            command.Connection.Open();
            command.ExecuteReader();
            command.Cancel();
        }
    }
    // </Snippet1>
}


