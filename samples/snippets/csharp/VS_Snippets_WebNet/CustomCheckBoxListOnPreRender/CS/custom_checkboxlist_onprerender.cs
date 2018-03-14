// <Snippet2>
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class CustomCheckBoxListOnPreRender : CheckBoxList
    {
        protected override void OnPreRender(EventArgs e)
        {
            // Run the OnPreRender method on the base class.
            base.OnPreRender(e);

            // Display the Calendar with a 3 point border.
            this.BorderWidth =  Unit.Point(3);
        }
    }
}
// </Snippet2>
