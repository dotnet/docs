// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomCalendarOnPreRender : System.Web.UI.WebControls.Calendar
    {
        protected override void OnPreRender(System.EventArgs e)
        {
            // Run the OnPreRender method on the base class.
            base.OnPreRender(e);

            // Display the Calendar with a 3 point border.
            this.BorderWidth =  System.Web.UI.WebControls.Unit.Point(3);
        }
    }
}
// </Snippet2>