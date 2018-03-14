// DesignerEditors.cs
// <snippet1>
using System.Web;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Security.Permissions;
using System.Drawing.Design;

namespace Examples.CS.WebControls.Design
{
    // The MyDataSourceControl has a property of the data source controls.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class MyDataSourceControl : WebControl
    {
        // <snippet2>
        private ParameterCollection selectParams;

        // Associate the ParameterCollectionEditor with the SelectParameters. 
        [Editor(typeof(System.Web.UI.Design.WebControls.
            ParameterCollectionEditor),
            typeof(UITypeEditor))]
        public ParameterCollection SelectParameters
        {
            get
            {
                // If there is no selectParams collection, create it.
                if (selectParams == null)
                    selectParams = new ParameterCollection();

                return selectParams;
            }
            set { selectParams = value; }
        } // SelectParameters
        // </snippet2>

    } // MyDataSourceControl
} // Examples.CS.WebControls.Design
// </snippet1>

