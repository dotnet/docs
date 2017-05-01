using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
// <Snippet1>
public class Form1: Form
{
protected DataGrid dataGrid1;
protected DataSet myDataSet;

private void dataGrid1_MouseDown(object sender, MouseEventArgs e)
{
    // Use the HitTest method to get a HitTestInfo object.
    DataGrid.HitTestInfo hi;   
    DataGrid grid = (DataGrid)sender;
    hi=grid.HitTest(e.X, e.Y);
    // Test if the clicked area was a cell.
    if (hi.Type == DataGrid.HitTestType.Cell)
    {
       // If it's a cell, get the GridTable and CurrencyManager of the
       // clicked table.         
       DataGridTableStyle dgt = dataGrid1.TableStyles[0];     
       CurrencyManager cm = (CurrencyManager)
       	this.BindingContext[myDataSet.Tables[dgt.MappingName]];
       // Get the Rectangle of the clicked cell.
       Rectangle cellRect = grid.GetCellBounds(hi.Row, hi.Column);
       // Get the clicked DataGridTextBoxColumn.
       MyGridColumn gridCol =
       (MyGridColumn)dgt.GridColumnStyles[hi.Column];
       // Edit the value.
       gridCol.EditCol(cm, hi.Row, cellRect, false, "New Text", true);
    }
 }
}

public class MyGridColumn:DataGridTextBoxColumn{
   public void EditCol(CurrencyManager cm, int rowNum, 
      Rectangle cellRect, bool readOnly, 
      string myString, bool isVisible){
      this.Edit(cm, rowNum, cellRect, readOnly, myString, isVisible);
   }
}
 // </Snippet1>
