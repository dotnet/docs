using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
private void Command_Button_Click(Object sender, CommandEventArgs e) 
{    
    CommandEventArgs args2 = new CommandEventArgs("Sort", "Descending");      
}
   
// </Snippet1>
}
