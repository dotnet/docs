// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomTableAddAttributesToRender : System.Web.UI.WebControls.Table
  {
    protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
    {
      // Add a client-side onclick event to the button.
      writer.AddAttribute(System.Web.UI.HtmlTextWriterAttribute.Onclick, "alert('Hello World');");

      // Call the base's AddAttributesToRender method.
      base.AddAttributesToRender(writer);
    }
  }
}
// </Snippet2>
