using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace BackupSample
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
                    value TEXT
                );

                INSERT INTO data
                VALUES ('Hello, online backup!');
            ";
            createCommand.ExecuteNonQuery();

            #region snippet_Backup
            // Create a full backup of the database
            var backup = new SqliteConnection("Data Source=BackupSample.db");
            connection.BackupDatabase(backup);
            #endregion

            backup.Open();

            var selectCommand = backup.CreateCommand();
            selectCommand.CommandText =
            @"
                SELECT value
                FROM data
                LIMIT 1
            ";
            var value = (string?)selectCommand.ExecuteScalar();
            Console.WriteLine(value);

            // Clean up
            backup.Close();
            File.Delete("BackupSample.db");
        }
    }
}
