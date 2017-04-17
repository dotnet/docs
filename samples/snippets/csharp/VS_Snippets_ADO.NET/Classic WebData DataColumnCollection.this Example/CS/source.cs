using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void PrintColumnNamesByIndex(DataTable table)
    {
        // Get the DataColumnCollection from a DataTable in a DataSet.
        DataColumnCollection columns = table.Columns;

        // Print each column's name using the Index.
        for (int i = 0 ;i <columns.Count ;i++)
            Console.WriteLine(columns[i]);
    }
    // </Snippet1>

}
