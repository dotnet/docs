using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{

static void Main(){}
 protected DataGrid dataGrid1;
// <Snippet1>
private void Grid_MouseUp
(object sender, System.Windows.Forms.MouseEventArgs e)
{
   DataGrid dg = (DataGrid)sender;
   DataGridCell myCell = dg.CurrentCell;
   Console.WriteLine(myCell.ToString());
}

// </Snippet1>
}
