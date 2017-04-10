using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void PrintColumnDetails(DataColumn column)
    {
        // Print the Ordinal, ColumnName, and 
        // DataType of the column.
        Console.WriteLine(column.Ordinal);
        Console.WriteLine(column.ColumnName);
        Console.WriteLine(column.DataType);
    }
    // </Snippet1>

}
