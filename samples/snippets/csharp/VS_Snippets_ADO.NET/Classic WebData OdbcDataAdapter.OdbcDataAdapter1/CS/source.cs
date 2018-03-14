using System;
using System.Data;
using System.Data.Odbc;

class Program
{
    static void Main()
    {
        //string connectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\\Samples\\Northwind.mdb";
        //string x = "DRIVER={SQL Server};SERVER=MyServer;Trusted_connection=yes;DATABASE=Northwind;"
    }


    //<Snippet1>
    public static OdbcDataAdapter CreateDataAdapter(
        OdbcConnection connection)
    {
        string selectCommand =
            "SELECT CustomerID, CompanyName FROM Customers";

        OdbcDataAdapter adapter = new OdbcDataAdapter(
            selectCommand, connection);
        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

        // Create the Insert, Update and Delete commands.
        adapter.InsertCommand = new OdbcCommand(
            "INSERT INTO Customers (CustomerID, CompanyName) " +
            "VALUES (?, ?)");

        adapter.UpdateCommand = new OdbcCommand(
            "UPDATE Customers SET CustomerID = ?, CompanyName = ? " +
            "WHERE CustomerID = ?");

        adapter.DeleteCommand = new OdbcCommand(
            "DELETE FROM Customers WHERE CustomerID = ?");

        // Create the parameters.
        adapter.InsertCommand.Parameters.Add("@CustomerID",
            OdbcType.Char, 5, "CustomerID");
        adapter.InsertCommand.Parameters.Add("@CompanyName",
            OdbcType.VarChar, 40, "CompanyName");

        adapter.UpdateCommand.Parameters.Add("@CustomerID",
            OdbcType.Char, 5, "CustomerID");
        adapter.UpdateCommand.Parameters.Add("@CompanyName",
            OdbcType.VarChar, 40, "CompanyName");
        adapter.UpdateCommand.Parameters.Add("@oldCustomerID",
            OdbcType.Char, 5, "CustomerID").SourceVersion =
            DataRowVersion.Original;

        adapter.DeleteCommand.Parameters.Add("@CustomerID",
            OdbcType.Char, 5, "CustomerID").SourceVersion =
            DataRowVersion.Original;

        return adapter;
    }
    //</Snippet1>
}
