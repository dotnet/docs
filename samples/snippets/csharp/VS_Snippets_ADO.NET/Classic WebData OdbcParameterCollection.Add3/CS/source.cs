using System;
using System.Xml;
using System.Data;
using System.Data.Odbc;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    public void CreateOdbcParamColl(OdbcConnection connection) 
    {
        OdbcCommand command = new OdbcCommand(
            "SELECT * FROM Customers WHERE CustomerID = ?", connection);
        OdbcParameterCollection paramCollection = command.Parameters;
        OdbcParameter parameter = paramCollection.Add(
            "CustomerID", OdbcType.VarChar, 5);
    }
    // </Snippet1>

}
