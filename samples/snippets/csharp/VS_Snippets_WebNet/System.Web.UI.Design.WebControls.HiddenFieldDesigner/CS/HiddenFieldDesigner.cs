// <snippet1>
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.Design.WebControls;
using System.ComponentModel;
using System.Security.Permissions;

namespace Examples.CS.WebControls.Design
{
    // <snippet2>
    // The MyHiddenField is a copy of the HiddenField.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(Examples.CS.WebControls.Design.MyHiddenFieldDesigner))]
    public class MyHiddenField : HiddenField
    {
    } // MyHiddenField
    //</snippet2>

    // Derive a designer that inherits from the HiddenFieldDesigner.
    public class MyHiddenFieldDesigner : HiddenFieldDesigner
    {
        // <snippet3>
        // Generate the design-time markup.
        public override string GetDesignTimeHtml()
        {
            // Get a reference to the control or a copy of the control.
            MyHiddenField myHF = (MyHiddenField)ViewControl;

            // Create a placeholder that displays the control value.
            string markup = CreatePlaceHolderDesignTimeHtml(
                 "Value: \"" + myHF.Value.ToString() + "\"" );

            return markup;

        } // GetDesignTimeHtml
        // </snippet3>
    } // MyHiddenFieldDesigner
} // Examples.CS.WebControls.Design
// </snippet1>

