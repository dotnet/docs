using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
// <Snippet1>
public class Form1: Form
{
 protected DataGrid dataGrid1;

private void GetHeight(){
    MyGridColumn myGridColumn;
    // Get a DataGridColumnStyle of a DataGrid control.
    myGridColumn = (MyGridColumn) dataGrid1.TableStyles[0].
    GridColumnStyles["CompanyName"];
    // Create a Graphics object.
    Graphics g = this.CreateGraphics();
    Size s =myGridColumn.GetPrefSize(g, "A string");
 }
}

public class MyGridColumn:DataGridTextBoxColumn{
   public Size GetPrefSize(Graphics g, string thisString){
      return this.GetPreferredSize(g,thisString);
   }
}
// </Snippet1>
