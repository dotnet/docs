// SimpleRadioButtonList.cs
// <snippet5>
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Security.Permissions;

namespace Examples.CS.WebControls.Design
{
    // The SimpleRadioButtonList is a copy of the RadioButtonList.
    // It uses the SimpleRadioButtonListDesigner for design-time support.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(Examples.CS.WebControls.Design.
       SimpleRadioButtonListDesigner))]
    [DataBindingHandler(typeof(Examples.CS.WebControls.Design.
        SimpleRadioButtonListDataBindingHandler))]
    public class SimpleRadioButtonList : RadioButtonList
    {
    } // SimpleRadioButtonList
} // Examples.CS.WebControls.Design
// </snippet5>

