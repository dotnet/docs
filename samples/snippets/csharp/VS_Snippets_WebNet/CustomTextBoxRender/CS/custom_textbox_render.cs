// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomTextBoxRender : System.Web.UI.WebControls.TextBox
  {
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
      // Create and render a new Image Web control.
      System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
      image.ID = "Image1";
      image.ImageUrl = "image.jpg";	
      image.AlternateText = "Image for TextBox1.";
      image.RenderControl(writer);

      // Create a BR tag.
      writer.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Br);

      // Call the base class's Render method.
      base.Render(writer);
    }
  }
}
// </Snippet2>
