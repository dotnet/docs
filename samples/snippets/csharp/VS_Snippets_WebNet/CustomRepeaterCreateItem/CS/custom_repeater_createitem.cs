// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomRepeaterCreateItem : System.Web.UI.WebControls.Repeater
  {
    protected override System.Web.UI.WebControls.RepeaterItem CreateItem(int itemIndex, System.Web.UI.WebControls.ListItemType itemType)
    {
      // Return a new RepeaterItem with the corresponding item index and type.
      return new System.Web.UI.WebControls.RepeaterItem(itemIndex, itemType);
    }
  }
}
// </Snippet2>
