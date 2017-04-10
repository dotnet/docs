// <snippet1>
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;
using System.Collections;
using System.ComponentModel;
using System.Security.Permissions;

namespace Examples.CS.WebControls.Design
{
    // The MyLoginView is a copy of the LoginView.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(Examples.CS.WebControls.Design.MyLoginViewDesigner))]
    public class MyLoginView : LoginView
    {
    } // MyLoginView

    // Override members of the LoginViewDesigner.
    [ReflectionPermission(SecurityAction.Demand, Flags=ReflectionPermissionFlag.MemberAccess)]
    public class MyLoginViewDesigner : LoginViewDesigner
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
            // Generate a design-time placeholder containing the names of all
            // the role groups.
            MyLoginView myLoginViewCtl = (MyLoginView)ViewControl;
            RoleGroupCollection roleGroups = myLoginViewCtl.RoleGroups;
            string roleNames = null;

            // If there are any role groups, form a string of their names.
            if (roleGroups.Count > 0)
            {
                roleNames = "Role Groups: <br /> &nbsp;&nbsp;" + 
                    roleGroups[0].ToString();

                for( int rgX = 1; rgX < roleGroups.Count; rgX++ )
                    roleNames += 
                        "<br /> &nbsp;&nbsp;" + roleGroups[rgX].ToString();
            }
            return CreatePlaceHolderDesignTimeHtml( roleNames);
        } // GetEmptyDesignTimeHtml
        // </snippet5>

        // <snippet3>
        // Shadow control properties with design-time properties.
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
        public override string GetDesignTimeHtml(DesignerRegionCollection regions)
        {
            // Make the control more visible in the designer.   
            // Enclose the markup in a table with an orange border. 
            const string openTableMarkup =
                "<table><tr><td style=\"border:4 solid #FF7F00;\">";
            const string closeTableMarkup = "</td></tr></table>";

            // Call the base method to generate the markup.
            string markup = base.GetDesignTimeHtml(regions);

            return openTableMarkup + markup + closeTableMarkup;

        } // GetDesignTimeHtml
        // </snippet4>

        // <snippet6>
        public override void Initialize(IComponent component)
        {
            // Ensure that only a MyLoginView can be created in this designer.
            if (!(component is MyLoginView))
                throw new ArgumentException();

            // Call the base method to generate the markup.
            base.Initialize(component);

        } // Initialize
        // </snippet6>
    } // MyLoginViewDesigner
} // Examples.CS.WebControls.Design
// </snippet1>

