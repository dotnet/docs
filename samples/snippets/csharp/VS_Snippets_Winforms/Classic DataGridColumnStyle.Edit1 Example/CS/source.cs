using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
// <Snippet1>
public class Form1: Form
{
static void Main(){}

protected DataSet myDataSet;

private void dataGrid1_MouseDown(object sender, MouseEventArgs e)
{
    // Use the HitTest method to get a HitTestInfo object.
    System.Windows.Forms.DataGrid.HitTestInfo hi;   
    DataGrid grid = (DataGrid) sender;
    hi=grid.HitTest(e.X, e.Y);
    // Test if the clicked area was a cell.
    if (hi.Type==DataGrid.HitTestType.Cell)
    {
       // If it's a cell, get the GridTable and CurrencyManager of the
       // clicked table.         
       DataGridTableStyle dgt = grid.TableStyles[0];     
       CurrencyManager myCurrencyManager = (CurrencyManager)
       	this.BindingContext[myDataSet.Tables[dgt.MappingName]];
       // Get the Rectangle of the clicked cell.
       Rectangle cellRect;
       cellRect=grid.GetCellBounds(hi.Row, hi.Column);
       // Get the clicked DataGridTextBoxColumn.
       MyColumnStyle gridCol =(MyColumnStyle) 
       dgt.GridColumnStyles[hi.Column];
       // Edit the value.
       gridCol.EditVal(myCurrencyManager, hi.Row, cellRect, false, "New Text");
    }
 }

public class MyColumnStyle:DataGridTextBoxColumn{
	public void EditVal(CurrencyManager cm, int row, Rectangle rec, 
	bool readOnly, string text){
		this.Edit(cm, row, rec, readOnly, text);
	}
}
}
// </Snippet1>

