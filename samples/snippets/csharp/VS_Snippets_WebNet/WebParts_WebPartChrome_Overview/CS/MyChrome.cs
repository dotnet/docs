// <snippet2>
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  public class MyZone : WebPartZone
  {
    private Boolean _renderVerbsInMenu;

    protected override WebPartChrome CreateWebPartChrome()
    {
      WebPartChrome theChrome = new MyWebPartChrome(this, 
        this.WebPartManager);
      if (RenderVerbsInMenu)
        this.WebPartVerbRenderMode = WebPartVerbRenderMode.Menu;
      else
        this.WebPartVerbRenderMode = WebPartVerbRenderMode.TitleBar;
      return theChrome;
    }

    public Boolean RenderVerbsInMenu
    {
      get { return _renderVerbsInMenu; }
      set { _renderVerbsInMenu = value; }
    }
  }

  
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  public class MyWebPartChrome : WebPartChrome
  {
    WebPartZoneBase theZone;
    WebPartManager theManager;

    // <snippet3>
    public MyWebPartChrome(WebPartZoneBase aZone, WebPartManager aManager) : 
      base(aZone, aManager)
    {
      theZone = aZone;
      theManager = aManager;
    }
    // </snippet3>

    // <snippet4>
    protected override WebPartVerbCollection GetWebPartVerbs(WebPart webPart)
    {
      ArrayList verbSet = new ArrayList();
      foreach (WebPartVerb verb in base.GetWebPartVerbs(webPart))
      {
        if (verb.Text != "Close")
          verbSet.Add(verb);
      }
      WebPartVerbCollection reducedVerbSet = 
        new WebPartVerbCollection(verbSet);
      return reducedVerbSet;
    }
    // </snippet4>

    // <snippet5>
    protected override Style CreateWebPartChromeStyle(WebPart part, 
      PartChromeType chromeType)
    {
      Style finalStyle = new Style();
      finalStyle.CopyFrom(base.CreateWebPartChromeStyle(part, chromeType));
      finalStyle.Font.Name = "Verdana";
      return finalStyle;
    }
    // </snippet5>

    // <snippet6>
    protected override void RenderPartContents(HtmlTextWriter writer, 
      WebPart part)
    {

        if (part == this.WebPartManager.SelectedWebPart)
          HttpContext.Current.Response.Write("<span>Not rendered</span>");
        else
          if(this.Zone.GetType() == typeof(MyZone))
            part.RenderControl(writer);
    }
    // </snippet6>

  }
}
// </snippet2>