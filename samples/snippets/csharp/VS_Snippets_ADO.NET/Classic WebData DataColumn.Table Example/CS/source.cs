using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void GetTable(DataColumn column)
    {
        // Get the Table of the column.
        DataTable table = column.Table;
        Console.WriteLine("columns count: " + table.Columns.Count);
        Console.WriteLine("rows count: " + table.Rows.Count);
    }
    // </Snippet1>

}
