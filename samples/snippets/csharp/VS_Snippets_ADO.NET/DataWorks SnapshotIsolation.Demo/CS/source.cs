using System;
using System.Data;
using System.Data.SqlClient;

static class Program
{
    static void Main()
    {
        // <Snippet1>
        // Assumes GetConnectionString returns a valid connection string
        // where pooling is turned off by setting Pooling=False;.
        var connectionString = GetConnectionString();
        using (SqlConnection connection1 = new(connectionString))
        {
            // Drop the TestSnapshot table if it exists
            connection1.Open();
            SqlCommand command1 = connection1.CreateCommand();
            command1.CommandText = "IF EXISTS "
                + "(SELECT * FROM sys.tables WHERE name=N'TestSnapshot') "
                + "DROP TABLE TestSnapshot";
            try
            {
                command1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Enable Snapshot isolation
            command1.CommandText =
                "ALTER DATABASE AdventureWorks SET ALLOW_SNAPSHOT_ISOLATION ON";
            command1.ExecuteNonQuery();

            // Create a table named TestSnapshot and insert one row of data
            command1.CommandText =
                "CREATE TABLE TestSnapshot (ID int primary key, valueCol int)";
            command1.ExecuteNonQuery();
            command1.CommandText =
                "INSERT INTO TestSnapshot VALUES (1,1)";
            command1.ExecuteNonQuery();

            // Begin, but do not complete, a transaction to update the data
            // with the Serializable isolation level, which locks the table
            // pending the commit or rollback of the update. The original
            // value in valueCol was 1, the proposed new value is 22.
            SqlTransaction transaction1 =
                connection1.BeginTransaction(IsolationLevel.Serializable);
            command1.Transaction = transaction1;
            command1.CommandText =
                "UPDATE TestSnapshot SET valueCol=22 WHERE ID=1";
            command1.ExecuteNonQuery();

            // Open a second connection to AdventureWorks
            using (SqlConnection connection2 = new(connectionString))
            {
                connection2.Open();
                // Initiate a second transaction to read from TestSnapshot
                // using Snapshot isolation. This will read the original
                // value of 1 since transaction1 has not yet committed.
                SqlCommand command2 = connection2.CreateCommand();
                SqlTransaction transaction2 =
                    connection2.BeginTransaction(IsolationLevel.Snapshot);
                command2.Transaction = transaction2;
                command2.CommandText =
                    "SELECT ID, valueCol FROM TestSnapshot";
                SqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    Console.WriteLine("Expected 1,1 Actual "
                        + reader2.GetValue(0)
                        + "," + reader2.GetValue(1));
                }
                transaction2.Commit();
            }

            // Open a third connection to AdventureWorks and
            // initiate a third transaction to read from TestSnapshot
            // using ReadCommitted isolation level. This transaction
            // will not be able to view the data because of
            // the locks placed on the table in transaction1
            // and will time out after 4 seconds.
            // You would see the same behavior with the
            // RepeatableRead or Serializable isolation levels.
            using (SqlConnection connection3 = new(connectionString))
            {
                connection3.Open();
                SqlCommand command3 = connection3.CreateCommand();
                SqlTransaction transaction3 =
                    connection3.BeginTransaction(IsolationLevel.ReadCommitted);
                command3.Transaction = transaction3;
                command3.CommandText =
                    "SELECT ID, valueCol FROM TestSnapshot";
                command3.CommandTimeout = 4;
                try
                {
                    SqlDataReader sqldatareader3 = command3.ExecuteReader();
                    while (sqldatareader3.Read())
                    {
                        Console.WriteLine("You should never hit this.");
                    }
                    transaction3.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Expected timeout expired exception: "
                        + ex.Message);
                    transaction3.Rollback();
                }
            }

            // Open a fourth connection to AdventureWorks and
            // initiate a fourth transaction to read from TestSnapshot
            // using the ReadUncommitted isolation level. ReadUncommitted
            // will not hit the table lock, and will allow a dirty read
            // of the proposed new value 22 for valueCol. If the first
            // transaction rolls back, this value will never actually have
            // existed in the database.
            using (SqlConnection connection4 = new(connectionString))
            {
                connection4.Open();
                SqlCommand command4 = connection4.CreateCommand();
                SqlTransaction transaction4 =
                    connection4.BeginTransaction(IsolationLevel.ReadUncommitted);
                command4.Transaction = transaction4;
                command4.CommandText =
                    "SELECT ID, valueCol FROM TestSnapshot";
                SqlDataReader reader4 = command4.ExecuteReader();
                while (reader4.Read())
                {
                    Console.WriteLine("Expected 1,22 Actual "
                        + reader4.GetValue(0)
                        + "," + reader4.GetValue(1));
                }

                transaction4.Commit();
            }

            // Roll back the first transaction
            transaction1.Rollback();
        }

        // CLEANUP
        // Delete the TestSnapshot table and set
        // ALLOW_SNAPSHOT_ISOLATION OFF
        using (SqlConnection connection5 = new(connectionString))
        {
            connection5.Open();
            SqlCommand command5 = connection5.CreateCommand();
            command5.CommandText = "DROP TABLE TestSnapshot";
            SqlCommand command6 = connection5.CreateCommand();
            command6.CommandText =
                "ALTER DATABASE AdventureWorks SET ALLOW_SNAPSHOT_ISOLATION OFF";
            try
            {
                command5.ExecuteNonQuery();
                command6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine("Done!");
        // </Snippet1>
    }

    static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file, using the
        // System.Configuration.ConfigurationSettings.AppSettings property
        return "Data Source=localhost;Initial Catalog=AdventureWorks;"
            + "Integrated Security=SSPI";
    }
}
