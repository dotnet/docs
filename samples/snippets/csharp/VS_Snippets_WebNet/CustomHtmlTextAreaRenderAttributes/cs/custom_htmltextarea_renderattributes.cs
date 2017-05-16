// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlTextAreaRenderAttributes : System.Web.UI.HtmlControls.HtmlTextArea
    {
        protected override void RenderAttributes(System.Web.UI.HtmlTextWriter writer)
        {
            // Write out the Title attribute.
            writer.Write(" Title=\"Text from RenderAttributes.\"");
            
            // Call the base class's RenderAttributes method.
            base.RenderAttributes(writer);
        }
    }
}
// </Snippet2>
