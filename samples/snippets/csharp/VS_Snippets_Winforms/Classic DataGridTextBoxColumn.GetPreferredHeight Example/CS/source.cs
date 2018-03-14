using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
// <Snippet1>
public class Form1: Form
{
 protected DataGrid dataGrid1;

private void GetPreferredHeight(){
   Graphics g;
   g = this.CreateGraphics();
   int gridPreferredHeight;
   MyGridColumn myTextColumn;
    // Assuming column 1 of a DataGrid control is a 
    // DataGridTextBoxColumn.
   myTextColumn = (MyGridColumn)
   dataGrid1.TableStyles[0].GridColumnStyles[1];
   string myVal;
   myVal = "A long string value";
   gridPreferredHeight= myTextColumn.GetPrefHeight(g, myVal);
   Console.WriteLine(gridPreferredHeight);
   }
}

public class MyGridColumn:DataGridTextBoxColumn{
   public int GetPrefHeight(Graphics g, string val){
      return this.GetPreferredHeight(g, val);
   }
}
// </Snippet1>
