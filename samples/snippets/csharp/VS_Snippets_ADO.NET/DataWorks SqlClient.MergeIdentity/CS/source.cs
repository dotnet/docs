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

            // Add the parameter for the inserted value.
            adapter.InsertCommand.Parameters.Add(
               new SqlParameter("@CompanyName", SqlDbType.NVarChar, 40,
               "CompanyName"));
            adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;

            // MissingSchemaAction adds any missing schema to 
            // the DataTable, including identity columns
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            // Fill the DataTable.
            DataTable shipper = new DataTable();
            adapter.Fill(shipper);

            // Add a new shipper. 
            DataRow newRow = shipper.NewRow();
            newRow["CompanyName"] = "New Shipper";
            shipper.Rows.Add(newRow);

            // Add changed rows to a new DataTable. This
            // DataTable will be used by the DataAdapter.
            DataTable dataChanges = shipper.GetChanges();

            // Add the event handler. 
            adapter.RowUpdated +=
                new SqlRowUpdatedEventHandler(OnRowUpdated);

            adapter.Update(dataChanges);
            connection.Close();

            // Merge the updates.
            shipper.Merge(dataChanges);

            // Commit the changes.
            shipper.AcceptChanges();

            Console.WriteLine("Rows after merge.");
            foreach (DataRow row in shipper.Rows)
            {
                {
                    Console.WriteLine("{0}: {1}", row[0], row[1]);
                }
            }
        }
    }
    // </Snippet1>

    // <Snippet2>
    protected static void OnRowUpdated(
        object sender, SqlRowUpdatedEventArgs e)
    {
        // If this is an insert, then skip this row.
        if (e.StatementType == StatementType.Insert)
        {
            e.Status = UpdateStatus.SkipCurrentRow;
        }
    }
    // </Snippet2>

    static private string GetConnectionString()
    {
        // To avoid storing the connection string in your code, 
        // you can retrieve it from a configuration file.
        return "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=true";
    }
}
