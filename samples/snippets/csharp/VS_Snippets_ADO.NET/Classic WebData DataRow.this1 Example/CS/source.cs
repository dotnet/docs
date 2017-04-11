using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void DataGrid1_Click(
        object sender, System.EventArgs e)
    {
        // Get the DataTable the grid is bound to.
        DataGrid thisGrid = (DataGrid) sender;
        DataTable table = (DataTable) thisGrid.DataSource;
        DataRow currentRow = 
            table.Rows[thisGrid.CurrentCell.RowNumber];

        // Get the value of the column 1 in the DataTable.
        Console.WriteLine(currentRow["FirstName"]);
        // You can also use the index:
        // Console.WriteLine(currentRow[1]);
    }
 
    private void SetDataRowValue(
        DataGrid grid, object newValue)
    {
        // Set the value of the first column in 
        // the last row of a DataGrid.
        DataTable table = (DataTable) grid.DataSource;
        DataRow row = table.Rows[table.Rows.Count-1];
        row["FirstName"] = newValue;
    }
    // </Snippet1>

}
