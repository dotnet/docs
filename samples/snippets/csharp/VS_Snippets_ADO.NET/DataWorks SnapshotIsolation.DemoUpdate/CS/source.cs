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
            connection1.Open();
            SqlCommand command1 = connection1.CreateCommand();

            // Enable Snapshot isolation in AdventureWorks
            command1.CommandText =
                "ALTER DATABASE AdventureWorks SET ALLOW_SNAPSHOT_ISOLATION ON";
            try
            {
                command1.ExecuteNonQuery();
                Console.WriteLine(
                    "Snapshot Isolation turned on in AdventureWorks.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ALLOW_SNAPSHOT_ISOLATION ON failed: {ex.Message}");
            }
            // Create a table
            command1.CommandText =
                "IF EXISTS "
                + "(SELECT * FROM sys.tables "
                + "WHERE name=N'TestSnapshotUpdate')"
                + " DROP TABLE TestSnapshotUpdate";
            command1.ExecuteNonQuery();
            command1.CommandText =
                "CREATE TABLE TestSnapshotUpdate "
                + "(ID int primary key, CharCol nvarchar(100));";
            try
            {
                command1.ExecuteNonQuery();
                Console.WriteLine("TestSnapshotUpdate table created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CREATE TABLE failed: {ex.Message}");
            }
            // Insert some data
            command1.CommandText =
                "INSERT INTO TestSnapshotUpdate VALUES (1,N'abcdefg');"
                + "INSERT INTO TestSnapshotUpdate VALUES (2,N'hijklmn');"
                + "INSERT INTO TestSnapshotUpdate VALUES (3,N'opqrstuv');";
            try
            {
                command1.ExecuteNonQuery();
                Console.WriteLine("Data inserted TestSnapshotUpdate table.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Begin, but do not complete, a transaction
            // using the Snapshot isolation level.
            SqlTransaction transaction1 = default!;
            try
            {
                transaction1 = connection1.BeginTransaction(IsolationLevel.Snapshot);
                command1.CommandText =
                    "SELECT * FROM TestSnapshotUpdate WHERE ID BETWEEN 1 AND 3";
                command1.Transaction = transaction1;
                command1.ExecuteNonQuery();
                Console.WriteLine("Snapshot transaction1 started.");

                // Open a second Connection/Transaction to update data
                // using ReadCommitted. This transaction should succeed.
                using (SqlConnection connection2 = new(connectionString))
                {
                    connection2.Open();
                    SqlCommand command2 = connection2.CreateCommand();
                    command2.CommandText = "UPDATE TestSnapshotUpdate SET CharCol="
                        + "N'New value from Connection2' WHERE ID=1";
                    SqlTransaction transaction2 =
                        connection2.BeginTransaction(IsolationLevel.ReadCommitted);
                    command2.Transaction = transaction2;
                    try
                    {
                        command2.ExecuteNonQuery();
                        transaction2.Commit();
                        Console.WriteLine(
                            "transaction2 has modified data and committed.");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction2.Rollback();
                    }
                    finally
                    {
                        transaction2.Dispose();
                    }
                }

                // Now try to update a row in Connection1/Transaction1.
                // This transaction should fail because Transaction2
                // succeeded in modifying the data.
                command1.CommandText =
                    "UPDATE TestSnapshotUpdate SET CharCol="
                    + "N'New value from Connection1' WHERE ID=1";
                command1.Transaction = transaction1;
                command1.ExecuteNonQuery();
                transaction1.Commit();
                Console.WriteLine("You should never see this.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Expected failure for transaction1:");
                Console.WriteLine($"  {ex.Number}: {ex.Message}");
            }
            finally
            {
                transaction1.Dispose();
            }
        }

        // CLEANUP:
        // Turn off Snapshot isolation and delete the table
        using (SqlConnection connection3 = new(connectionString))
        {
            connection3.Open();
            SqlCommand command3 = connection3.CreateCommand();
            command3.CommandText =
                "ALTER DATABASE AdventureWorks SET ALLOW_SNAPSHOT_ISOLATION OFF";
            try
            {
                command3.ExecuteNonQuery();
                Console.WriteLine(
                    "CLEANUP: Snapshot isolation turned off in AdventureWorks.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CLEANUP FAILED: {ex.Message}");
            }
            command3.CommandText = "DROP TABLE TestSnapshotUpdate";
            try
            {
                command3.ExecuteNonQuery();
                Console.WriteLine("CLEANUP: TestSnapshotUpdate table deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CLEANUP FAILED: {ex.Message}");
            }
        }
        // </Snippet1>
        Console.WriteLine("Done");
        Console.ReadLine();
    }

    static string GetConnectionString() =>
        throw new NotImplementedException();
}
