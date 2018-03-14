// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlInputButtonOnPreRender : System.Web.UI.HtmlControls.HtmlInputButton
    {
        protected override void OnPreRender(System.EventArgs e)
        {
            // Call the base class's OnPreRender method.
            base.OnPreRender(e);

            // Always display the HtmlInputButton with bold text.
            this.Style.Add("font-weight", "bold");
        }
    }
}
// </Snippet2>
