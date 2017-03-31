using System;
using System.Data;
using System.Data.OleDb;

class Class1
{
    static void Main()
    {
    }

    // <Snippet1>
    public void ReadMyData(string connectionString)
    {
        string queryString = "SELECT OrderID, CustomerID FROM Orders";
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader.GetInt32(0) + ", " + reader.GetString(1));
            }
            // always call Close when done reading.
            reader.Close();
        }
    }
    // </Snippet1>
}

