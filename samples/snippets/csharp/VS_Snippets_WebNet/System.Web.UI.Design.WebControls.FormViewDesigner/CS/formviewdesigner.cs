// <snippet1>
using System;
using System.Web;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Web.UI.Design.WebControls;
using System.Collections;
using System.ComponentModel;
using System.Security.Permissions;

namespace Examples.CS.WebControls.Design
{
    // The MyFormView is a copy of the FormView.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(Examples.CS.WebControls.Design.MyFormViewDesigner))]
    public class MyFormView : FormView
    {
    } // MyFormView

    // Override members of the FormViewDesigner.
    public class MyFormViewDesigner : FormViewDesigner
    {
        // <snippet2>
        // Determines the number of design-time links in the pager row.
        protected override int SampleRowCount
        {
            get
            {
                // Render four links in the pager row.
                return 4;
            }
        } // SampleRowCount
        // </snippet2>

        // <snippet4>
        // Generate the design-time markup.
        const string capTag = "caption";
        const string trOpen = "tr><td colspan=9 align=center";
        const string trClose = "td></tr";

        public override string GetDesignTimeHtml()
        {
            // Make the full extent of the control more visible in the designer.
            // If the border style is None or NotSet, change the border to
            // a wide, blue, dashed line. Include the caption within the border.
            MyFormView myGV = (MyFormView)Component;
            string markup = null;
            int charX;

            // Check if the border style should be changed.
            if (myGV.BorderStyle == BorderStyle.NotSet ||
                myGV.BorderStyle == BorderStyle.None)
            {
                BorderStyle oldBorderStyle = myGV.BorderStyle;
                Unit oldBorderWidth = myGV.BorderWidth;
                Color oldBorderColor = myGV.BorderColor;

                // Set the design-time properties and catch any exceptions.
                try
                {
                    myGV.BorderStyle = BorderStyle.Dashed;
                    myGV.BorderWidth = Unit.Pixel(3);
                    myGV.BorderColor = Color.Blue;

                    // Call the base method to generate the markup.
                    markup = base.GetDesignTimeHtml();
                }
                catch (Exception ex)
                {
                    markup = GetErrorDesignTimeHtml(ex);
                }
                finally
                {
                    // Restore the properties to their original settings.
                    myGV.BorderStyle = oldBorderStyle;
                    myGV.BorderWidth = oldBorderWidth;
                    myGV.BorderColor = oldBorderColor;
                }
            }
            else
                // Call the base method to generate the markup.
                markup = base.GetDesignTimeHtml();

            // Look for a <caption> tag.
            if ((charX = markup.IndexOf(capTag)) > 0)
            {
                // Replace the first caption with 
                // "tr><td colspan=9 align=center".
                // It is okay if the colspan exceeds the 
                // number of columns in the table.
                markup = markup.Remove(charX,
                    capTag.Length).Insert(charX, trOpen);

                // Replace the second caption with "td></tr".
                if ((charX = markup.IndexOf(capTag, charX)) > 0)
                    markup = markup.Remove(charX,
                        capTag.Length).Insert(charX, trClose);
            }
            return markup;

        } // GetDesignTimeHtml
        // </snippet4>
    } // MyFormViewDesigner
} // Examples.CS.WebControls.Design
// </snippet1>
