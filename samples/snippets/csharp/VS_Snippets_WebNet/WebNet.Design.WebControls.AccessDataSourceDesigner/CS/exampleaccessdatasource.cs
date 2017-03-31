using System;
using System.Security.Permissions;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.Web.UI.Design.WebControls;

namespace CustomControls.Design
{
    //<Snippet2>
    // Create a control and bind it to the ExampleAccessDataSourceDesigner.
    [AspNetHostingPermission(System.Security.Permissions.SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(System.Security.Permissions.SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(CustomControls.Design.ExampleAccessDataSourceDesigner))]
    public class ExampleAccessDataSource : AccessDataSource
    {
        // Does nothing extra
    }
    //</Snippet2>

    //<Snippet3>
    [ReflectionPermission(SecurityAction.Demand, Flags=ReflectionPermissionFlag.MemberAccess)]
    public class ExampleAccessDataSourceDesigner : AccessDataSourceDesigner
    {
        //<Snippet5>
        // Generate design time markup.
        public override string GetDesignTimeHtml()
        {
            // Generate a design-time placeholder containing the 
            // DataFile and the ConnectionString properties.
            // Split the ConnectionString into segments so it doesn't make
            // placeholder too wide.
            string[] connectParts = GetConnectionString().Split(new char[] { ';' });
            string connectString = "&nbsp;&nbsp;" + connectParts[0];

            for (int i = 1; i < connectParts.Length; i++)
                connectString += ";<br>&nbsp;&nbsp;" + connectParts[i].Trim();

            return CreatePlaceHolderDesignTimeHtml(
                "DataFile: " + DataFile + "<br />" +
                "Connection string:<br />" + connectString);
        }
        //</Snippet5>

        // <Snippet4>
        // Shadow control properties with design time properties.
        protected override void PreFilterProperties(IDictionary properties)
        {
            // Call the base class method first.
            base.PreFilterProperties(properties);

            // Add the ConnectionString property to the property grid.
            PropertyDescriptor property =
                (PropertyDescriptor)properties["ConnectionString"];
            Attribute[] attributes = new Attribute[]
            {
                new BrowsableAttribute(true),
                new ReadOnlyAttribute(true)
            };
            properties["ConnectionString"] = TypeDescriptor.CreateProperty(
                GetType(), property, attributes);
        }
        // </Snippet4>
    }
    // </Snippet3>
}

