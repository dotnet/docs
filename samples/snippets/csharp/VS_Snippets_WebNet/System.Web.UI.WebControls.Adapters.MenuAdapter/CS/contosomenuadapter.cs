//<Snippet1>
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Contoso
{
    [AspNetHostingPermission(
        SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(
        SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class ContosoMenuAdapter :
        System.Web.UI.WebControls.Adapters.MenuAdapter, IPostBackEventHandler
    {

        // String variable to hold the currently selected path.
        private string menuPath = String.Empty;

        //<Snippet2>
        protected new System.Web.UI.WebControls.Menu Control
        {
            get
            {
                return (System.Web.UI.WebControls.Menu)base.Control;
            }
        }
        //</Snippet2>

        // Set the menuPath variable to the saved state variable.
        //<Snippet3>
        protected override void LoadAdapterControlState(Object controlState)
        {
            if (controlState != null)
            {
                if (controlState is String)
                {
                    menuPath = (string)controlState;
                }
            }

            base.LoadAdapterControlState(controlState);
        }
        //</Snippet3>


        // Return the menu path at the current location.
        //<Snippet4>
        protected override object SaveAdapterControlState()
        {
            return menuPath;
        }
        //</Snippet4>

        //<Snippet5>
        protected override void OnInit(EventArgs e)
        {
            Control.Init += new EventHandler(this.ShowMap);
            base.OnInit(e);
        }

        public void ShowMap(object sender, EventArgs e)
        {
            Control menuNav = this.Control.FindControl("contosoMenuNav");
            if (menuNav == null)
            {
                Style labelStyle = new Style();
                labelStyle.BackColor = System.Drawing.Color.Blue;
                labelStyle.ForeColor = System.Drawing.Color.White;
                labelStyle.Font.Name = "Arial";
                labelStyle.Font.Size = FontUnit.XXSmall;

                Label newLabel = new Label();
                newLabel.ApplyStyle(labelStyle);
                newLabel.ID = "contosoMenuNav";
                newLabel.Text = "Initialized label";

                this.CreateChildControls();
                this.Control.Controls.Add(newLabel);
            }
        }
        //</Snippet5>

        // Set the text of the contosoMenuNav to the current menu path.
        //<Snippet6>
        protected override void OnPreRender(EventArgs e)
        {
            if (menuPath != String.Empty)
            {
                Control menuNav = this.Control.FindControl("contosoMenuNav");
                if (menuNav != null)
                {
                    Label newLabel = (Label)menuNav;
                    newLabel.Text = "Nav:: " + menuPath.Replace("\\", "-->");
                }
            }

            base.OnPreRender(e);
        }
        //</Snippet6>

        //<Snippet7>
        protected override void Render(HtmlTextWriter writer)
        {
            // Pass the modified writer to the parent class for rendering.
            base.Render(writer);

            // Render the MenuNav label control.
            Control menuNav = this.Control.FindControl("contosoMenuNav");
            if (menuNav != null)
            {
                menuNav.RenderControl(writer);
            }
        }
        //</Snippet7>

        // Wrap a panel with the inherited menu styles around the 
        // menu control.
        //<Snippet8>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.Write("<i>");
            base.RenderBeginTag(writer);
        }
        //</Snippet8>

        //<Snippet9>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            base.RenderEndTag(writer);
            writer.Write("</i>");
        }
        //</Snippet9>

        // Set the menuPath to the current location in the menu hierarchy.
        //<Snippet10>
        protected new void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument != null)
            {
                string newPath = 
                    eventArgument.Substring(1, eventArgument.Length - 1);

                if (eventArgument[0] == 'u')
                {
                    int lastDelim = menuPath.LastIndexOf("\\");
                    menuPath = menuPath.Substring(0, lastDelim);
                }
                else
                {
                    menuPath = newPath;
                }

                // Call the parent RaisePostBackEvent method.
                base.RaisePostBackEvent(eventArgument);
            }
        }
        //</Snippet10>
    }
}
//</Snippet1>