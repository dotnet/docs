using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
 protected DataSet myDataSet;
// <Snippet1>
private void dataGrid1_MouseDown(object sender, MouseEventArgs e){
   // Use the HitTest method to get a HitTestInfo object.
   System.Windows.Forms.DataGrid.HitTestInfo hi;   
   DataGrid grid = (DataGrid) sender;
   hi=grid.HitTest(e.X, e.Y);
   // Test if the clicked area was a cell.
   if(hi.Type==DataGrid.HitTestType.Cell ) {
      // If it's a cell, get the GridTable and CurrencyManager of the
      // clicked table.         
      DataGridTableStyle dgt = dataGrid1.TableStyles[0];     
      CurrencyManager myCurrencyManager = 
      (CurrencyManager)this.BindingContext
      [myDataSet.Tables[dataGrid1.DataMember]];
      // Get the Rectangle of the clicked cell.
      Rectangle cellRect;
      cellRect=grid.GetCellBounds(hi.Row, hi.Column);
      // Get the clicked DataGridTextBoxColumn.
      DataGridTextBoxColumn gridCol =
      (DataGridTextBoxColumn) dgt.GridColumnStyles[hi.Column];
      // Insert code to edit the value.
      
   }
}

// </Snippet1>
}
