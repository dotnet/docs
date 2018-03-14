// <snippet2>
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls {
  [AspNetHostingPermission(System.Security.Permissions.SecurityAction.Demand,Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(System.Security.Permissions.SecurityAction.InheritanceDemand,Level = AspNetHostingPermissionLevel.Minimal)]
  public class CustomCreateUserWizard : CreateUserWizard {

    protected override void OnCreatingUser(LoginCancelEventArgs e) {
      this.UserName.ToLower();
      base.OnCreatingUser(e);
    }
  }
}
// </snippet2>