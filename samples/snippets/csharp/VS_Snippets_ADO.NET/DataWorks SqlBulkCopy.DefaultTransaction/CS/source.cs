﻿using System;
using System.Data;
// <Snippet1>
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = GetConnectionString();
        // Open a sourceConnection to the AdventureWorks database.
        using (SqlConnection sourceConnection =
                   new SqlConnection(connectionString))
        {
            sourceConnection.Open();

            //  Delete all from the destination table.
            SqlCommand commandDelete = new SqlCommand();
            commandDelete.Connection = sourceConnection;
            commandDelete.CommandText =
                "DELETE FROM dbo.BulkCopyDemoMatchingColumns";
            commandDelete.ExecuteNonQuery();

            //  Add a single row that will result in duplicate key
            //  when all rows from source are bulk copied.
            //  Note that this technique will only be successful in
            //  illustrating the point if a row with ProductID = 446
            //  exists in the AdventureWorks Production.Products table.
            //  If you have made changes to the data in this table, change
            //  the SQL statement in the code to add a ProductID that
            //  does exist in your version of the Production.Products
            //  table. Choose any ProductID in the middle of the table
            //  (not first or last row) to best illustrate the result.
            SqlCommand commandInsert = new SqlCommand();
            commandInsert.Connection = sourceConnection;
            commandInsert.CommandText =
                "SET IDENTITY_INSERT dbo.BulkCopyDemoMatchingColumns ON;" +
                "INSERT INTO " + "dbo.BulkCopyDemoMatchingColumns " +
                "([ProductID], [Name] ,[ProductNumber]) " +
                "VALUES(446, 'Lock Nut 23','LN-3416');" +
                "SET IDENTITY_INSERT dbo.BulkCopyDemoMatchingColumns OFF";
            commandInsert.ExecuteNonQuery();

            // Perform an initial count on the destination table.
            SqlCommand commandRowCount = new SqlCommand(
                "SELECT COUNT(*) FROM dbo.BulkCopyDemoMatchingColumns;",
                sourceConnection);
            long countStart = System.Convert.ToInt32(
                commandRowCount.ExecuteScalar());
            Console.WriteLine("Starting row count = {0}", countStart);

            //  Get data from the source table as a SqlDataReader.
            SqlCommand commandSourceData = new SqlCommand(
                "SELECT ProductID, Name, ProductNumber " +
                "FROM Production.Product;", sourceConnection);
            SqlDataReader reader = commandSourceData.ExecuteReader();

            // Set up the bulk copy object using the KeepIdentity option.
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(
                       connectionString, SqlBulkCopyOptions.KeepIdentity))
            {
                bulkCopy.BatchSize = 10;
                bulkCopy.DestinationTableName =
                    "dbo.BulkCopyDemoMatchingColumns";

                // Write from the source to the destination.
                // This should fail with a duplicate key error
                // after some of the batches have been copied.
                try
                {
                    bulkCopy.WriteToServer(reader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    reader.Close();
                }
            }

            // Perform a final count on the destination
            // table to see how many rows were added.
            long countEnd = System.Convert.ToInt32(
                commandRowCount.ExecuteScalar());
            Console.WriteLine("Ending row count = {0}", countEnd);
            Console.WriteLine("{0} rows were added.", countEnd - countStart);
            Console.WriteLine("Press Enter to finish.");
            Console.ReadLine();
        }
    }

    private static string GetConnectionString()
        // To avoid storing the sourceConnection string in your code,
        // you can retrieve it from a configuration file.
    {
        return "Data Source=(local); " +
            " Integrated Security=true;" +
            "Initial Catalog=AdventureWorks;";
    }
}
// </Snippet1>
