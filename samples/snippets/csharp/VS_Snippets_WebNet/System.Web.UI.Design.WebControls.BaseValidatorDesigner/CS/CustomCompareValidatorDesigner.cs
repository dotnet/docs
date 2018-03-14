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
    // The SimpleCompareValidator is a copy of the CompareValidator.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(Examples.CS.WebControls.Design.
        SimpleCompareValidatorDesigner))]
    public class SimpleCompareValidator : CompareValidator
    {
    } // SimpleCompareValidator
    //</snippet2>

    // Derive a designer that inherits from the BaseValidatorDesigner.
    public class SimpleCompareValidatorDesigner : BaseValidatorDesigner
    {
        // <snippet3>
        // Make the full extent of the control more visible in the designer.
        // If the border style is None or NotSet, change the border to a 
        // solid line. 
        public override string GetDesignTimeHtml()
        {
            // Get a reference to the control or a copy of the control.
            SimpleCompareValidator myCV = (SimpleCompareValidator)ViewControl;
            string markup = null;

            // Check if the border style should be changed.
            if (myCV.BorderStyle == BorderStyle.NotSet ||
                myCV.BorderStyle == BorderStyle.None)
            {
                // Save the current property setting.
                BorderStyle oldBorderStyle = myCV.BorderStyle;

                // Set the design-time property and catch any exceptions.
                try
                {
                    myCV.BorderStyle = BorderStyle.Solid;

                    // Call the base method to generate the markup.
                    markup = base.GetDesignTimeHtml();
                }
                catch (Exception ex)
                {
                    markup = GetErrorDesignTimeHtml(ex);
                }
                finally
                {
                    // Restore the property to its original setting.
                    myCV.BorderStyle = oldBorderStyle;
                }
            }
            else
                // Call the base method to generate the markup.
                markup = base.GetDesignTimeHtml();

            return markup;

        } // GetDesignTimeHtml
        // </snippet3>
    } // SimpleCompareValidatorDesigner
} // Examples.CS.WebControls.Design
// </snippet1>

