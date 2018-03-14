using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompositionSampleControls {

    public class Composition1 : Control, INamingContainer {

       // <snippet1>
       // Ensure the current control has children,
       // then get or set the Text property.
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

       // </snippet1>


       // <snippet2>
       // Override CreateChildControls to create the control tree.
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="Execution")]
        protected override void CreateChildControls() {

            // Add a LiteralControl to the current ControlCollection.
            this.Controls.Add(new LiteralControl("<h3>Value: "));


            // Create a text box control, set the default Text property, 
            // and add it to the ControlCollection.
            TextBox box = new TextBox();
            box.Text = "0";
            this.Controls.Add(box);

            this.Controls.Add(new LiteralControl("</h3>"));
        }

       // </snippet2>
    }
}

  