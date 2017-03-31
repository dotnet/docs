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
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        OleDbCommand command;

        // Create the SelectCommand.
        command = new OleDbCommand("SELECT * FROM Customers " +
            "WHERE Country = ? AND City = ?", connection);

        command.Parameters.Add("Country", OleDbType.VarChar, 15);
        command.Parameters.Add("City", OleDbType.VarChar, 15);

        adapter.SelectCommand = command;

        // Create the InsertCommand.
        command = new OleDbCommand(
            "INSERT INTO Customers (CustomerID, CompanyName) " +
            "VALUES (?, ?)", connection);

        command.Parameters.Add(
            "CustomerID", OleDbType.Char, 5, "CustomerID");
        command.Parameters.Add(
            "CompanyName", OleDbType.VarChar, 40, "CompanyName");

        adapter.InsertCommand = command;
        return adapter;
    }
    //</Snippet1>
}



