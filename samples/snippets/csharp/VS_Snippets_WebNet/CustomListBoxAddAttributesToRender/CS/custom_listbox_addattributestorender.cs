// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomListBoxAddAttributesToRender : System.Web.UI.WebControls.ListBox
  {
    protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
    {
      // Show the ListItem text as Bold 
      writer.AddStyleAttribute(System.Web.UI.HtmlTextWriterStyle.FontWeight, "bold");

      // Call the Base's AddAttributesToRender method.
      base.AddAttributesToRender(writer);
    }
  }
}
// </Snippet2>
