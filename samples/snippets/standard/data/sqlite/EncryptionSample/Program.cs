using System;
using System.IO;
using Microsoft.Data.Sqlite;

using static SQLitePCL.raw;

namespace EncryptionSample
{
    class Program
    {
        static void Main()
        {
            const string baseConnectionString = "Data Source=EncryptionSample.db";
            var password = "...";

            // Notice which packages are referenced by this project:
            // - Microsoft.Data.Sqlite.Core
            // - SQLitePCLRaw.bundle_sqlcipher

            // The Password keyword in the connection string specifies the encryption key.
            #region snippet_ConnectionStringBuilder
            var connectionString = new SqliteConnectionStringBuilder(baseConnectionString)
            {
                Mode = SqliteOpenMode.ReadWriteCreate,
                Password = password
            }.ToString();
            #endregion

            using (var connection = new SqliteConnection(connectionString))
            {
                // When a new database is created, it will be encrypted using the key.
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    CREATE TABLE data (
                        value TEXT
                    );

                    INSERT INTO data
                    VALUES ('Hello, encryption!');
                ";
                command.ExecuteNonQuery();
            }

            Console.Write("Password (it's 'password'): ");
            password = Console.ReadLine();

            connectionString = new SqliteConnectionStringBuilder(baseConnectionString)
            {
                Mode = SqliteOpenMode.ReadWrite,
                Password = password
            }.ToString();

            using (var connection = new SqliteConnection(connectionString))
            {
                try
                {
                    // If the key is incorrect, this will throw
                    connection.Open();
                }
                catch (SqliteException ex) when (ex.SqliteErrorCode == SQLITE_NOTADB)
                {
                    Console.WriteLine("Access denied.");
                    goto Cleanup;
                }

                var queryCommand = connection.CreateCommand();
                queryCommand.CommandText =
                @"
                    SELECT value
                    FROM data
                    LIMIT 1
                ";
                var value = (string)queryCommand.ExecuteScalar();
                Console.WriteLine(value);

                Console.Write("New password: ");
                var newPassword = Console.ReadLine();

                // Send PRAGMA rekey to change the encryption key. Unfortunately, you can't use
                // parameters with PRAGMA statements, so you have to resort to the quote() SQL
                // function to protect against injection attacks
                #region snippet_Rekey
                var command = connection.CreateCommand();
                command.CommandText = "SELECT quote($newPassword);";
                command.Parameters.AddWithValue("$newPassword", newPassword);
                var quotedNewPassword = (string)command.ExecuteScalar();

                command.CommandText = "PRAGMA rekey = " + quotedNewPassword;
                command.Parameters.Clear();
                command.ExecuteNonQuery();
                #endregion
            }

            Cleanup:
            File.Delete("EncryptionSample.db");
        }
    }
}
