using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
// <Snippet1>
private void GetDataGrid(DataGridTableStyle thisColumn){
    DataGrid myDataGrid;
    
    // Get the DataGrid of the column.
    myDataGrid = thisColumn.DataGrid;
 }

// </Snippet1>
}
