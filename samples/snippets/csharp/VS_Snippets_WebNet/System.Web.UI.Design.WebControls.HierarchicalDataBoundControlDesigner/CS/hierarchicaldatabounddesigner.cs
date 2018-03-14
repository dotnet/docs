// <snippet1>
using System;
using System.IO;
using System.Web;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Web.UI.Design.WebControls;
using System.Collections;
using System.ComponentModel;
using System.Security.Permissions;

namespace Examples.CS.WebControls.Design
{
    // The MyHierarchicalDataBoundControl is a copy of the 
    // HierarchicalDataBoundControl.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(Examples.CS.WebControls.Design.
        MyHierarchicalDataBoundControlDesigner))]
    public class MyHierarchicalDataBoundControl : 
        HierarchicalDataBoundControl
    {
    } // MyHierarchicalDataBoundControl

    // Override members of the ierarchicalDataBoundControlDesigner.
    [ReflectionPermission(SecurityAction.Demand, Flags=ReflectionPermissionFlag.MemberAccess)]
    public class MyHierarchicalDataBoundControlDesigner : 
        HierarchicalDataBoundControlDesigner
    {
        // <snippet2>
        const string bracketClose = ">";
        const string spanOpen = "<SPAN";
        const string spanClose = "</SPAN>";

        // Return the markup for a placeholder, if the inner markup is empty.
        // For brevity, the code that is used to detect embedded white_space 
        // in the tags is not shown.
        public override string GetDesignTimeHtml()
        {
            // Get the design-time markup from the base method.
            string markup = base.GetDesignTimeHtml();

            // If the markup is null or empty, return the markup 
            // for the placeholder.
            if(markup == null || markup == string.Empty)
                return GetEmptyDesignTimeHtml();

            // Make the markup uniform case so that the IndexOf will work.
            string MARKUP = markup.ToUpper();
            int charX;

            // Look for a <span ...> tag.
            if ((charX = MARKUP.IndexOf(spanOpen)) >= 0)
            {
                // Find closing bracket of span open tag.
                if ((charX = MARKUP.IndexOf(bracketClose, 
                        charX+spanOpen.Length)) >= 0)
                {
                    // If the inner markup of <span ...></span> is empty, 
                    // return the markup for a placeholder.
                    if (string.Compare(MARKUP, charX + 1, spanClose, 0, 
                                        spanClose.Length) == 0)

                        return GetEmptyDesignTimeHtml();
                }
            }
            // Return the original markup, if the inner markup is not empty.
            return markup;
        }
        // </snippet2>

        // <snippet3>
        // Shadow the control properties with design-time properties.
        protected override void PreFilterProperties(IDictionary properties)
        {
            string namingContainer = "NamingContainer";

            // Call the base method first.
            base.PreFilterProperties(properties);

            // Make the NamingContainery visible in the Properties grid.
            PropertyDescriptor selectProp =
                (PropertyDescriptor)properties[namingContainer];
            properties[namingContainer] =
                TypeDescriptor.CreateProperty(selectProp.ComponentType,
                    selectProp, BrowsableAttribute.Yes);
        } // PreFilterProperties
        // </snippet3>
    } // MyHierarchicalDataBoundControlDesigner
} // Examples.CS.WebControls.Design
// </snippet1>

