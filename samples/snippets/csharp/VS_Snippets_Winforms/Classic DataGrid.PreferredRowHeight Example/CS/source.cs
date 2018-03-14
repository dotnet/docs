using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
// <Snippet1>
private void ChangeFontHeight(DataGrid myGrid)
{
   myGrid.Font = new System.Drawing.Font
      ("Microsoft Sans Serif",
      15, System.Drawing.FontStyle.Regular);
   myGrid.PreferredRowHeight = myGrid.Font.Height;
}

// </Snippet1>
}
