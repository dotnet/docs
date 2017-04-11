using System;
using System.Data;
using System.Data.OleDb;

class Class1
{
    static void Main()
    {
    }

    // <Snippet1>
    public void ExecuteTransaction(string connectionString)
    {
        using (OleDbConnection connection =
                   new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand();
            OleDbTransaction transaction = null;

            // Set the Connection to the new OleDbConnection.
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
    }
    // </Snippet1>
}