using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
static void Main(){}

// <Snippet1>
private void SetCellValue(DataGrid myGrid){
   DataGridCell myCell = new DataGridCell();
   // Use an arbitrary cell.
   myCell.RowNumber = 1;
   myCell.ColumnNumber = 1;
   // Change the cell's value using the CurrentCell.
   myGrid[myCell]="New Value";
}
 
private void GetCellValue(DataGrid myGrid){
   DataGridCell myCell = new DataGridCell();
   // Use and arbitrary cell.
   myCell.RowNumber = 1;
   myCell.ColumnNumber = 1;
   Console.WriteLine(myGrid[myCell]);
}
    
// </Snippet1>
}
