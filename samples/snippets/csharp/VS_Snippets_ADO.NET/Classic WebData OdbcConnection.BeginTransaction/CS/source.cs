using System;
using System.Data;
using System.Data.Odbc;

class Program
{
    static void Main()
    {
        string connectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\\Samples\\Northwind.mdb";
        ExecuteTransaction(connectionString);

    }
    // <Snippet1>
    public static void ExecuteTransaction(string connectionString)
    {
        using (OdbcConnection connection =
                   new OdbcConnection(connectionString))
        {
            OdbcCommand command = new OdbcCommand();
            OdbcTransaction transaction = null;

            // Set the Connection to the new OdbcConnection.
            command.Connection = connection;

            // Open the connection and execute the transaction.
            try
            {
                connection.Open();

                // Start a local transaction
                transaction = connection.BeginTransaction();

                // Assign transaction object for a pending local transaction.
                command.Connection = connection;
                command.Transaction = transaction;

                // Execute the commands.
                command.CommandText =
                    "Insert into Region (RegionID, RegionDescription) VALUES (100, 'Description')";
                command.ExecuteNonQuery();
                command.CommandText =
                    "Insert into Region (RegionID, RegionDescription) VALUES (101, 'Description')";
                command.ExecuteNonQuery();

                // Commit the transaction.
                transaction.Commit();
                Console.WriteLine("Both records are written to database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    // Attempt to roll back the transaction.
                    transaction.Rollback();
                }
                catch
                {
                    // Do nothing here; transaction is not active.
                }
            }
            // The connection is automatically closed when the
            // code exits the using block.
        }
        // </Snippet1>
    }
}
