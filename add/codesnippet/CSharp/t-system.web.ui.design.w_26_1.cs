using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.Design.WebControls;
using System.Collections;
using System.ComponentModel;
using System.Security.Permissions;

namespace Examples.CS.WebControls.Design
{
    // The MyObjectDataSource is a copy of the ObjectDataSource.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(Examples.CS.WebControls.Design.
        MyObjectDataSourceDesigner))]
    public class MyObjectDataSource : ObjectDataSource
    {
    } // MyObjectDataSource

    // Derive a designer that inherits from the ObjectDataSourceDesigner.
    [ReflectionPermission(SecurityAction.Demand, Flags=ReflectionPermissionFlag.MemberAccess)]
    public class MyObjectDataSourceDesigner : ObjectDataSourceDesigner
    {
        // Generate the design-time markup.
        public override string GetDesignTimeHtml()
        {
            // Get a reference to the control or a copy of the control.
            MyObjectDataSource myODS = (MyObjectDataSource)ViewControl;

            // Create a placeholder that displays the type of the business 
            // object and the name of the Select method.
            string markup = CreatePlaceHolderDesignTimeHtml(
                 "<b>TypeName</b> \"" + myODS.TypeName + "\"<br />" + 
                 "<b>SelectMethod</b> \"" + myODS.SelectMethod + "\"" );

            return markup;

        } // GetDesignTimeHtml

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

    } // MyObjectDataSourceDesigner
} // Examples.CS.WebControls.Design