using System;
using System.Data;
using System.Data.OracleClient;

class Class1
{
    static void Main()
    {
    }

    // <Snippet1>
    private static void ReadData(string connectionString)
    {
        string queryString = "SELECT OrderID, CustomerID FROM Orders";
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            OracleCommand command = new OracleCommand(queryString, connection);
            connection.Open();
            OracleDataReader reader;
            reader = command.ExecuteReader();

            // Always call Read before accessing data.
            while (reader.Read())
            {
                Console.WriteLine(reader.GetInt32(0) + ", " + reader.GetString(1));
            }

            // Always call Close when done reading.
            reader.Close();
        }
    }
    // </Snippet1>
}


