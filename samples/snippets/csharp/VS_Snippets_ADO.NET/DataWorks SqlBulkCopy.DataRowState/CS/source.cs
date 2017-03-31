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

            // Perform an initial count on the destination table.
            SqlCommand commandRowCount = new SqlCommand(
                "SELECT COUNT(*) FROM " +
                "dbo.BulkCopyDemoMatchingColumns;",
                connection);
            long countStart = System.Convert.ToInt32(
                commandRowCount.ExecuteScalar());
            Console.WriteLine("Starting row count = {0}", countStart);

            // Create a table with some rows. 
            DataTable newProducts = MakeTable();
            
            // Make a change to one of the rows in the DataTable.
            DataRow row = newProducts.Rows[0];
            row.BeginEdit();
            row["Name"] = "AAA";
            row.EndEdit();

            // Create the SqlBulkCopy object. 
            // Note that the column positions in the source DataTable 
            // match the column positions in the destination table so 
            // there is no need to map columns. 
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.DestinationTableName = 
                    "dbo.BulkCopyDemoMatchingColumns";

                try
                {
                    // Write unchanged rows from the source to the destination.
                    bulkCopy.WriteToServer(newProducts, DataRowState.Unchanged);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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

    private static DataTable MakeTable()
        // Create a new DataTable named NewProducts. 
    {
        DataTable newProducts = new DataTable("NewProducts");

        // Add three column objects to the table. 
        DataColumn productID = new DataColumn();
        productID.DataType = System.Type.GetType("System.Int32");
        productID.ColumnName = "ProductID";
        productID.AutoIncrement = true;
        newProducts.Columns.Add(productID);

        DataColumn productName = new DataColumn();
        productName.DataType = System.Type.GetType("System.String");
        productName.ColumnName = "Name";
        newProducts.Columns.Add(productName);

        DataColumn productNumber = new DataColumn();
        productNumber.DataType = System.Type.GetType("System.String");
        productNumber.ColumnName = "ProductNumber";
        newProducts.Columns.Add(productNumber);

        // Create an array for DataColumn objects.
        DataColumn[] keys = new DataColumn[1];
        keys[0] = productID;
        newProducts.PrimaryKey = keys;

        // Add some new rows to the collection. 
        DataRow row = newProducts.NewRow();
        row["Name"] = "CC-101-WH";
        row["ProductNumber"] = "Cyclocomputer - White";

        newProducts.Rows.Add(row);
        row = newProducts.NewRow();
        row["Name"] = "CC-101-BK";
        row["ProductNumber"] = "Cyclocomputer - Black";

        newProducts.Rows.Add(row);
        row = newProducts.NewRow();
        row["Name"] = "CC-101-ST";
        row["ProductNumber"] = "Cyclocomputer - Stainless";
        newProducts.Rows.Add(row);
        newProducts.AcceptChanges();

        // Return the new DataTable. 
        return newProducts;
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
