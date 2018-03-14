using System;
using System.Xml;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;

    public OleDbConnection connection;
    // <Snippet1>
    public void CreateParameters() 
    {
        OleDbCommand command = new OleDbCommand(
            "SELECT * FROM Customers WHERE CustomerID = ?", connection);
        OleDbParameterCollection paramCollection = command.Parameters;
        OleDbParameter myParm = paramCollection.Add(
            new OleDbParameter("CustomerID", OleDbType.VarChar));
    }
    // </Snippet1>

}
