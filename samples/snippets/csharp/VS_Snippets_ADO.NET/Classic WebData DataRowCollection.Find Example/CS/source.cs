using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void FindInPrimaryKeyColumn(DataTable table, 
        long pkValue)
    {
        // Find the number pkValue in the primary key 
        // column of the table.
        DataRow foundRow = table.Rows.Find(pkValue);

        // Print the value of column 1 of the found row.
        if(foundRow != null)
            Console.WriteLine(foundRow[1]);
    }
    // </Snippet1>

}
