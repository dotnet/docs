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
    public class HideDisabledControlContosoAdapter:
        System.Web.UI.WebControls.Adapters.HideDisabledControlAdapter
    {
        // Link the Label control to the adapter.
        protected new System.Web.UI.WebControls.Label Control
        {
            get
            {
                return (System.Web.UI.WebControls.Label)base.Control;
            }
        }

        // Do not render the Contoso controls if Enabled is false.
        //<Snippet2>
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if (Control.ID.StartsWith("Contoso"))
            {
                if (!Control.Enabled)
                {
                    return;
                }
            }

            base.Render(writer);
        }
        //</Snippet2>
    }
}
//</Snippet1>
