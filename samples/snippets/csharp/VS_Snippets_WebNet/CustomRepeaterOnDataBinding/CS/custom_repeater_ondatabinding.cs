// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomRepeaterOnDataBinding : System.Web.UI.WebControls.Repeater
  {
    protected override void OnDataBinding(System.EventArgs e)
    {
      // Raise the OnDataBinding event.
      base.OnDataBinding(e);

      // Clear out the controls collection and child viewstate.
      this.Controls.Clear();
      this.ClearChildViewState();

      // Create a new control hierarchy.
      this.CreateControlHierarchy(true);
      this.ChildControlsCreated = true;
    }
  }
}
// </Snippet2>
