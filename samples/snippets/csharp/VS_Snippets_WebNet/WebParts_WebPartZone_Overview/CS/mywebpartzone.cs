// <snippet3>
using System;
using System.Collections;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, 
    Level=AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
    Level=AspNetHostingPermissionLevel.Minimal)]
  public class MyWebPartZone : WebPartZone
  {
    public MyWebPartZone()
    {
      base.VerbButtonType = ButtonType.Button;
      base.CloseVerb.Enabled = false;
    }
  }
}
// </snippet3>
