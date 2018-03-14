using System;
using System.Data;
using System.Data.OleDb;

class Class1
{
    static void Main()
    {
        string x = "Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI;Initial Catalog=Northwind";
        CreateDataAdapter(x);
    }

    //<Snippet1>
    public static void CreateDataAdapter(
        string connectionString)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(
                "SELECT * FROM Customers WHERE CustomerID = 'ALFKI'", connection);

            adapter.InsertCommand = new OleDbCommand(
                "INSERT INTO Customers (CustomerID, CompanyName) VALUES(?, ?)", 
                connection);

            adapter.InsertCommand.Parameters.Add(
                "@CustomerID", OleDbType.VarChar, 5, "CustomerID");
            adapter.InsertCommand.Parameters.Add(
                "@CompanyName", OleDbType.VarChar, 30, "CompanyName");

            connection.Open();

            DataSet custDS = new DataSet();
            adapter.Fill(custDS, "Customers");

            DataRow custRow = custDS.Tables["Customers"].NewRow();
            custRow["CustomerID"] = "NEWCO";
            custRow["CompanyName"] = "New Company";
            custDS.Tables["Customers"].Rows.Add(custRow);

            // add handlers
            adapter.RowUpdating += new OleDbRowUpdatingEventHandler(OnRowUpdating);
            adapter.RowUpdated += new OleDbRowUpdatedEventHandler(OnRowUpdated);

            adapter.Update(custDS, "Customers");

            // remove handlers
            adapter.RowUpdating -= new OleDbRowUpdatingEventHandler(OnRowUpdating);
            adapter.RowUpdated -= new OleDbRowUpdatedEventHandler(OnRowUpdated);

            foreach (DataRow row in custDS.Tables["Customers"].Rows)
            {
                if (row.HasErrors)
                    Console.WriteLine(row.RowError);
            }
        }
    }

    protected static void OnRowUpdating(object sender, 
        OleDbRowUpdatingEventArgs args)
    {
        if (args.StatementType == StatementType.Insert)
        {
            System.IO.TextWriter writer = System.IO.File.AppendText("Inserts.log");
            writer.WriteLine("{0}: Customer {1} Inserted.", 
                DateTime.Now, args.Row["CustomerID"]);
            writer.Close();
        }
    }

    protected static void OnRowUpdated(object sender, OleDbRowUpdatedEventArgs args)
    {
        if (args.Status == UpdateStatus.ErrorsOccurred)
        {
            args.Row.RowError = args.Errors.Message;
            args.Status = UpdateStatus.SkipCurrentRow;
        }
    }
    //</Snippet1>
}


