//<Snippet1>
using System;
using System.Web;
using System.Web.UI;
using System.Security.Permissions;

namespace Contoso
{
    [AspNetHostingPermission(
        SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(
        SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class HierarchicalTreeViewAdapter :
        System.Web.UI.WebControls.Adapters.HierarchicalDataBoundControlAdapter
    {
        // Return a strongly-typed TreeView control for adapter.
        //<Snippet2>
        protected new System.Web.UI.WebControls.TreeView Control
        {
            get
            {
                return (System.Web.UI.WebControls.TreeView)base.Control;
            }
        }
        //</Snippet2>

        // Verify the DataSourceID property is set prior to binding data.
        //<Snippet3>
        protected override void PerformDataBinding()
        {
            if (Control.DataSourceID != null)
            {
                base.PerformDataBinding();
            }
        }
        //</Snippet3>
    }
}
//</Snippet1>