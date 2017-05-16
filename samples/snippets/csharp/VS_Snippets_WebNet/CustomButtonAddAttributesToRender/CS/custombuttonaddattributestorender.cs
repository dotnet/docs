// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomButtonAddAttributesToRender : System.Web.UI.WebControls.Button
    {
    protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer) 
    {
      // Add a client-side onclick event to the button.
      writer.AddAttribute(System.Web.UI.HtmlTextWriterAttribute.Onclick, "alert('Hello World');");

      // Update the text of the button to be shown in the color Red
      writer.AddStyleAttribute(System.Web.UI.HtmlTextWriterStyle.Color, "Red");

      // Call the base's AddAttributesToRender method
      base.AddAttributesToRender(writer);
    }
  }
}
// </Snippet2>