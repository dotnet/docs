using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompositionSampleControls {

    public class Composition1 : Control, INamingContainer {

        public int Value {
           get {
               this.EnsureChildControls();
               return Int32.Parse(((TextBox)Controls[1]).Text);
           }
           set {
               this.EnsureChildControls();
               ((TextBox)Controls[1]).Text = value.ToString();
           }
        }

        // <snippet1>
        // Add two LiteralControls that render HTML H3 elements and text.
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
        protected override void CreateChildControls() {

            this.Controls.Add(new LiteralControl("<h3>Value: "));

            TextBox box = new TextBox();
            box.Text = "0";
            this.Controls.Add(box);

            this.Controls.Add(new LiteralControl("</h3>"));
        }
        // </snippet1>
    }
}

  