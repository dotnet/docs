using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1: Form
{
protected DataGrid myDataGrid;
protected DataSet myDataSet;
// <Snippet1>
private void EditTable(){
   DataGridTableStyle dgt= myDataGrid.TableStyles[0];
   DataGridColumnStyle myCol = dgt.GridColumnStyles[0]; 
      
   dgt.BeginEdit(myCol,1); 
   dgt.EndEdit(myCol, 1, true);
}
// </Snippet1>
}

