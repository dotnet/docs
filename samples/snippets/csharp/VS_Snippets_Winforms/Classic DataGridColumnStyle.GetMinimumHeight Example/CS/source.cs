using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

// <Snippet1>
public class Form1: Form
{
 protected DataGrid dataGrid1;

private void GetHeight(){
    MyGridColumn myGridColumn = (MyGridColumn)dataGrid1.TableStyles[1].GridColumnStyles[0];
    Console.WriteLine(myGridColumn.GetMinHeight());
 }
}

public class MyGridColumn:DataGridBoolColumn{
   public int GetMinHeight(){
   return this.GetMinimumHeight();
   }
}

// </Snippet1>
