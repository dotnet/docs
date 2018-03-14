using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid DataGrid1;
static void Main(){}
// <Snippet1>
private void PrintCellRowAndCol()
{
   DataGridCell myCell;
   myCell = DataGrid1.CurrentCell;
   Console.WriteLine(myCell.RowNumber);
   Console.WriteLine(myCell.ColumnNumber);
   // Prints the value of the cell through the DataTable.
   DataTable myTable;
   // Assumes the DataGrid is bound to a DataTable.
   myTable = (DataTable) DataGrid1.DataSource;
   Console.WriteLine(myTable.Rows[myCell.RowNumber]
   [myCell.ColumnNumber]);
}

// </Snippet1>
}
