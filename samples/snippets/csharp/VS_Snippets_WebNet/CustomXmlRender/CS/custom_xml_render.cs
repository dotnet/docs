// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomXmlRender : System.Web.UI.WebControls.Xml
  {
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
      // Create and render a new Image web control.
      System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
      image.ID = "Image1";
      image.ImageUrl = "image.jpg";	
      image.AlternateText = "Image for XML.";
      image.RenderControl(writer);

      // Call the base class's Render method.
      base.Render(writer);
    }
  }
}
// </Snippet2>
