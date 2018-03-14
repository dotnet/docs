using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;


public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid DataGrid1;

    // <Snippet1>
    private void ClearTables()
    {
        // Get the DataSet of a DataGrid control.
        DataSet dataSet = (DataSet)DataGrid1.DataSource;
        DataTableCollection tables = dataSet.Tables;

        // Clear the collection.
        tables.Clear();
    }
    // </Snippet1>

}