using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
static void Main()
{}
 protected DataGrid dataGrid1;
// <Snippet1>
private void SetBackColorAndBackgroundColor(){
   // Set the BackColor and BackgroundColor properties.
   dataGrid1.BackColor = System.Drawing.Color.Blue;
   dataGrid1.BackgroundColor = System.Drawing.Color.Red;
}
// </Snippet1>
}
