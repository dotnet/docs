// <snippet2>
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public class SimpleControl:UserControl
{

  public TextBox name;
  public Label output;
  public Button myButton;

  public void myButton_Click(object sender, EventArgs e)
  { 
    output.Text = "Hello, " + name.Text + ".";

  }
 
}
// </snippet2>