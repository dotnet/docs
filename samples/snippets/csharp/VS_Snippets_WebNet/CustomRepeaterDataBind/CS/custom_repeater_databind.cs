// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomRepeaterDataBind : System.Web.UI.WebControls.Repeater
  {
    public override void DataBind()
    {
      // Raise the DataBinding event.
      this.OnDataBinding(System.EventArgs.Empty);
    }
  }
}
// </Snippet2>
