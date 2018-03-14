using System;
using System.Data;
using System.Data.OracleClient;

class Class1
{
    static void Main()
    {
    }

    // <Snippet1>
    public void CreateOracleCommand(string myExecuteQuery, string connectionString)
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            OracleCommand command = new OracleCommand(myExecuteQuery, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
    }
    // </Snippet1>

}


