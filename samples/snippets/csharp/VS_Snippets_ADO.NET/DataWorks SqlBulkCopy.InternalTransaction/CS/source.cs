﻿using System;
using System.Data.SqlClient;

static class Program
{
    static void Main()
    {
        // <Snippet1>
        var connectionString = GetConnectionString();
        // Open a sourceConnection to the AdventureWorks database.
        using (SqlConnection sourceConnection =
                   new(connectionString))
        {
            sourceConnection.Open();

            //  Delete all from the destination table.
            SqlCommand commandDelete = new()
            {
                Connection = sourceConnection,
                CommandText =
                "DELETE FROM dbo.BulkCopyDemoMatchingColumns"
            };
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
            SqlCommand commandInsert = new()
            {
                Connection = sourceConnection,
                CommandText =
                "SET IDENTITY_INSERT dbo.BulkCopyDemoMatchingColumns ON;" +
                "INSERT INTO " + "dbo.BulkCopyDemoMatchingColumns " +
                "([ProductID], [Name] ,[ProductNumber]) " +
                "VALUES(446, 'Lock Nut 23','LN-3416');" +
                "SET IDENTITY_INSERT dbo.BulkCopyDemoMatchingColumns OFF"
            };
            commandInsert.ExecuteNonQuery();

            // Perform an initial count on the destination table.
            SqlCommand commandRowCount = new(
                "SELECT COUNT(*) FROM dbo.BulkCopyDemoMatchingColumns;",
                sourceConnection);
            long countStart = Convert.ToInt32(
                commandRowCount.ExecuteScalar());
            Console.WriteLine("Starting row count = {0}", countStart);

            //  Get data from the source table as a SqlDataReader.
            SqlCommand commandSourceData = new(
                "SELECT ProductID, Name, ProductNumber " +
                "FROM Production.Product;", sourceConnection);
            SqlDataReader reader = commandSourceData.ExecuteReader();

            // Set up the bulk copy object.
            // Note that when specifying the UseInternalTransaction
            // option, you cannot also specify an external transaction.
            // Therefore, you must use the SqlBulkCopy construct that
            // requires a string for the connection, rather than an
            // existing SqlConnection object.
            using (SqlBulkCopy bulkCopy = new(
                       connectionString, SqlBulkCopyOptions.KeepIdentity |
                       SqlBulkCopyOptions.UseInternalTransaction))
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
            long countEnd = Convert.ToInt32(
                commandRowCount.ExecuteScalar());
            Console.WriteLine("Ending row count = {0}", countEnd);
            Console.WriteLine("{0} rows were added.", countEnd - countStart);
            Console.WriteLine("Press Enter to finish.");
            Console.ReadLine();
        }
        // </Snippet1>
    }

    static string GetConnectionString() =>
        throw new NotImplementedException();
}
