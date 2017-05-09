using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
// <Snippet1>
public class Form1: Form
{
 protected DataGrid dataGrid1;

private void GetPreferredSize(){
   Graphics g;
   g = this.CreateGraphics();
   Size gridPreferredSize;
   MyGridColumn myTextColumn;
    // Assuming column 1 of a DataGrid control is a 
    // DataGridTextBoxColumn.
   myTextColumn = (MyGridColumn)
   dataGrid1.TableStyles[0].GridColumnStyles[1];
   string myVal;
   myVal = "A long string value";
   gridPreferredSize = myTextColumn.GetPrefSize(g, myVal);
   Console.WriteLine(gridPreferredSize);
   }
}

public class MyGridColumn:DataGridTextBoxColumn{
   public Size GetPrefSize(Graphics g, string val){
      return this.GetPreferredSize(g, val);
   }
}
// </Snippet1>
