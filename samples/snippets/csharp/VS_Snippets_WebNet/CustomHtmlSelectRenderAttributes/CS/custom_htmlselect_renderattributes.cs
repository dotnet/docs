// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlSelectRenderAttributes : System.Web.UI.HtmlControls.HtmlSelect
    {
        protected override void RenderAttributes(System.Web.UI.HtmlTextWriter writer)
        {
            // Write out Title tag
            writer.Write(" Title=\"Text from RenderAttributes.\"");
            
            // Call the base's RenderAttributes method.
            base.RenderAttributes(writer);
        }
    }
}
// </Snippet2>
