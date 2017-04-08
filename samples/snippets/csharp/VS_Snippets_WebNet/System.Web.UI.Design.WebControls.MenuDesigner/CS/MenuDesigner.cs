// <snippet1>
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.Design.WebControls;
using System.ComponentModel;
using System.Security.Permissions;
using System.Drawing;

namespace Examples.CS.WebControls.Design
{
    // <snippet3>
    // The MyMenu is a copy of the Menu.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(Examples.CS.WebControls.Design.MyMenuDesigner))]
    public class MyMenu : Menu
    {
    } // MyMenu
    // </snippet3>

    // Override members of the MenuDesigner.
    public class MyMenuDesigner : MenuDesigner
    {
        // <snippet2>
        // Generate the design-time markup for the control when an error occurs.
        protected override string GetErrorDesignTimeHtml(Exception ex) 
        {
            // Write the error message text in red, bold.
            string errorRendering =
                "<span style=\"font-weight:bold; color:Red; \">" +
                ex.Message + "</span>";

            return CreatePlaceHolderDesignTimeHtml(errorRendering);
        } // GetErrorDesignTimeHtml
        // </snippet2>

        // <snippet5>
        // Generate the design-time markup for the control 
        // when the template is empty.
        protected override string GetEmptyDesignTimeHtml()
        {
            string noElements = "Contains no menu items.";

            return CreatePlaceHolderDesignTimeHtml(noElements);
        } // GetEmptyDesignTimeHtml
        // </snippet5>

        // <snippet4>
        // Generate the design-time markup.
        public override string GetDesignTimeHtml()
        {
            // Make the control more visible in the designer.  If the border 
            // style is None or NotSet, change the border to an orange dotted line. 
            MyMenu myMenuCtl = (MyMenu)ViewControl;
            string markup = null;

            // Check if the border style should be changed.
            if (myMenuCtl.BorderStyle == BorderStyle.NotSet ||
                myMenuCtl.BorderStyle == BorderStyle.None)
            {
                BorderStyle oldBorderStyle = myMenuCtl.BorderStyle;
                Color oldBorderColor = myMenuCtl.BorderColor;

                // Set the design-time properties and catch any exceptions.
                try
                {
                    myMenuCtl.BorderStyle = BorderStyle.Dotted;
                    myMenuCtl.BorderColor = Color.FromArgb(0xFF7F00);

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
                    myMenuCtl.BorderStyle = oldBorderStyle;
                    myMenuCtl.BorderColor = oldBorderColor;
                }
            }
            else
                // Call the base method to generate the markup.
                markup = base.GetDesignTimeHtml();

            return markup;

        } // GetDesignTimeHtml
        // </snippet4>

        // <snippet6>
        public override void Initialize(IComponent component)
        {
            // Ensure that only a MyMenu can be created in this designer.
            if (!(component is MyMenu))
                throw new ArgumentException(
                    "The component is not a MyMenu control.");
            
            base.Initialize(component);

        } // Initialize
        // </snippet6>
    } // MyMenuDesigner
} // Examples.CS.WebControls.Design
// </snippet1>

