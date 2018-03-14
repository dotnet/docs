using System;
using System.Data;
using System.Data.SqlClient;


class Program
{
    static void Main()
    {
        string connectionString = GetConnectionString();
        ConnectToData(connectionString);
        Console.ReadLine();
    }
    private static void ConnectToData(string connectionString)
    {
        using (SqlConnection connection =
                   new SqlConnection(connectionString))
        {
            SqlDataAdapter adapter = 
                new SqlDataAdapter(
                "SELECT CustomerID, CompanyName FROM dbo.Customers", 
                connection);
            DataSet dataSet = new DataSet();

            // <Snippet1>
            DataTable customers = dataSet.Tables["Customers"];

            // Make modifications to the Customers table.

            // Get changes to the DataSet.
            DataSet dataSetChanges = dataSet.GetChanges();

            // Add an event handler to handle the errors during Update.
            adapter.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);

            connection.Open();
            adapter.Update(dataSetChanges, "Customers");
            connection.Close();

            // Merge the updates.
            dataSet.Merge(dataSetChanges, true, MissingSchemaAction.Add);

            // Reject changes on rows with errors and clear the error.
            DataRow[] errRows = dataSet.Tables["Customers"].GetErrors();
            foreach (DataRow errRow in errRows)
            {
                errRow.RejectChanges();
                errRow.RowError = null;
            }

            // Commit the changes.
            dataSet.AcceptChanges();

            // </Snippet1>
        }
    }

    // <Snippet2>
    protected static void OnRowUpdated(
        object sender, SqlRowUpdatedEventArgs args)
    {
        if (args.Status == UpdateStatus.ErrorsOccurred)
        {
            args.Row.RowError = args.Errors.Message;
            args.Status = UpdateStatus.SkipCurrentRow;
        }
    }
   // </Snippet2>

    static private string GetConnectionString()
    {
        // To avoid storing the connection string in your code, 
        // you can retrieve it from a configuration file.
        return "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=SSPI";
    }
}
