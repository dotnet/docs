using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void PrintDataType(DataTable table)
    {
        // Get the DataColumnCollection from a DataTable in a DataSet.
        DataColumnCollection columns = table.Columns;

        // Print the column's data type.
        Console.WriteLine(columns["id"].DataType);
    }
    // </Snippet1>

}
