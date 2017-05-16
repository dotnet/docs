// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlSelectOnPreRender : System.Web.UI.HtmlControls.HtmlSelect
    {
        protected override void OnPreRender(System.EventArgs e)
        {
            // Call the base's OnPreRender method.
            base.OnPreRender(e);
                
            // Allow multiple selections.
            this.Multiple = true;
        }
    }
}
// </Snippet2>
