// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlInputImageOnPreRender : System.Web.UI.HtmlControls.HtmlInputImage
    {
        protected override void OnPreRender(System.EventArgs e)
        {
            // Call the base class's OnPreRender method.
            base.OnPreRender(e);
            
            // Always display the HtmlInputImage control with no border.
            this.Border = 0;
        }
    }
}
// </Snippet2>
