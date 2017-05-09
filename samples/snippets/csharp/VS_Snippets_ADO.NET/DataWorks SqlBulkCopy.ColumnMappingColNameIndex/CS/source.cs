using System;
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

            // Perform an initial count on the destination table.
            SqlCommand commandRowCount = new SqlCommand(
                "SELECT COUNT(*) FROM " +
                "dbo.BulkCopyDemoDifferentColumns;",
                sourceConnection);
            long countStart = System.Convert.ToInt32(
                commandRowCount.ExecuteScalar());
            Console.WriteLine("Starting row count = {0}", countStart);

            // Get data from the source table as a SqlDataReader.
            SqlCommand commandSourceData = new SqlCommand(
                "SELECT ProductID, Name, " +
                "ProductNumber " +
                "FROM Production.Product;", sourceConnection);
            SqlDataReader reader =
                commandSourceData.ExecuteReader();

            // Set up the bulk copy object. 
            using (SqlBulkCopy bulkCopy =
                       new SqlBulkCopy(connectionString))
            {
                bulkCopy.DestinationTableName =
                    "dbo.BulkCopyDemoDifferentColumns";

                // The column order in the source doesn't match the order 
                // in the destination, so ColumnMappings must be defined.
                bulkCopy.ColumnMappings.Add("ProductID", 0);
                bulkCopy.ColumnMappings.Add("ProductNumber", 1);
                bulkCopy.ColumnMappings.Add("Name", 2);

                // Write from the source to the destination.
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
                    // Close the SqlDataReader. The SqlBulkCopy
                    // object is automatically closed at the end
                    // of the using block.
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
