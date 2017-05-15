using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void DataGrid1_Click(object sender, 
        System.EventArgs e)
    {
        // Get the DataTable the grid is bound to.
        DataGrid thisGrid = (DataGrid) sender;
        DataTable table = (DataTable) thisGrid.DataSource;
        DataRow currentRow = 
            table.Rows[thisGrid.CurrentCell.RowNumber];

        // Get the value of the column 1 in the DataTable.
        Console.WriteLine(currentRow[1]);
        // You can also use the name of the column:
        // Console.WriteLine(currentRow["FirstName"])
    }
 
    private void SetDataRowValue(DataGrid grid, object newValue)
    {
        // Set the value of the last column in the last row of a DataGrid.
        DataTable table;
        table = (DataTable) grid.DataSource;
        DataRow row;

        // Get last row
        row = (DataRow)table.Rows[table.Rows.Count-1];

        // Set value of last column
        row[table.Columns.Count-1] = newValue;
    }
    // </Snippet1>

}
