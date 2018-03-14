using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = GetConnectionString();
        MergeIdentityColumns(connectionString);
        Console.ReadLine();
    }
    // <Snippet1>
    private static void MergeIdentityColumns(string connectionString)
    {
        using (SqlConnection connection =
                   new SqlConnection(connectionString))
        {
            // Create the DataAdapter
            SqlDataAdapter adapter =
                new SqlDataAdapter(
                "SELECT ShipperID, CompanyName FROM dbo.Shippers",
                connection);

            //Add the InsertCommand to retrieve new identity value.
            adapter.InsertCommand = new SqlCommand(
                "INSERT INTO dbo.Shippers (CompanyName) " +
                "VALUES (@CompanyName); " +
                "SELECT ShipperID, CompanyName FROM dbo.Shippers " +
                "WHERE ShipperID = SCOPE_IDENTITY();", connection);

            // Set AcceptChangesDuringUpdate to false
            adapter.AcceptChangesDuringUpdate = false;

            // Add the parameter for the inserted value.
            adapter.InsertCommand.Parameters.Add(
               new SqlParameter("@CompanyName", SqlDbType.NVarChar, 40,
               "CompanyName"));
            adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;

            // MissingSchemaAction adds any missing schema to 
            // the DataTable, including auto increment columns
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            // Fill a DataTable.
            DataTable shipper = new DataTable();
            adapter.Fill(shipper);

            // Add a new shipper row. 
            DataRow newRow = shipper.NewRow();
            newRow["CompanyName"] = "New Shipper";
            shipper.Rows.Add(newRow);

            // Add changed rows to a new DataTable. This
            // DataTable will be used to update the data source.
            DataTable dataChanges = shipper.GetChanges();

            adapter.Update(dataChanges);
            connection.Close();

            Console.WriteLine("Rows after merge.");
            foreach (DataRow rowBefore in shipper.Rows)
            {
                {
                    Console.WriteLine("{0}: {1}", rowBefore[0], rowBefore[1]);
                }
            }

            // Merge the two DataTables to get new values.
            shipper.Merge(dataChanges);

            // Commit the changes.
            shipper.AcceptChanges();

            Console.WriteLine("Rows after merge.");
            foreach (DataRow rowAfter in shipper.Rows)
            {
                {
                    Console.WriteLine("{0}: {1}", rowAfter[0], rowAfter[1]);
                }
            }
        }
    }
    // </Snippet1>

    static private string GetConnectionString()
    {
        // To avoid storing the connection string in your code, 
        // you can retrieve it from a configuration file.
        return "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=true";
    }
}
