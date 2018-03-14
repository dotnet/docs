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
    protected OleDbParameterCollection parameters;

    // <Snippet1>
    public void SearchParameters() 
    {
        // ...
        // create OleDbParameterCollection parameters
        // ...
        if (!parameters.Contains("Description"))
            Console.WriteLine("ERROR: no such parameter in the collection");
        else
            Console.WriteLine("Name: " + parameters["Description"].ToString() +
                "Index: " + parameters.IndexOf("Description").ToString());
    }
    // </Snippet1>

}
