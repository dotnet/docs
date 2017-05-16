using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
    public class CustomAdRotatorOnPreRender : System.Web.UI.WebControls.AdRotator
    {
// <Snippet2> 
        protected override void OnPreRender(System.EventArgs e)
        {
            // Run the OnPreRender method on the base class.
            base.OnPreRender(e);

            // Always display the Ad with a border.
            this.BorderWidth =  System.Web.UI.WebControls.Unit.Point(1);
        }
// </Snippet2> 
    }
}
