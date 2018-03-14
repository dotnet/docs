// <snippet2>
using System;
using System.Security.Permissions;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, 
    Level=AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
    Level=AspNetHostingPermissionLevel.Minimal)]
  public class TextDisplayWebPart : WebPart
  {
    private String _contentText = null;
    TextBox input;
    Label DisplayContent;

    public TextDisplayWebPart()
    {
      this.AllowClose = false;
    }

    [Personalizable(), WebBrowsable]
    public String ContentText
    {
      get { return _contentText; }
      set { _contentText = value; }
    }

    protected override void CreateChildControls()
    {
      Controls.Clear();
      DisplayContent = new Label();
      DisplayContent.BackColor = 
        System.Drawing.Color.LightBlue;
      DisplayContent.Text = this.ContentText;
      this.Controls.Add(DisplayContent);
      input = new TextBox();
      this.Controls.Add(input);
      Button update = new Button();
      update.Text = "Set Label Content";
      update.Click += new EventHandler(this.submit_Click);
      this.Controls.Add(update);
      ChildControlsCreated = true;
    }

    private void submit_Click(object sender, EventArgs e)
    {
      // Update the label string.
      if (input.Text != String.Empty)
      {
        _contentText = input.Text + @"<br />";
        input.Text = String.Empty;
        DisplayContent.Text = this.ContentText;
      }
    }
  }
}
// </snippet2>