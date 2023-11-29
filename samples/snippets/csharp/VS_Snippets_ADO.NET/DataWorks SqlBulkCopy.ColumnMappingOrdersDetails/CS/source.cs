using System;
using System.Data;
// <Snippet1>
using System.Data.SqlClient;

static class Program
{
    static void Main()
    {
        var connectionString = GetConnectionString();
        // Open a connection to the AdventureWorks database.
        using (SqlConnection connection =
                   new(connectionString))
        {
            connection.Open();

            // Empty the destination tables.
            SqlCommand deleteHeader = new(
                "DELETE FROM dbo.BulkCopyDemoOrderHeader;",
                connection);
            deleteHeader.ExecuteNonQuery();
            SqlCommand deleteDetail = new(
                "DELETE FROM dbo.BulkCopyDemoOrderDetail;",
                connection);
            deleteDetail.ExecuteNonQuery();

            // Perform an initial count on the destination
            //  table with matching columns.
            SqlCommand countRowHeader = new(
                "SELECT COUNT(*) FROM dbo.BulkCopyDemoOrderHeader;",
                connection);
            long countStartHeader = Convert.ToInt32(
                countRowHeader.ExecuteScalar());
            Console.WriteLine(
                "Starting row count for Header table = {0}",
                countStartHeader);

            // Perform an initial count on the destination
            // table with different column positions.
            SqlCommand countRowDetail = new(
                "SELECT COUNT(*) FROM dbo.BulkCopyDemoOrderDetail;",
                connection);
            long countStartDetail = Convert.ToInt32(
                countRowDetail.ExecuteScalar());
            Console.WriteLine(
                "Starting row count for Detail table = {0}",
                countStartDetail);

            // Get data from the source table as a SqlDataReader.
            // The Sales.SalesOrderHeader and Sales.SalesOrderDetail
            // tables are quite large and could easily cause a timeout
            // if all data from the tables is added to the destination.
            // To keep the example simple and quick, a parameter is
            // used to select only orders for a particular account
            // as the source for the bulk insert.
            SqlCommand headerData = new(
                "SELECT [SalesOrderID], [OrderDate], " +
                "[AccountNumber] FROM [Sales].[SalesOrderHeader] " +
                "WHERE [AccountNumber] = @accountNumber;",
                connection);
            SqlParameter parameterAccount = new()
            {
                ParameterName = "@accountNumber",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Value = "10-4020-000034"
            };
            headerData.Parameters.Add(parameterAccount);
            SqlDataReader readerHeader = headerData.ExecuteReader();

            // Get the Detail data in a separate connection.
            using (SqlConnection connection2 = new(connectionString))
            {
                connection2.Open();
                SqlCommand sourceDetailData = new(
                    "SELECT [Sales].[SalesOrderDetail].[SalesOrderID], [SalesOrderDetailID], " +
                    "[OrderQty], [ProductID], [UnitPrice] FROM [Sales].[SalesOrderDetail] " +
                    "INNER JOIN [Sales].[SalesOrderHeader] ON [Sales].[SalesOrderDetail]." +
                    "[SalesOrderID] = [Sales].[SalesOrderHeader].[SalesOrderID] " +
                    "WHERE [AccountNumber] = @accountNumber;", connection2);

                SqlParameter accountDetail = new()
                {
                    ParameterName = "@accountNumber",
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Value = "10-4020-000034"
                };
                sourceDetailData.Parameters.Add(accountDetail);
                SqlDataReader readerDetail = sourceDetailData.ExecuteReader();

                // Create the SqlBulkCopy object.
                using (SqlBulkCopy bulkCopy =
                           new(connectionString))
                {
                    bulkCopy.DestinationTableName =
                        "dbo.BulkCopyDemoOrderHeader";

                    // Guarantee that columns are mapped correctly by
                    // defining the column mappings for the order.
                    bulkCopy.ColumnMappings.Add("SalesOrderID", "SalesOrderID");
                    bulkCopy.ColumnMappings.Add("OrderDate", "OrderDate");
                    bulkCopy.ColumnMappings.Add("AccountNumber", "AccountNumber");

                    // Write readerHeader to the destination.
                    try
                    {
                        bulkCopy.WriteToServer(readerHeader);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        readerHeader.Close();
                    }

                    // Set up the order details destination.
                    bulkCopy.DestinationTableName = "dbo.BulkCopyDemoOrderDetail";

                    // Clear the ColumnMappingCollection.
                    bulkCopy.ColumnMappings.Clear();

                    // Add order detail column mappings.
                    bulkCopy.ColumnMappings.Add("SalesOrderID", "SalesOrderID");
                    bulkCopy.ColumnMappings.Add("SalesOrderDetailID", "SalesOrderDetailID");
                    bulkCopy.ColumnMappings.Add("OrderQty", "OrderQty");
                    bulkCopy.ColumnMappings.Add("ProductID", "ProductID");
                    bulkCopy.ColumnMappings.Add("UnitPrice", "UnitPrice");

                    // Write readerDetail to the destination.
                    try
                    {
                        bulkCopy.WriteToServer(readerDetail);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        readerDetail.Close();
                    }
                }

                // Perform a final count on the destination
                // tables to see how many rows were added.
                long countEndHeader = Convert.ToInt32(
                    countRowHeader.ExecuteScalar());
                Console.WriteLine("{0} rows were added to the Header table.",
                    countEndHeader - countStartHeader);
                long countEndDetail = Convert.ToInt32(
                    countRowDetail.ExecuteScalar());
                Console.WriteLine("{0} rows were added to the Detail table.",
                    countEndDetail - countStartDetail);
                Console.WriteLine("Press Enter to finish.");
                Console.ReadLine();
            }
        }
    }

    static string GetConnectionString()
    // To avoid storing the connection string in your code,
    // you can retrieve it from a configuration file.
    {
        return "Data Source=(local); " +
            " Integrated Security=true;" +
            "Initial Catalog=AdventureWorks;";
    }
}
// </Snippet1>
