using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void SetColError(DataRow row, int columnIndex)
    {
        string errorString = "Replace this text.";

        // Set the error for the specified column of the row.
        row.SetColumnError(columnIndex, errorString);
    }
 
    private void PrintColError(DataRow row, int columnIndex)
    {
        // Print the error of a specified column.
        Console.WriteLine(row.GetColumnError(columnIndex));
    }
    // </Snippet1>

}
