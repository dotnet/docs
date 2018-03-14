using System;
using System.Data;
using System.Data.OleDb;

public class Sample
{

  public static void Main()
  {
  }

//<Snippet1>
public static OleDbDataAdapter CreateCustomerAdapter(OleDbConnection conn)
{
  OleDbDataAdapter da = new OleDbDataAdapter();
  OleDbCommand cmd;
  OleDbParameter parm;

  // Create the SelectCommand.

  cmd = new OleDbCommand("SELECT * FROM Customers " +
                       "WHERE Country = @Country AND City = @City", conn);

  cmd.Parameters.Add("@Country", OleDbType.VarChar, 15);
  cmd.Parameters.Add("@City", OleDbType.VarChar, 15);

  da.SelectCommand = cmd;

  // Create the UpdateCommand.

  cmd = new OleDbCommand("UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName " +
                       "WHERE CustomerID = @oldCustomerID", conn);

  cmd.Parameters.Add("@CustomerID", OleDbType.Char, 5, "CustomerID");
  cmd.Parameters.Add("@CompanyName", OleDbType.VarChar, 40, "CompanyName");

  parm = cmd.Parameters.Add("@oldCustomerID", OleDbType.Char, 5, "CustomerID");
  parm.SourceVersion = DataRowVersion.Original;

  da.UpdateCommand = cmd;

  return da;
}
//</Snippet1>
}



