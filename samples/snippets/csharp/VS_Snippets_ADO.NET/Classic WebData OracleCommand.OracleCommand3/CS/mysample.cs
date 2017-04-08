using System;
using System.Data;
using System.Data.OracleClient;

class Class1
{
    static void Main()
    {
    }

    // <Snippet1>
    public void CreateOracleCommand(string connectionString)
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            connection.Open();
            OracleTransaction transaction = connection.BeginTransaction();
            string queryString = "SELECT * FROM Emp ORDER BY EmpNo";
            OracleCommand command = new OracleCommand(queryString, connection, transaction);
            command.CommandType = CommandType.Text;
        }
    }
    // </Snippet1>
}


