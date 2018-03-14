// <snippet2>
namespace Samples.AspNet.CS.Controls
{
  using System;
  using System.Web;
  using System.Web.Security;
  using System.Security.Permissions;
  using System.Web.UI;
  using System.Web.UI.WebControls;
  using System.Web.UI.WebControls.WebParts;

  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  public class MyManagerIDLabel : Label
  {

    protected override void OnPreRender(EventArgs e)
    {
      EnsureChildControls();

      this.Text = 
        WebPartManager.GetCurrentWebPartManager(Page).ID;
    }

  }

}
// </snippet2>