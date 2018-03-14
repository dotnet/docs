using System;
using System.Data;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Form1: Page
{
 protected TextBox textBox1;
// <Snippet1>
void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
{
   DataGridPageChangedEventArgs page_change_args = new DataGridPageChangedEventArgs(e.CommandSource, e.NewPageIndex);
}
   
// </Snippet1>
}
