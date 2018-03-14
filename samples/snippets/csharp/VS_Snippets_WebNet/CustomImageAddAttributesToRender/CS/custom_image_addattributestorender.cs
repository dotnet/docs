// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomImageAddAttributesToRender : System.Web.UI.WebControls.Image
    {
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            // Show the Image with a thin border.
            writer.AddStyleAttribute("border-width","thin");

            // Call the Base's AddAttributesToRender method.
            base.AddAttributesToRender(writer);
        }
    }
}
// </Snippet2>
