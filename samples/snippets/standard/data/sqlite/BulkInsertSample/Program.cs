using System;
using System.Diagnostics;
using Microsoft.Data.Sqlite;

namespace BulkInsertSample
{
    class Program
    {
        static void Main()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var createCommand = connection.CreateCommand();
            createCommand.CommandText =
            @"
                CREATE TABLE data (
                    value INTEGER
                )
            ";
            createCommand.ExecuteNonQuery();

            Console.WriteLine("Inserting 150,000 rows...");
            var stopwatch = Stopwatch.StartNew();

            // There is no special API for inserting data in bulk. For the best performance,
            // follow this pattern of using a transaction and re-using the same parameterized
            // command.
            #region snippet_BulkInsert
            using (var transaction = connection.BeginTransaction())
            {
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO data
                    VALUES ($value)
                ";

                var parameter = command.CreateParameter();
                parameter.ParameterName = "$value";
                command.Parameters.Add(parameter);

                // Insert a lot of data
                var random = new Random();
                for (var i = 0; i < 150_000; i++)
                {
                    parameter.Value = random.Next();
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            #endregion

            Console.WriteLine($"Done. (took {stopwatch.ElapsedMilliseconds} ms)");
        }
    }
}
