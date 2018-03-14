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
    protected OdbcParameterCollection parameterCollection;

    // <Snippet1>
    public void SearchParameters() 
    {
        // ...
        // create OdbcParameterCollection parameterCollection
        // ...
        if (!parameterCollection.Contains("Description"))
            Console.WriteLine("ERROR: no such parameter in the collection");
        else
            Console.WriteLine("Name: " + parameterCollection["Description"].ToString() +
                "Index: " + parameterCollection.IndexOf("Description").ToString());
    }
    // </Snippet1>

}
