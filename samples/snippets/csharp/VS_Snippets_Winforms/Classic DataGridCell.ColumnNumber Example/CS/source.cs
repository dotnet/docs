using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid DataGrid1;

static void Main(){}
// <Snippet1>
private void PrintCell(object sender, MouseEventArgs e)
{
   DataGrid thisGrid = (DataGrid) sender;
   DataGridCell myDataGridCell = thisGrid.CurrentCell;
   BindingManagerBase bm = BindingContext[thisGrid.DataSource, thisGrid.DataMember];
   DataRowView drv = (DataRowView) bm.Current;
   Console.WriteLine(drv [myDataGridCell.ColumnNumber]);
   Console.WriteLine(myDataGridCell.RowNumber);
}

// </Snippet1>
}
