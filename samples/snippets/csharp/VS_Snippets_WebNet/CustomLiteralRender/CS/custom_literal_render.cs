// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomLiteralRender : System.Web.UI.LiteralControl
  {
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
      // Write out some literal text.
      writer.Write("Literal Text: ");
      
      // Call the base Render method.
      base.Render(writer);
    }
  }
}
// </Snippet2>
