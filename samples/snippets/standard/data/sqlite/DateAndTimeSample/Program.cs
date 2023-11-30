using System;
using Microsoft.Data.Sqlite;

namespace DateAndTimeSample
{
    class Program
    {
        static void Main()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                CREATE TABLE task (
                    name TEXT NOT NULL,
                    started TEXT NOT NULL,
                    finished TEXT NULL
                );

                INSERT INTO task
                VALUES ('Learn SQLite', '2000-08-17 00:00:00', '2016-06-27 00:00:00'),
                       ('Learn .NET',   '2002-02-13 00:00:00', NULL);
            ";
            command.ExecuteNonQuery();

            // SQLite doesn't support primitive DateTime and TimeSpan values. Instead, it
            // provides date and time functions to help you perform operations based on strings
            // and Julian day values.

            // By default, Microsoft.Data.Sqlite uses strings, but it can also read DateTime
            // values from Julian day values
            command.CommandText =
            @"
                SELECT name, julianday(started) + 7.0 AS due
                FROM task
                WHERE finished IS NULL
            ";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var name = reader.GetString(0);
                    var due = reader.GetDateTime(1);

                    Console.WriteLine($"'{name}' is due on {due}.");
                }
            }

            // And it can read TimeSpan values from values in days
            #region snippet_AlternativeType
            command.CommandText =
            @"
                SELECT name, julianday(finished) - julianday(started) AS length
                FROM task
                WHERE finished IS NOT NULL
            ";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var name = reader.GetString(0);
                    var length = reader.GetTimeSpan(1);

                    Console.WriteLine($"'{name}' took {length}.");
                }
            }
            #endregion

            // To write values in days or as Julian day values, set SqliteType to Real
            var expected = TimeSpan.FromDays(7.0);
            #region snippet_SqliteType
            command.CommandText =
            @"
                SELECT count(*)
                FROM task
                WHERE finished IS NULL
                    AND julianday('now') - julianday(started) > $expected
            ";
            // Convert TimeSpan to days instead of text
            command.Parameters.AddWithValue("$expected", expected).SqliteType = SqliteType.Real;
            #endregion
            var oCount = command.ExecuteScalar();
            var count = (oCount is not null) ? (long)oCount : -1;
            Console.WriteLine($"{count} tasks are overdue.");
        }
    }
}
