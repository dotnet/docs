// <snippet4>
using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class WebPartZoneBase_verbs : System.Web.UI.Page
{
  protected void Page_Load(Object sender, EventArgs e)
  {
    if (WebPartZone1.WebParts.Count == 0)
      Table1.Visible = false;
    else
      Table1.Visible = true;

    // Enable all verbs on the first page load.
    if (!IsPostBack)
    {
      foreach (ListItem item in CheckBoxList1.Items)
        item.Selected = true;
      CheckBoxList1_SelectedItemIndexChanged(sender, e);
    } 
  }

  // <snippet5>
  protected void CheckBoxList1_SelectedItemIndexChanged(Object sender, EventArgs e)
  {
    foreach (ListItem item in CheckBoxList1.Items)
    {
      WebPartVerb theVerb;
      switch (item.Value)
      {
        case "close":
          theVerb = WebPartZone1.CloseVerb;
          break;
        case "export":
          theVerb = WebPartZone1.ExportVerb;
          break;
        case "delete":
          theVerb = WebPartZone1.DeleteVerb;
          break;
        case "minimize":
          theVerb = WebPartZone1.MinimizeVerb;
          break;
        case "restore":
          theVerb = WebPartZone1.RestoreVerb;
          break;
        default:
          theVerb = null;
          break;
      }

      if (item.Selected)
        theVerb.Enabled = true;
      else
        theVerb.Enabled = false;
    }
  }
  // </snippet5>
}
// </snippet4>