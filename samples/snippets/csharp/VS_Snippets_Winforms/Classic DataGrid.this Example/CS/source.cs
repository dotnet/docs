using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
static void Main(){}
// <Snippet1>
private void PrintCellValues(DataGrid myGrid){
    int iRow;
    int iCol;
    DataTable myTable;
    // Assumes the DataGrid is bound to a DataTable.
    myTable = (DataTable) dataGrid1.DataSource;
    for(iRow = 0;iRow < myTable.Rows.Count ;iRow++) {
       for(iCol = 0;iCol < myTable.Columns.Count ;iCol++) {
          Console.WriteLine(myGrid[iRow, iCol]);
       }
    }
 }
    
// </Snippet1>
}
