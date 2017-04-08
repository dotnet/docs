using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
static void Main(){}
 protected DataGrid dataGrid1;
// <Snippet1>
private void SetCell()
{
   // Set the focus to the cell specified by the DataGridCell.
   DataGridCell dc = new DataGridCell();
   dc.RowNumber = 1;
   dc.ColumnNumber = 1;
   dataGrid1.CurrentCell = dc;
}

// </Snippet1>
}
