using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid DataGrid1;


    // <Snippet1>
    private void DataGrid1_Click(object sender, System.EventArgs e)
    {
        // Set the current row using the RowNumber 
        // property of the CurrentCell.
        DataRow currentRow =
            ((DataTable)(DataGrid1.DataSource)).
            Rows[DataGrid1.CurrentCell.RowNumber];

        // Print the current value of the column named "FirstName."
        Console.WriteLine(currentRow["FirstName", 
            DataRowVersion.Current]);
    }
    // </Snippet1>

}
