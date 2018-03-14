// <snippet3> 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Security.Permissions;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand,
  Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  public class NewWebPartManager : WebPartManager 
  {
    private static readonly WebPartDisplayMode _inLineEditDisplayMode =
      new InlineWebPartEditDisplayMode();

    public NewWebPartManager() {}

    // <snippet4>
    protected override WebPartDisplayModeCollection CreateDisplayModes() 
    {
      WebPartDisplayModeCollection displayModes = 
        base.CreateDisplayModes();
      displayModes.Add(_inLineEditDisplayMode);
      return displayModes;
    }

    public WebPartDisplayMode InLineEditDisplayMode
    {
      get { return _inLineEditDisplayMode; }
    }
    // </snippet4>

    // <snippet5>
    private sealed class InlineWebPartEditDisplayMode : WebPartDisplayMode
    {
      public InlineWebPartEditDisplayMode()
        : base("Inline Edit Display")
      {
      }
      public override bool AllowPageDesign
      {
        get { return true; }
      }
      public override bool RequiresPersonalization
      {
        get { return true; }
      }
      public override bool ShowHiddenWebParts
      {
        get { return false; }
      }
      public override bool AssociatedWithToolZone
      {
        get { return false; }
      }
      public override bool IsEnabled(WebPartManager webPartManager)
      {
        return true;
      }
    }
    // </snippet5>

  }

}
// </snippet3> 