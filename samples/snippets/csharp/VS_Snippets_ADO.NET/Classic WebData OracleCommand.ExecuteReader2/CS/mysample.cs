using System;
using System.Data;
using System.Data.OracleClient;

class Class1
{
    static void Main()
    {
    }

    // <Snippet1>
    public void CreateMyOracleDataReader(string queryString, string connectionString)
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            OracleCommand command = new OracleCommand(queryString, connection);
            connection.Open();

            // Implicitly closes the connection because 
            // CommandBehavior.CloseConnection is specified.
            OracleDataReader reader = 
                command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Console.WriteLine(reader.GetValue(0));
            }
            reader.Close();
        }
    }
    // </Snippet1>


}


