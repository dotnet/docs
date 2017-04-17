// <Snippet2>
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomTableCreateControlCollection : Table
    {
        protected override ControlCollection CreateControlCollection()
        {
            // Return a new ControlCollection
            return new ControlCollection(this);
        }
    }
}
// </Snippet2>
