// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlInputImageRenderAttributes : System.Web.UI.HtmlControls.HtmlInputImage
    {
        protected override void RenderAttributes(System.Web.UI.HtmlTextWriter writer)
        {
            // Add an Alt attribute to the the HtmlInputImage control.
            writer.Write(" alt='Alternate text from RenderAttributes'");
            
            // Call the base class's RenderAttributes method.
            base.RenderAttributes(writer);
        }
    }
}
// </Snippet2>
