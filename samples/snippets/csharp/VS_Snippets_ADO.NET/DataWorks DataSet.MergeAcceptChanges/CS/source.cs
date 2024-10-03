using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        var connectionString = GetConnectionString();
        ConnectToData(connectionString);
        Console.ReadLine();
    }
    static void ConnectToData(string connectionString)
    {
        using (SqlConnection connection =
                   new(connectionString))
        {
            SqlDataAdapter adapter =
                new(
                "SELECT CustomerID, CompanyName FROM dbo.Customers",
                connection);
            DataSet dataSet = new();

            // <Snippet1>
            DataTable customers = dataSet.Tables["Customers"]!;

            // Make modifications to the Customers table.

            // Get changes to the DataSet.
            DataSet dataSetChanges = dataSet.GetChanges() ?? new();

            // Add an event handler to handle the errors during Update.
            adapter.RowUpdated += OnRowUpdated;

            connection.Open();
            adapter.Update(dataSetChanges, "Customers");
            connection.Close();

            // Merge the updates.
            dataSet.Merge(dataSetChanges, true, MissingSchemaAction.Add);

            // Reject changes on rows with errors and clear the error.
            DataRow[] errRows = dataSet.Tables["Customers"]!.GetErrors();
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
            args.Row.RowError = args.Errors!.Message;
            args.Status = UpdateStatus.SkipCurrentRow;
        }
    }
    // </Snippet2>

    static string GetConnectionString() =>
        throw new NotImplementedException();
}
