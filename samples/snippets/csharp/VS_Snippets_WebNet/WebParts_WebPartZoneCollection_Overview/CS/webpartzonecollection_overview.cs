// <snippet2>
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class webpartzonecollection_overview : System.Web.UI.Page
{

  protected void Button1_Click(object sender, EventArgs e)
  {
    Label1.Text = String.Empty;
    Label1.Text = "WebPartZone Count:  " + mgr.Zones.Count;
  }

  // <snippet3>
  protected void Button2_Click(object sender, EventArgs e)
  {
    Label1.Text = String.Empty;
    Label1.Text = mgr.Zones.Contains(WebPartZone2).ToString();
  }
  // </snippet3>

  // <snippet4>
  protected void Button3_Click(object sender, EventArgs e)
  {
    Label1.Text = String.Empty;
    WebPartZoneBase[] zoneArray = new WebPartZoneBase[mgr.Zones.Count];
    mgr.Zones.CopyTo(zoneArray, 0);
    Label1.Text = zoneArray[2].ID;
    Label1.Text += ", " + zoneArray[1].ID;
    Label1.Text += ", " + zoneArray[0].ID;
  }
  // </snippet4>

  // <snippet5>
  protected void Button4_Click(object sender, EventArgs e)
  {
    Label1.Text = String.Empty;
    Label1.Text = "WebPartZone1 index:  " + mgr.Zones.IndexOf(WebPartZone1);
  }
  // </snippet5>

  // <snippet6>
  protected void Button5_Click(object sender, EventArgs e)
  {
    Label1.Text = String.Empty;

    WebPartZoneCollection zoneCollection = mgr.Zones;
    foreach (WebPartZone zone in zoneCollection)
    {

      if (zone.WebPartVerbRenderMode == WebPartVerbRenderMode.Menu)
        zone.WebPartVerbRenderMode = WebPartVerbRenderMode.TitleBar;
      else
        zone.WebPartVerbRenderMode = WebPartVerbRenderMode.Menu;
    }
  }
  // </snippet6>
}
// </snippet2>