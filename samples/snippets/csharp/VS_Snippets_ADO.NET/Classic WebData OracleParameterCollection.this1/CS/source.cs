using System;
using System.Xml;
using System.Data;
using System.Data.OracleClient;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;
    protected OracleParameterCollection parameters;

    // <Snippet1>
    public void SearchOracleParams() 
    {
        // ...
        // create OracleParameterCollection parameters
        // ...
        if (!parameters.Contains("DName"))
            Console.WriteLine("ERROR: no such parameter in the collection");
        else
            Console.WriteLine("Name: " + parameters["DName"].ToString() +
                "Index: " + parameters.IndexOf("DName").ToString());
    }
    // </Snippet1>

}
