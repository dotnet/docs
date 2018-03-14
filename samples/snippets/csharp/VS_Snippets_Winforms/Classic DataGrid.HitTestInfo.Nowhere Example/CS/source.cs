using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
// <Snippet1>
private void dataGrid1_MouseDown
(object sender, System.Windows.Forms.MouseEventArgs e)
{
   if(dataGrid1.HitTest(e.X,e.Y).Equals (DataGrid.HitTestInfo.Nowhere)) 
   {
      Console.WriteLine("Nowhere");
   }
}
   
// </Snippet1>
}
