using System;
using System.Xml;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet dataSet;
    protected OleDbDataAdapter adapter;


    // <Snippet1>
    public void GetRecords() 
    {
        // ...
        // create dataSet and adapter
        // ...
        adapter.Fill(dataSet,9,15,"Categories");
    }
    // </Snippet1>

}
