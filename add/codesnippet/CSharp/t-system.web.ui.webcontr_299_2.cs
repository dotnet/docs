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
  public class MyEditorZone : EditorZone
  {
    public MyEditorZone()
    {
    }
    protected override void OnDisplayModeChanged(object sender, 
      WebPartDisplayModeEventArgs e)
    {
      this.BackColor = Color.LightGray;
      base.OnDisplayModeChanged(sender, e);
    }
    protected override void OnSelectedWebPartChanged(object sender, 
      WebPartEventArgs e)
    {
      if (e.WebPart != null)
        e.WebPart.Zone.SelectedPartChromeStyle.BackColor = 
          Color.LightGreen;
      base.OnSelectedWebPartChanged(sender, e);
    }
    protected override void RenderBody(HtmlTextWriter writer)
    {
      writer.WriteLine("<hr />");
      base.RenderBody(writer);
    }
    protected override void RenderVerbs(HtmlTextWriter writer)
    {
      WebPartVerb[] verbs = new WebPartVerb[] { OKVerb, 
        CancelVerb, ApplyVerb };
      foreach (WebPartVerb verb in verbs)
      {
        if (verb != null)
          verb.Text += " Verb";
      }
      base.RenderVerbs(writer);
    }
  }
}