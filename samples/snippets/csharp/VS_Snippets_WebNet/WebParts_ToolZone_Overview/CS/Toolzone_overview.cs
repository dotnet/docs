// <snippet2>
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Toolzone_overview_cs : System.Web.UI.Page
{
  protected void Button1_Click(Object sender, EventArgs e)
  {
    if(string.IsNullOrEmpty(TextBox1.Text))
      EditorZone1.InstructionText = String.Empty;
    else
      EditorZone1.InstructionText = Server.HtmlEncode(TextBox1.Text);
      TextBox1.Text = String.Empty;
  }
}
// </snippet2>