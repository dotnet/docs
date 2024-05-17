using Microsoft.Data.Sqlite;

namespace SavepointSample
{
    internal class Program
    {
        static void Main()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            // This sample uses Optimistic Offline Lock to detect concurrent updates and resolve conflicts within a
            // savepoint as part of a larger transaction

            var createCommand = connection.CreateCommand();
            createCommand.CommandText =
            @"
                CREATE TABLE audit (
                    time TEXT,
                    message Text
                );

                CREATE TABLE data (
                    id INTEGER PRIMARY KEY
                    value INTEGER,
                    version INTEGER
                );

                INSERT INTO data
                VALUES (1, 1, 1);
            ";
            createCommand.ExecuteNonQuery();

            var expectedVersion = 1L;

            #region snippet_Savepoint
            using (var transaction = connection.BeginTransaction())
            {
                // Transaction may include additional statements before the savepoint

                var updated = false;
                do
                {
                    // Begin savepoint
                    transaction.Save("optimistic-update");

                    var insertCommand = connection.CreateCommand();
                    insertCommand.CommandText =
                    @"
                        INSERT INTO audit
                        VALUES (datetime('now'), 'User updates data with id 1')
                    ";
                    insertCommand.ExecuteScalar();

                    var updateCommand = connection.CreateCommand();
                    updateCommand.CommandText =
                    @"
                        UPDATE data
                        SET value = 2,
                            version = $expectedVersion + 1
                        WHERE id = 1
                            AND version = $expectedVersion
                    ";
                    updateCommand.Parameters.AddWithValue("$expectedVersion", expectedVersion);
                    var recordsAffected = updateCommand.ExecuteNonQuery();
                    if (recordsAffected == 0)
                    {
                        // Concurrent update detected! Rollback savepoint and retry
                        transaction.Rollback("optimistic-update");

                        // TODO: Resolve update conflicts
                    }
                    else
                    {
                        // Update succeeded. Commit savepoint and continue with the transaction
                        transaction.Release("optimistic-update");

                        updated = true;
                    }
                }
                while (!updated);

                // Additional statements may be included after the savepoint

                transaction.Commit();
            }
            #endregion
        }
    }
}
