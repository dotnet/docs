// <snippet2>
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls {

  [AspNetHostingPermission (SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission (SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
  public class CustomCreateUserWizard : CreateUserWizard
  {
    private void SiteSpecificErrorLoggingProcedure (SendMailErrorEventArgs e)
    {
      // Site-specific code for logging e-mail errors goes here.
    }

    protected override void OnSendMailError (SendMailErrorEventArgs e)
    {
      this.SiteSpecificErrorLoggingProcedure (e);
      e.Handled = true;
    }
  }
}
// </snippet2>