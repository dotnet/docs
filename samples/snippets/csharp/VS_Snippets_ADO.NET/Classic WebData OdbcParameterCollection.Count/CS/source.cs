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
    public void CreateParameterCollection(OdbcCommand command) 
    {
        OdbcParameterCollection paramCollection = command.Parameters;
        paramCollection.Add("@CategoryName", OdbcType.Char);
        paramCollection.Add("@Description", OdbcType.Char);
        paramCollection.Add("@Picture", OdbcType.Binary);
        string paramNames = "";
        for (int i=0; i < paramCollection.Count; i++)
            paramNames += paramCollection[i].ToString() + "\n";
        Console.WriteLine(paramNames);
        paramCollection.Clear();
    }
    // </Snippet1>

}
