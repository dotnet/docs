// CustomHyperLink.cs
// <snippet3>
using System.Web;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Security.Permissions;

namespace Examples.CS.WebControls.Design
{
    // The CustomHyperLink is a copy of the HyperLink.
    // It uses the CustomHyperLinkDesigner for design-time support. 
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(Examples.CS.WebControls.Design.
        CustomHyperLinkDesigner))]
    public class CustomHyperLink : HyperLink
    {
    } // CustomHyperLink
} // Examples.CS.WebControls.Design
// </snippet3>

