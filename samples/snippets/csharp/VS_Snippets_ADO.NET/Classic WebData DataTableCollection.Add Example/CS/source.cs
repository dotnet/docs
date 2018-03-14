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
    private void AddDataTable()
    {
        // Get the DataTableCollection of a DataGrid 
        // control's DataSet.
        DataTableCollection tables = 
            ((DataSet)DataGrid1.DataSource).Tables;

        // Create a new DataTable.
        DataTable table = new DataTable();

        // Code to add columns and rows not shown here.
    
        // Add the table to the DataTableCollection.
        tables.Add(table);
    }
    // </Snippet1>

}
