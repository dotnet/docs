using System;
using System.Data;
using System.Data.OleDb;

namespace OleDbCommandPrepareCS
{
    class Program
    {
        static void Main()
        {
            string connectionString = "Provider=sqloledb;Data Source=(local);Initial Catalog=Northwind;"
                + "Integrated Security=SSPI";
            OleDbCommandPrepare(connectionString);
            Console.ReadLine();
        }

        // <Snippet1>
        private static void OleDbCommandPrepare(string connectionString)
        {
            using (OleDbConnection connection = new
                       OleDbConnection(connectionString))
            {
                connection.Open();

                // Create the Command.
                OleDbCommand command = new OleDbCommand();

                // Set the Connection, CommandText and Parameters.
                command.Connection = connection;
                command.CommandText =
                    "INSERT INTO dbo.Region (RegionID, RegionDescription) VALUES (?, ?)";
                command.Parameters.Add("RegionID", OleDbType.Integer, 4);
                command.Parameters.Add("RegionDescription", OleDbType.VarWChar, 50);
                command.Parameters[0].Value = 20;
                command.Parameters[1].Value = "First Region";

                // Call  Prepare and ExecuteNonQuery.
                command.Prepare();
                command.ExecuteNonQuery();

                // Change parameter values and call ExecuteNonQuery.
                command.Parameters[0].Value = 21;
                command.Parameters[1].Value = "SecondRegion";
                command.ExecuteNonQuery();
            }
        }
        // </Snippet1>

    }
}
