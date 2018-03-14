// <snippet1>
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web.UI.Design.WebControls.WebParts;

/// <summary>
/// SecretEditorPart is a custom EditorPart control that
/// allows the end user to change the ToolTip property of
/// a control by typing the value into a TextBox. 
/// SecretEditorPartDesigner hides the TextBox at design
/// time via the view control and replaces it with the 
/// words "The textbox is now hidden."
/// </summary>
namespace Samples.AspNet.CS.Controls
{
    [Designer(typeof(SecretEditorPartDesigner))]
    public class SecretEditorPart : EditorPart
    {
        public CheckBox UseCustom = new CheckBox();
        public TextBox TTTextBox = new TextBox();

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            Controls.Add(UseCustom);
            Literal lApply = new Literal();
            lApply.Text = "Apply custom ToolTip<br />";
            Controls.Add(lApply);
            Controls.Add(TTTextBox);
        }

        public override bool ApplyChanges()
        {
            EnsureChildControls();
            try
            {
                WebPartToEdit.ToolTip = TTTextBox.Text;
            }
            catch
            {
                return false;
            }
            return true;
        }

        public override void SyncChanges()
        {
            // Abstract method not implemented for this example
            return;
        }
    }

    public class SecretEditorPartDesigner : EditorPartDesigner
    {
        public override void Initialize(IComponent component)
        {
            // Validate the associated control
            if (! (component is SecretEditorPart))
            {
                string msg = "The associated control must be of type 'SecretEditorPart'";
                throw new ArgumentException(msg);
            }
            base.Initialize(component);
        }

        public override string GetDesignTimeHtml()
        {
            // Access the view control.
            SecretEditorPart sep = (SecretEditorPart)ViewControl;
           
            // Hide the textbox.
            sep.TTTextBox.Visible = false;

            // Now generate the base rendering.
            string designTimeHtml = base.GetDesignTimeHtml();

            // Insert some text.
            string segment = "</div>";
            designTimeHtml = designTimeHtml.Replace(segment, 
                "The textbox is now hidden." + segment);
            
            // Return the modified rendering.
            return designTimeHtml;
        }
    }
}
// </snippet1>