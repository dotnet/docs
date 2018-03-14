// <Snippet2>
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class CustomImageButtonOnPreRender : ImageButton
    {
        protected override void OnPreRender(EventArgs e)
        {
            // Run the OnPreRender method on the base class.
            base.OnPreRender(e);

            // Always display the ImageButton with a thin border.
            this.BorderWidth =  Unit.Point(1);
        }
    }
}
// </Snippet2>
