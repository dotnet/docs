using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void AddRow(DataTable table)
    {
        // Create an array with three elements.
        object[] rowVals = new object[3];
        DataRowCollection rowCollection = table.Rows;
        rowVals[0] = "hello";
        rowVals[1] = "world";
        rowVals[2] = "two";

        // Add and return the new row.
        DataRow row = rowCollection.Add(rowVals);
    }
    // </Snippet1>

}
