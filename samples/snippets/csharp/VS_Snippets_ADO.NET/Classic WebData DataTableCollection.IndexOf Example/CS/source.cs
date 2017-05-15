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
    private void GetIndexes()
    {
        // Get the DataSet of a DataGrid.
        DataSet thisDataSet = (DataSet)DataGrid1.DataSource;

        // Get the DataTableCollection through the Tables property.
        DataTableCollection tables = thisDataSet.Tables;

        // Get the index of each table in the collection.
        foreach (DataTable table in tables)
            System.Diagnostics.Debug.WriteLine(tables.IndexOf(table));
    }
    // </Snippet1>

}
