// <snippet8>
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public class LogOnControl:UserControl
{
	public TextBox user;
	public TextBox password;

	public Label Message;

	public void Page_Load(Object sender, EventArgs e) 
	{
		Message.Text="Welcome! Welcome to a simple User Control!";
	}

}
// </snippet8>