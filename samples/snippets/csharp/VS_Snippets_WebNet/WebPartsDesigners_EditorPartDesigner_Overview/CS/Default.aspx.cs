//<snippet3>
using System;
using System.Web.UI.WebControls.WebParts;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        {
            // Make the 'Edit' verb available so the EditorZone can render
            WebPartManager mgr = WebPartManager.GetCurrentWebPartManager(Page);
            mgr.DisplayMode = mgr.SupportedDisplayModes["Edit"];
        }
    }
}
//</snippet3>