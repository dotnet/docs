using System;
using System.Data;
using System.Data.Odbc;

class Program
{
    static void Main()
    {
        //string connectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\\Samples\\Northwind.mdb";
    }
    // <Snippet1>
    public void InsertRow(string connectionString, string insertSQL)
    {
        using (OdbcConnection connection = 
                   new OdbcConnection(connectionString))
        {
            // The insertSQL string contains a SQL statement that
            // inserts a new row in the source table.
            OdbcCommand command = new OdbcCommand(insertSQL, connection);

            // Open the connection and execute the insert command.
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // The connection is automatically closed when the
            // code exits the using block.
        }
        // </Snippet1>
    }
}
