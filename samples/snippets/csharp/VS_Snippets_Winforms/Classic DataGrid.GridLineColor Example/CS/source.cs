using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
// <Snippet1>
private void SetGridLineColor
(DataGrid myGrid, System.Drawing.Color newcolor)
{
   myGrid.GridLineColor = newcolor;
}
   
// </Snippet1>
}
