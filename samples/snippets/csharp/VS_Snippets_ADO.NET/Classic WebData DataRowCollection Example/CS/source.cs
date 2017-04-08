using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void ShowRows(DataTable table)
    {
        // Print the number of rows in the collection.
        Console.WriteLine(table.Rows.Count);
        // Print the value of columns 1 in each row
        foreach(DataRow row in table.Rows)
        {
            Console.WriteLine(row[1]);
        }
    }
 
    private void AddRow(DataTable table)
    {
        DataRowCollection rowCollection = table.Rows;
        // Instantiate a new row using the NewRow method.

        DataRow newRow = table.NewRow();
        // Insert code to fill the row with values.

        // Add the row to the DataRowCollection.
        table.Rows.Add(newRow);
    }
    // </Snippet1>

}
