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

    public OdbcConnection connection;
    // <Snippet1>
    public void CreateParamCollection() 
    {
        OdbcCommand command = new OdbcCommand(
            "SELECT * FROM Customers WHERE CustomerID = ?", connection);
        OdbcParameterCollection paramCollection = command.Parameters;
        object paramObject = new OdbcParameter(
            "CustomerID", OdbcType.VarChar);
        int paramIndex = paramCollection.Add(paramObject);
    }
    // </Snippet1>

}
