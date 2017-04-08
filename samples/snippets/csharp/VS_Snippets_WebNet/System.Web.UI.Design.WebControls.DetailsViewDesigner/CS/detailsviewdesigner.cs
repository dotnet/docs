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
    // The MyDetailsView is a copy of the DetailsView.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(Examples.CS.WebControls.Design.MyDetailsViewDesigner))]
    public class MyDetailsView : DetailsView
    {
    } // MyDetailsView

    // Override members of the DetailsViewDesigner.
    [ReflectionPermission(SecurityAction.Demand, Flags=ReflectionPermissionFlag.MemberAccess)]
    public class MyDetailsViewDesigner : DetailsViewDesigner
    {
        // <snippet2>
        // Determines the number of page links in the pager row
        // when viewed in the designer.
        protected override int SampleRowCount
        {
            get
            {
                // Render five page links in the pager row.
                return 5;
            }
        } // SampleRowCount
        // </snippet2>

        // <snippet3>
        // Shadow the control properties with design-time properties.
        protected override void PreFilterProperties(IDictionary properties)
        {
            // Call the base method first.
            base.PreFilterProperties(properties);

            // Make the NamingContainer visible in the Properties grid.
            PropertyDescriptor selectProp = 
                (PropertyDescriptor)properties["NamingContainer"];
            properties["NamingContainer"] =
                TypeDescriptor.CreateProperty(selectProp.ComponentType, 
                    selectProp, BrowsableAttribute.Yes);
        } // PreFilterProperties
        // </snippet3>

        // <snippet4>
        // Generate the design-time markup.
        const string capTag = "caption";
        const string trOpen = "tr><td colspan=2 align=center";
        const string trClose = "td></tr";

        public override string GetDesignTimeHtml()
        {
            // Make the full extent of the control more visible in the designer.
            // If the border style is None or NotSet, change the border to
            // a wide, blue, dashed line. Include the caption within the border.
            MyDetailsView myDV = (MyDetailsView)Component;
            string markup = null;
            int charX;

            // Check if the border style should be changed.
            if (myDV.BorderStyle == BorderStyle.NotSet ||
                myDV.BorderStyle == BorderStyle.None)
            {
                BorderStyle oldBorderStyle = myDV.BorderStyle;
                Unit oldBorderWidth = myDV.BorderWidth;
                Color oldBorderColor = myDV.BorderColor;

                // Set design-time properties and catch any exceptions.
                try
                {
                    myDV.BorderStyle = BorderStyle.Dashed;
                    myDV.BorderWidth = Unit.Pixel(3);
                    myDV.BorderColor = Color.Blue;

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
                    myDV.BorderStyle = oldBorderStyle;
                    myDV.BorderWidth = oldBorderWidth;
                    myDV.BorderColor = oldBorderColor;
                }
            }
            else
                // Call the base method to generate the markup.
                markup = base.GetDesignTimeHtml();

            // Look for a <caption> tag.
            if ((charX = markup.IndexOf(capTag)) > 0)
            {
                // Replace the first caption with 
                // "tr><td colspan=2 align=center".
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
    } // MyDetailsViewDesigner
} // Examples.CS.WebControls.Design
// </snippet1>

