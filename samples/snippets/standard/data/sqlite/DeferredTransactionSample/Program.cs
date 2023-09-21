using System.IO;
using Microsoft.Data.Sqlite;

namespace DeferredTransactionSample
{
    class Program
    {
        static void Main()
        {
            var connection = new SqliteConnection("Data Source=DeferredTransactionSample.db");
            connection.Open();

            var createCommand = connection.CreateCommand();
            createCommand.CommandText =
            @"
                CREATE TABLE data (
                    value INTEGER
                );

                INSERT INTO data
                VALUES (1);
            ";
            createCommand.ExecuteNonQuery();

            #region snippet_DeferredTransaction
            using (var transaction = connection.BeginTransaction(deferred: true))
            {
                // Before the first statement of the transaction is executed, both concurrent
                // reads and writes are allowed

                var readCommand = connection.CreateCommand();
                readCommand.CommandText =
                @"
                    SELECT *
                    FROM data
                ";
                var value = (long)readCommand.ExecuteScalar();

                // After a the first read statement, concurrent writes are blocked until the
                // transaction completes. Concurrent reads are still allowed

                var writeCommand = connection.CreateCommand();
                writeCommand.CommandText =
                @"
                    UPDATE data
                    SET value = $newValue
                ";
                writeCommand.Parameters.AddWithValue("$newValue", value + 1L);
                writeCommand.ExecuteNonQuery();

                // After the first write statement, both concurrent reads and writes are blocked
                // until the transaction completes

                transaction.Commit();
            }
            #endregion

            // Clean up
            connection.Close();
            File.Delete("DeferredTransactionSample.db");
        }
    }
}
