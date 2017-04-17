// <snippet1>
using System;
using System.Web;
using System.Security.Permissions;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.Design.WebControls.WebParts;
using System.ComponentModel;

/// <summary>
/// The PrettyPartManager class is an inherited copy of WebPartManager for
/// the purpose of applying the PrettyPartManagerDesigner at design time.
/// PrettyPartManager provides an arbitrary design time rendering of the
/// control by overriding GetDesignTimeHtml()
/// </summary>
namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(PrettyPartManagerDesigner))]
    public class PrettyPartManager : WebPartManager {}

    public class PrettyPartManagerDesigner : WebPartManagerDesigner
    {
        public override string GetDesignTimeHtml()
        {
            string designTimeHtml = "";
            designTimeHtml = "<div style=\"background-color:bisque;";
            designTimeHtml += "border:thick groove mediumseagreen\">";
            designTimeHtml += "<span style=\"font:italic 16pt bold Garamond\">";
            designTimeHtml += "PrettyPartManager</span><br />";
            designTimeHtml += "<span style=\"font:italic 12pt Garamond\">";
            WebPartManager m = (WebPartManager)Component;
            designTimeHtml += m.ID;
            designTimeHtml += "</ span></ div>";
            return designTimeHtml;
        }
    }
}
//</snippet1>