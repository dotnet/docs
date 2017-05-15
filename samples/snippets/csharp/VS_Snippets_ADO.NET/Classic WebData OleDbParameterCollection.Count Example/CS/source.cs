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


    // <Snippet1>
    public void CreateParamCollection(OleDbCommand command) 
    {
        OleDbParameterCollection paramCollection = command.Parameters;
        paramCollection.Add("@CategoryName", OleDbType.Char);
        paramCollection.Add("@Description", OleDbType.Char);
        paramCollection.Add("@Picture", OleDbType.Binary);
        string parameterNames = "";
        for (int i=0; i < paramCollection.Count; i++)
            parameterNames += paramCollection[i].ToString() + "\n";
        Console.WriteLine(parameterNames);
        paramCollection.Clear();
    }
    // </Snippet1>

}
