using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
void Command_Button_Click(Object sender, CommandEventArgs e) 
{
    CommandEventArgs args = new CommandEventArgs(e);    
}
   
// </Snippet1>
}
