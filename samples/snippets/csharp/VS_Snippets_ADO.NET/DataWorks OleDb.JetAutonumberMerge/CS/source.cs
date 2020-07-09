using System;
using System.Data;
using System.Data.OleDb;

class Program
{
    static void Main()
    {
        string connectionString = GetConnectionString();
        connection = new OleDbConnection(connectionString);
        MergeIdentityColumns(connection);
        Console.ReadLine();
    }
    // <Snippet1>
    private static OleDbConnection connection = null;

    private static void MergeIdentityColumns(OleDbConnection connection)
    {
        using (connection)
        {
            // Create a DataAdapter based on a SELECT query.
            OleDbDataAdapter adapter = new OleDbDataAdapter(
             "SELECT CategoryID, CategoryName FROM Categories",
             connection);

            // Create the INSERT command for the new category.
            adapter.InsertCommand = new OleDbCommand(
              "INSERT INTO Categories (CategoryName) Values(?)", connection);
            adapter.InsertCommand.CommandType = CommandType.Text;

            // Add the parameter for the CategoryName.
            adapter.InsertCommand.Parameters.Add(
              "@CategoryName", OleDbType.VarWChar, 15, "CategoryName");
            adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;

            // Create a DataTable
            DataTable categories = new DataTable();

            // Create the CategoryID column and set its auto
            // incrementing properties to decrement from zero.
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CategoryID";
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 0;
            column.AutoIncrementStep = -1;
            categories.Columns.Add(column);

            // Create the CategoryName column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CategoryName";
            categories.Columns.Add(column);

            // Set the primary key on CategoryID.
            DataColumn[] pKey = new DataColumn[1];
            pKey[0] = categories.Columns["CategoryID"];
            categories.PrimaryKey = pKey;

            // Fetch the data and fill the DataTable
            adapter.Fill(categories);

            // Add a new row.
            DataRow newRow = categories.NewRow();
            newRow["CategoryName"] = "New Category";
            categories.Rows.Add(newRow);

            // Add another new row.
            DataRow newRow2 = categories.NewRow();
            newRow2["CategoryName"] = "Another New Category";
            categories.Rows.Add(newRow2);

            // Add changed rows to a new DataTable that will be
            // used to post the inserts to the database.
            DataTable dataChanges = categories.GetChanges();

            // Include an event to fill in the Autonumber value.
            adapter.RowUpdated +=
                new OleDbRowUpdatedEventHandler(OnRowUpdated);

            // Update the database, inserting the new rows.
            adapter.Update(dataChanges);

            Console.WriteLine("Rows before merge:");
            foreach (DataRow row in categories.Rows)
            {
                {
                    Console.WriteLine("  {0}: {1}", row[0], row[1]);
                }
            }

            // Merge the two DataTables.
            categories.Merge(dataChanges);

            // Commit the changes.
            categories.AcceptChanges();

            Console.WriteLine("Rows after merge:");
            foreach (DataRow row in categories.Rows)
            {
                {
                    Console.WriteLine("  {0}: {1}", row[0], row[1]);
                }
            }
        }
    }
    // </Snippet1>

    // <Snippet2>
    private static void OnRowUpdated(
      object sender, OleDbRowUpdatedEventArgs e)
    {
        // Conditionally execute this code block on inserts only.
        if (e.StatementType == StatementType.Insert)
        {
            OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY",
                connection);
            // Retrieve the Autonumber and store it in the CategoryID column.
            e.Row["CategoryID"] = (int)cmdNewID.ExecuteScalar();
            e.Status = UpdateStatus.SkipCurrentRow;
        }
    }
    // </Snippet2>

    static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file.
        return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
            + "c:\\Data\\Northwind.mdb;User Id=admin;Password=;";
    }
}
