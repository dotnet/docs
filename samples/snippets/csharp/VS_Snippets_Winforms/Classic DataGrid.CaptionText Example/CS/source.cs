using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;

 protected void Method()
 {
// <Snippet1>
if(dataGrid1.CaptionText == "")
dataGrid1.CaptionText = "Microsoft DataGrid";

// </Snippet1>
 }
}
