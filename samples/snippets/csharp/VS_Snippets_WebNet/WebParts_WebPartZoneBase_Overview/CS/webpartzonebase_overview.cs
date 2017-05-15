// <snippet4>
using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class WebPartZoneBase_overview : System.Web.UI.Page
{
  // <snippet5>
  protected void Page_Load(Object sender, EventArgs e)
  {
    Label1.Text = DateTime.Now.ToLongDateString();
    Label2.Text = String.Empty;
  }
  // </snippet5>

  // <snippet6>
  protected void Button1_Click(object sender, EventArgs e)
  {
    if (WebPartZone2.VerbButtonType == ButtonType.Button)
      WebPartZone2.VerbButtonType = ButtonType.Link;
    else
      WebPartZone2.VerbButtonType = ButtonType.Button;
  }
  // </snippet6>

  // <snippet7>
  protected void Button2_Click(object sender, EventArgs e)
  {
    if (WebPartZone1.LayoutOrientation == Orientation.Vertical)
      WebPartZone1.LayoutOrientation = Orientation.Horizontal;
    else
      WebPartZone1.LayoutOrientation = Orientation.Vertical;
    Page_Load(sender, e);
  }
  // </snippet7>

  // <snippet8>
  protected void Button3_Click(object sender, EventArgs e)
  {
    StringBuilder builder = new StringBuilder();
    builder.AppendLine(@"<strong>WebPartZone1 WebPart IDs</strong><br />");
    foreach (WebPart part in WebPartZone1.WebParts)
    {
      builder.AppendLine("ID: " + part.ID 
                          + "; Type:  " + part.GetType() 
                          + @"<br />");
    }
    Label2.Text = builder.ToString();
    Label2.Visible = true;
  }
  // </snippet8>

  // <snippet9>
  protected void Button4_Click(object sender, EventArgs e)
  {
    StringBuilder builder = new StringBuilder();
    builder.AppendLine(@"<strong>WebPartZone1 DisplayTitle Property</strong><br />");
    builder.AppendLine(WebPartZone1.DisplayTitle + @"<br />");
    Label2.Text = builder.ToString();
    Label2.Visible = true;
  }
  // </snippet9>
}
// </snippet4>