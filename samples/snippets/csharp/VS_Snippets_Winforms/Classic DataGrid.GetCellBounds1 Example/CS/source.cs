using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
// <Snippet1>
protected DataGridCell dgc;

protected void GetRect(){
    Rectangle rect;
    dgc.ColumnNumber = 0;
    dgc.RowNumber = 0;
    rect = dataGrid1.GetCellBounds(dgc);
    Console.WriteLine(rect.ToString());
 }
 
// </Snippet1>
}
