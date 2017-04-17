using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
// <Snippet1>
private void dataGrid1_CurrentCellChange(object sender, EventArgs e)
 {
    Rectangle rect;
    rect = dataGrid1.GetCurrentCellBounds();
    Console.WriteLine(rect.ToString());
 }
 
// </Snippet1>
}
