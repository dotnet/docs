// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlTextAreaOnPreRender : System.Web.UI.HtmlControls.HtmlTextArea
    {
        protected override void OnPreRender(System.EventArgs e)
        {
            // Call the base class's OnPreRender method.
            base.OnPreRender(e);
            
            // Always display this control with 5 rows and 75 columns.
            this.Rows = 5;
            this.Cols = 75;
        }
    }
}
// </Snippet2>
