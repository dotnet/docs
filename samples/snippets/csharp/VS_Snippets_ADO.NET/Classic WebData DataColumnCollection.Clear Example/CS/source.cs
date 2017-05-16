using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>

    private void ClearColumnsCollection(DataTable table)
    {
        DataColumnCollection columns;
        // Get the DataColumnCollection from a 
        // DataTable in a DataSet.
        columns = table.Columns;
        columns.Clear();
    }
    // </Snippet1>

}
