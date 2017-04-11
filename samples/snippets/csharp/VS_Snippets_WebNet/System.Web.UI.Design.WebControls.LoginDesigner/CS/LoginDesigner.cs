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
    // The MyLogin is a copy of the Login.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(Examples.CS.WebControls.Design.MyLoginDesigner))]
    public class MyLogin : Login
    {
    } // MyLogin

    // Override members of the LoginDesigner.
    [ReflectionPermission(SecurityAction.Demand, Flags=ReflectionPermissionFlag.MemberAccess)]
    public class MyLoginDesigner : LoginDesigner
    {
        // <snippet2>
        // Generate the design-time markup for the control when an error occurs.
        protected override string GetErrorDesignTimeHtml(Exception e) 
        {
            // Write the error message text in red, bold.
            string errorRendering =
                "<span style=\"font-weight:bold; color:Red; \">" +
                e.Message + "</span>";

            return CreatePlaceHolderDesignTimeHtml(errorRendering);
        } // GetErrorDesignTimeHtml
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
        public override string GetDesignTimeHtml()
        {
            // Make the control more visible in the designer.  If the border 
            // style is None or NotSet, change the border to a blue dashed line. 
            MyLogin myLoginCtl = (MyLogin)ViewControl;
            string markup = null;

            // Check if the border style should be changed.
            if (myLoginCtl.BorderStyle == BorderStyle.NotSet ||
                myLoginCtl.BorderStyle == BorderStyle.None)
            {
                BorderStyle oldBorderStyle = myLoginCtl.BorderStyle;
                Color oldBorderColor = myLoginCtl.BorderColor;

                // Set the design time properties and catch any exceptions.
                try
                {
                    myLoginCtl.BorderStyle = BorderStyle.Dashed;
                    myLoginCtl.BorderColor = Color.Blue;

                    // Call the base method to generate the markup.
                    markup = base.GetDesignTimeHtml();
                }
                catch (Exception ex)
                {
                    markup = GetErrorDesignTimeHtml(ex);
                }
                finally
                {
                    // It is not necessary to restore the border properties 
                    // to their original values because the ViewControl 
                    // was used to reference the associated control and the 
                    // UsePreviewControl was not overridden.  

                    // myLoginCtl.BorderStyle = oldBorderStyle;
                    // myLoginCtl.BorderColor = oldBorderColor;
                }
            }
            else
                // Call the base method to generate the markup.
                markup = base.GetDesignTimeHtml();

            return markup;

        } // GetDesignTimeHtml
        // </snippet4>
    } // MyLoginDesigner
} // Examples.CS.WebControls.Design
// </snippet1>

