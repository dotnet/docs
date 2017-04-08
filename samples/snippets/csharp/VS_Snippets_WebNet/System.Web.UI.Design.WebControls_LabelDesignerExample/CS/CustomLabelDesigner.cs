// CustomLabelDesigner.cs
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
    // The SampleLabel is a copy of the Label.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(Examples.CS.WebControls.Design.SampleLabelDesigner))]
    public class SampleLabel : Label
    {
    } // SampleLabel
    // </snippet2>

    // Override members of the LabelDesigner.
    public class SampleLabelDesigner : LabelDesigner
    {
        // <snippet3>
        // Generate the design-time markup.
        public override string GetDesignTimeHtml()
        {
            // Make the control more visible in the designer.  If the border 
            // style is None or NotSet, change the border to a dashed line. 
            SampleLabel sampleLabel = (SampleLabel)Component;
            string designTimeMarkup = null;

            // Check if the border style should be changed.
            if (sampleLabel.BorderStyle == BorderStyle.NotSet ||
                sampleLabel.BorderStyle == BorderStyle.None)
            {
                BorderStyle oldBorderStyle = sampleLabel.BorderStyle;

                try
                {
                    // Set the design-time BorderStyle.
                    sampleLabel.BorderStyle = BorderStyle.Dashed;

                    // Call the base method to generate the markup.
                    designTimeMarkup = base.GetDesignTimeHtml();
                }
                catch (Exception ex)
                {
                    // If an exception occurs, generate an error message.
                    designTimeMarkup = GetErrorDesignTimeHtml(ex);
                }
                finally
                {
                    // Restore the BorderStyle to its original setting.
                    sampleLabel.BorderStyle = oldBorderStyle;
                }
            }
            else
                // Call the base method to generate the markup.
                designTimeMarkup = base.GetDesignTimeHtml();

            return designTimeMarkup;
        } // GetDesignTimeHtml
        // </snippet3>
    } // SampleLabelDesigner
} // Examples.CS.WebControls.Design
// </snippet1>

