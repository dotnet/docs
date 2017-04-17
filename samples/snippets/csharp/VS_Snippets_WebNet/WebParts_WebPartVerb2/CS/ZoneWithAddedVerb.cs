//<SNIPPET3>
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Security.Permissions;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Samples.AspNet.CS.Controls
{
/* 
This code sample creates a Web Part zone and adds the 
"Copy Web Part" verb to any control in the zone.
*/
[AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
[AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
public class ZoneWithAddedVerb : WebPartZone
{

  protected override void OnCreateVerbs(WebPartVerbsEventArgs e)
  {
    List<WebPartVerb> newVerbs = new List<WebPartVerb>();
    newVerbs.Add(new CopyWebPartVerb(CopyWebPartToNewOne));
    e.Verbs = new WebPartVerbCollection(e.Verbs,newVerbs);
    base.OnCreateVerbs(e);
  }

  void CopyWebPartToNewOne(object sender, WebPartEventArgs e)
  {
    WebPartManager wpmgr = 
      WebPartManager.GetCurrentWebPartManager(Page);
    System.Web.UI.WebControls.WebParts.WebPart wp;
    Type tp = e.WebPart.GetType(); 
    wp = (System.Web.UI.WebControls.WebParts.WebPart)Activator.CreateInstance(tp);   
    wpmgr.AddWebPart(wp, e.WebPart.Zone, e.WebPart.ZoneIndex + 1);
  }
}
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  internal class CopyWebPartVerb : WebPartVerb
  {
    private const String _copyWebPartImageUrl = "~/CopyVerb.ico";

    internal CopyWebPartVerb(WebPartEventHandler serverClickHandler) :  
       base("MyVerb", serverClickHandler)
    { }
    public override string Text
    {
      get { return "Copy Web Part"; }
      set { ;}
    }
    public override string Description
    {
      get { return "This verb will copy this web part control " +
        "to a new one below"; }
      set { ; }
    }
    public override bool Enabled
    {
      get { return base.Enabled; }
      set { base.Enabled = value; }
    }
    
    public override string ImageUrl
    {
      get { return _copyWebPartImageUrl; }
      set { ; }
    }
  }
}
//</SNIPPET3>