using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void GetTable(DataRow row)
    {
        // Get the DataTable of a DataRow
        DataTable table = row.Table;

        // Print the DataType of each column in the table.
        foreach(DataColumn column in table.Columns)
        {
            Console.WriteLine(column.DataType);
        }
    }
    // </Snippet1>

}
