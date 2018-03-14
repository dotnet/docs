using System;
using System.Data;
using System.Data.OracleClient;

class Class1
{
    static void Main()
    {
    }

    // <Snippet1>
    public void InsertRow(string connectionString)
    {
        string queryString = 
            "INSERT INTO Dept (DeptNo, Dname, Loc) values (50, 'TECHNOLOGY', 'DENVER')";
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            OracleCommand command = new OracleCommand(queryString);
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    // </Snippet1>
}

