using System;
using System.Web.UI.WebControls.WebParts;

public partial class _Default : System.Web.UI.Page 
{
    //<snippet1>
    protected void Page_Load(object sender, EventArgs e)
    {
        GenericWebPart gwp = (GenericWebPart) Control1.Parent;
        gwp.ExportMode = WebPartExportMode.All;
    } 
    //</snippet1>
}

