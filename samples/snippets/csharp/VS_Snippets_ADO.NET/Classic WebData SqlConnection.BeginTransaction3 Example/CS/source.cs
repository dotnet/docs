using System;
using System.Data;
using System.Data.SqlClient;


namespace Transaction1CS
{
    class Program
    {
        static void Main()
        {
            string connectionString =
                "Persist Security Info=False;Integrated Security=SSPI;database=Northwind;server=(local)";
            ExecuteSqlTransaction(connectionString);
            Console.ReadLine();
        }
        // <Snippet1>
        private static void ExecuteSqlTransaction(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction(
                    IsolationLevel.ReadCommitted, "SampleTransaction");

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction.
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText =
                        "Insert into Region (RegionID, RegionDescription) VALUES (100, 'Description')";
                    command.ExecuteNonQuery();
                    command.CommandText =
                        "Insert into Region (RegionID, RegionDescription) VALUES (101, 'Description')";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Both records are written to database.");
                }
                catch (Exception e)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (SqlException ex)
                    {
                        if (transaction.Connection != null)
                        {
                            Console.WriteLine("An exception of type " + ex.GetType() +
                                " was encountered while attempting to roll back the transaction.");
                        }
                    }

                    Console.WriteLine("An exception of type " + e.GetType() +
                        " was encountered while inserting the data.");
                    Console.WriteLine("Neither record was written to database.");
                }
            }
        }
        // </Snippet1>
    }
}
