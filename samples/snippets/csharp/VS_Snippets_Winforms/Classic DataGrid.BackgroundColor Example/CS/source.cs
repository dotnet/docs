using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
// <Snippet1>
private void SetGridColors(){
    dataGrid1.BackColor=System.Drawing.Color.Red;
    dataGrid1.AlternatingBackColor= System.Drawing.Color.AliceBlue;
    dataGrid1.BackgroundColor=System.Drawing.Color.Yellow;
 }
 
// </Snippet1>
}
