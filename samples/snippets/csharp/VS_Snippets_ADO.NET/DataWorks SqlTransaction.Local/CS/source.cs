using System;
using System.Data.SqlClient;

namespace SqlPrepareCS;

static class Program
{
    static void Main()
    {
        const string connectionString =
            "Persist Security Info=False;Integrated Security=true;database=Northwind;server=(local)";
        LocalTrans(connectionString);
        Console.ReadLine();
    }
    static void LocalTrans(string connectionString)
    {
        // <Snippet1>
        using (SqlConnection connection = new(connectionString))
        {
            connection.Open();

            // Start a local transaction.
            SqlTransaction sqlTran = connection.BeginTransaction();

            // Enlist a command in the current transaction.
            SqlCommand command = connection.CreateCommand();
            command.Transaction = sqlTran;

            try
            {
                // Execute two separate commands.
                command.CommandText =
                  "INSERT INTO Production.ScrapReason(Name) VALUES('Wrong size')";
                command.ExecuteNonQuery();
                command.CommandText =
                  "INSERT INTO Production.ScrapReason(Name) VALUES('Wrong color')";
                command.ExecuteNonQuery();

                // Commit the transaction.
                sqlTran.Commit();
                Console.WriteLine("Both records were written to database.");
            }
            catch (Exception ex)
            {
                // Handle the exception if the transaction fails to commit.
                Console.WriteLine(ex.Message);

                try
                {
                    // Attempt to roll back the transaction.
                    sqlTran.Rollback();
                }
                catch (Exception exRollback)
                {
                    // Throws an InvalidOperationException if the connection
                    // is closed or the transaction has already been rolled
                    // back on the server.
                    Console.WriteLine(exRollback.Message);
                }
            }
        }
        // </Snippet1>
    }
}
