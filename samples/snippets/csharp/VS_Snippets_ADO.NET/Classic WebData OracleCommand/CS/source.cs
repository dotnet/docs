
using System;
using System.Data;
using System.Data.OracleClient;

class Class1
{
    static void Main()
    {
    }

    // <Snippet1>
    public void ReadMyData(string connectionString)
    {
        string queryString = "SELECT EmpNo, DeptNo FROM Scott.Emp";
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            OracleCommand command = new OracleCommand(queryString, connection);
            connection.Open();
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0) + ", " + reader.GetInt32(1));
                }
            }
            finally
            {
                // always call Close when done reading.
                reader.Close();
            }
        }
    }
    // </Snippet1>

}


