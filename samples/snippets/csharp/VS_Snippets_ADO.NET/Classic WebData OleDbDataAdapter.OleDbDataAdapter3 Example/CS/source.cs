using System;
using System.Data;
using System.Data.OleDb;

class Class1
{
    static void Main()
    {
    }

    //<Snippet1>
    public static OleDbDataAdapter CreateDataAdapter(
        OleDbConnection connection)
    {
        string selectCommand = 
            "SELECT CustomerID, CompanyName FROM Customers";
        OleDbDataAdapter adapter = 
            new OleDbDataAdapter(selectCommand, connection);

        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

        // Create the Insert, Update and Delete commands.
        adapter.InsertCommand = new OleDbCommand(
            "INSERT INTO Customers (CustomerID, CompanyName) " +
            "VALUES (?, ?)");

        adapter.UpdateCommand = new OleDbCommand(
            "UPDATE Customers SET CustomerID = ?, CompanyName = ? " +
            "WHERE CustomerID = ?");

        adapter.DeleteCommand = new OleDbCommand(
            "DELETE FROM Customers WHERE CustomerID = ?");

        // Create the parameters.
        adapter.InsertCommand.Parameters.Add("@CustomerID", 
            OleDbType.Char, 5, "CustomerID");
        adapter.InsertCommand.Parameters.Add("@CompanyName", 
            OleDbType.VarChar, 40, "CompanyName");

        adapter.UpdateCommand.Parameters.Add("@CustomerID", 
            OleDbType.Char, 5, "CustomerID");
        adapter.UpdateCommand.Parameters.Add("@CompanyName", 
            OleDbType.VarChar, 40, "CompanyName");
        adapter.UpdateCommand.Parameters.Add("@oldCustomerID", 
            OleDbType.Char, 5, "CustomerID").SourceVersion = 
            DataRowVersion.Original;

        adapter.DeleteCommand.Parameters.Add("@CustomerID", 
            OleDbType.Char, 5, "CustomerID").SourceVersion = 
            DataRowVersion.Original;

        return adapter;
    }
    //</Snippet1>
}


