using System;
using System.Data;
// <Snippet1>
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = GetConnectionString();
        // Open a connection to the AdventureWorks database.
        using (SqlConnection connection =
                   new SqlConnection(connectionString))
        {
            connection.Open();

            // Empty the destination tables. 
            SqlCommand deleteHeader = new SqlCommand(
                "DELETE FROM dbo.BulkCopyDemoOrderHeader;",
                connection);
            deleteHeader.ExecuteNonQuery();
            SqlCommand deleteDetail = new SqlCommand(
                "DELETE FROM dbo.BulkCopyDemoOrderDetail;",
                connection);
            deleteDetail.ExecuteNonQuery();

            // Perform an initial count on the destination
            //  table with matching columns. 
            SqlCommand countRowHeader = new SqlCommand(
                "SELECT COUNT(*) FROM dbo.BulkCopyDemoOrderHeader;",
                connection);
            long countStartHeader = System.Convert.ToInt32(
                countRowHeader.ExecuteScalar());
            Console.WriteLine(
                "Starting row count for Header table = {0}",
                countStartHeader);

            // Perform an initial count on the destination
            // table with different column positions. 
            SqlCommand countRowDetail = new SqlCommand(
                "SELECT COUNT(*) FROM dbo.BulkCopyDemoOrderDetail;",
                connection);
            long countStartDetail = System.Convert.ToInt32(
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
            SqlCommand headerData = new SqlCommand(
                "SELECT [SalesOrderID], [OrderDate], " +
                "[AccountNumber] FROM [Sales].[SalesOrderHeader] " +
                "WHERE [AccountNumber] = @accountNumber;",
                connection);
            SqlParameter parameterAccount = new SqlParameter();
            parameterAccount.ParameterName = "@accountNumber";
            parameterAccount.SqlDbType = SqlDbType.NVarChar;
            parameterAccount.Direction = ParameterDirection.Input;
            parameterAccount.Value = "10-4020-000034";
            headerData.Parameters.Add(parameterAccount);
            SqlDataReader readerHeader = headerData.ExecuteReader();

            // Get the Detail data in a separate connection.
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();
                SqlCommand sourceDetailData = new SqlCommand(
                    "SELECT [Sales].[SalesOrderDetail].[SalesOrderID], [SalesOrderDetailID], " +
                    "[OrderQty], [ProductID], [UnitPrice] FROM [Sales].[SalesOrderDetail] " +
                    "INNER JOIN [Sales].[SalesOrderHeader] ON [Sales].[SalesOrderDetail]." +
                    "[SalesOrderID] = [Sales].[SalesOrderHeader].[SalesOrderID] " +
                    "WHERE [AccountNumber] = @accountNumber;", connection2);

                SqlParameter accountDetail = new SqlParameter();
                accountDetail.ParameterName = "@accountNumber";
                accountDetail.SqlDbType = SqlDbType.NVarChar;
                accountDetail.Direction = ParameterDirection.Input;
                accountDetail.Value = "10-4020-000034";
                sourceDetailData.Parameters.Add(accountDetail);
                SqlDataReader readerDetail = sourceDetailData.ExecuteReader();

                // Create the SqlBulkCopy object. 
                using (SqlBulkCopy bulkCopy =
                           new SqlBulkCopy(connectionString))
                {
                    bulkCopy.DestinationTableName =
                        "dbo.BulkCopyDemoOrderHeader";

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

                    // Set up a different destination and 
                    // map columns. 
                    bulkCopy.DestinationTableName =
                        "dbo.BulkCopyDemoOrderDetail";

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
                long countEndHeader = System.Convert.ToInt32(
                    countRowHeader.ExecuteScalar());
                Console.WriteLine("{0} rows were added to the Header table.",
                    countEndHeader - countStartHeader);
                long countEndDetail = System.Convert.ToInt32(
                    countRowDetail.ExecuteScalar());
                Console.WriteLine("{0} rows were added to the Detail table.",
                    countEndDetail - countStartDetail);
                Console.WriteLine("Press Enter to finish.");
                Console.ReadLine();
            }
        }
    }

    private static string GetConnectionString()
        // To avoid storing the connection string in your code, 
        // you can retrieve it from a configuration file. 
    {
        return "Data Source=(local); " +
            " Integrated Security=true;" +
            "Initial Catalog=AdventureWorks;";
    }
}
// </Snippet1>
