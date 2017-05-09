using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void PrintColumns(DataTable table)
    {
        // Print the default string of each column in a collection.
        foreach(DataColumn column in table.Columns)
        {
            Console.WriteLine(column.ToString());
        }
    }
    // </Snippet1>

}
