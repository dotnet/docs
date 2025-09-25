using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace HelloWorldSample
{
    class Program
    {
        static void Main()
        {
            CreateAndSeed();
            Query();

            // Clean up
            SqliteConnection.ClearAllPools();
            File.Delete("hello.db");
        }

        static void CreateAndSeed()
        {
            using var connection = new SqliteConnection("Data Source=hello.db");

            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = """
                CREATE TABLE user (
                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL
                );

                INSERT INTO user
                VALUES (1, 'Brice'),
                       (2, 'Alexander'),
                       (3, 'Nate');
            """;
            command.ExecuteNonQuery();

            Console.Write("Name: ");
            var name = Console.ReadLine();

            #region snippet_Parameter
            command.CommandText = "INSERT INTO user (name) VALUES ($name)";
            command.Parameters.AddWithValue("$name", name);
            #endregion
            command.ExecuteNonQuery();

            command.CommandText = "SELECT last_insert_rowid()";
            var newId = (long)command.ExecuteScalar()!;

            Console.WriteLine($"Your new user ID is {newId}.");
        }

        static void Query()
        {
            Console.Write("User ID: ");
            var line = Console.ReadLine();
            if (line is null)
            {
                return;
            }

            var id = int.Parse(line);

            #region snippet_HelloWorld
            using var connection = new SqliteConnection("Data Source=hello.db");

            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = """
                SELECT name
                FROM user
                WHERE id = $id
            """;
            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var name = reader.GetString(0);

                Console.WriteLine($"Hello, {name}!");
            }
            #endregion
        }
    }
}
