using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
// <Snippet1>
private void SetCellWithFocus(DataGrid myGrid)
 {
    // Set the current cell to cell1, row 1.
    myGrid.CurrentCell = new DataGridCell(1,1);
 }
 
 private void dataGrid1_GotFocus(object sender, EventArgs e)
 {
    Console.WriteLine(dataGrid1.CurrentCell.ColumnNumber + 
    " " + dataGrid1.CurrentCell.RowNumber);
 }
    
// </Snippet1>
}
