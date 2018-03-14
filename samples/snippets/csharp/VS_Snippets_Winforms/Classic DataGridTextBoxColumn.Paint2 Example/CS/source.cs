using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
// <Snippet1>
public class Form1: Form
{
 protected DataGrid dataGrid1;
 protected DataSet myDataSet;

private void PaintCell(object sender, MouseEventArgs e)
{
    // Use the HitTest method to get a HitTestInfo object.
    DataGrid.HitTestInfo hi;
    DataGrid grid = (DataGrid)sender;
    hi=grid.HitTest(e.X, e.Y);
    // Test if the clicked area was a cell.
    if(hi.Type == DataGrid.HitTestType.Cell)
    {
       // If it's a cell, get the GridTable and ListManager of the
       // clicked table.         
       DataGridTableStyle dgt = dataGrid1.TableStyles[0];
       CurrencyManager cm = (CurrencyManager)this.BindingContext[myDataSet.Tables[dgt.MappingName]];
       // Get the Rectangle of the clicked cell.
       Rectangle cellRect;
       cellRect=grid.GetCellBounds(hi.Row, hi.Column);
       // Get the clicked DataGridTextBoxColumn.
       MyGridColumn  gridCol =(MyGridColumn)dgt.GridColumnStyles[hi.Column];
       // Get the Graphics object for the form.
       Graphics g = dataGrid1.CreateGraphics();
       // Create two new Brush objects, a fore brush, and back brush.
       Brush fBrush = new System.Drawing.SolidBrush(Color.Blue);
       Brush bBrush= new System.Drawing.SolidBrush(Color.Yellow);
       // Invoke the Paint method to paint the cell with the brushes.
       gridCol.PaintCol(g, cellRect, cm, hi.Row, bBrush, fBrush, false);
     }
 }
}

public class MyGridColumn:DataGridTextBoxColumn{
   public void PaintCol(Graphics g, Rectangle cellRect, 
   	CurrencyManager cm, int rowNum, Brush bBrush, 
   	Brush fBrush, bool isVisible){
      this.Paint(g, cellRect, cm, rowNum, bBrush, fBrush, isVisible);
   }
}
// </Snippet1>
