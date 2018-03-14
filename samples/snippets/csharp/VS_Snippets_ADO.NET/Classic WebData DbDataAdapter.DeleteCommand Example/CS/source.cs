using System;
using System.Data;
using System.Data.OleDb;

public class Sample
{

    public static void Main()
    {
    }

    //<Snippet1>
    public static OleDbDataAdapter CreateCustomerAdapter(
        OleDbConnection connection)
    {
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
        OleDbCommand command;
        OleDbParameter parameter;

        // Create the SelectCommand.
        command = new OleDbCommand("SELECT CustomerID FROM Customers " +
            "WHERE Country = ? AND City = ?", connection);

        command.Parameters.Add("Country", OleDbType.VarChar, 15);
        command.Parameters.Add("City", OleDbType.VarChar, 15);

        dataAdapter.SelectCommand = command;

        // Create the DeleteCommand.
        command = new OleDbCommand(
            "DELETE * FROM Customers WHERE CustomerID = ?", 
            connection);

        parameter = command.Parameters.Add(
            "CustomerID", OleDbType.Char, 5, "CustomerID");
        parameter.SourceVersion = DataRowVersion.Original;

        dataAdapter.DeleteCommand = command;

        return dataAdapter;
    }
    //</Snippet1>
}



