// <snippet1>
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class webpartcollectioncs : System.Web.UI.Page
{
  protected void Button1_Click(object sender, EventArgs e)
  {

    WebPartCollection partCollection = mgr1.WebParts;

    foreach (WebPart part in partCollection)
    {
      if (part.ChromeState != PartChromeState.Minimized)
        part.ChromeState = PartChromeState.Minimized;
      else
        part.ChromeState = PartChromeState.Normal;
    }
  }
  protected void Button2_Click(object sender, EventArgs e)
  {
    WebPartCollection partCollection = WebPartZone1.WebParts;

    if (partCollection[0].Title == "My Link List")
      partCollection[0].Title = "Favorite Links";
    else
      partCollection[0].Title = "My Link List";
  }
}
// </snippet1>