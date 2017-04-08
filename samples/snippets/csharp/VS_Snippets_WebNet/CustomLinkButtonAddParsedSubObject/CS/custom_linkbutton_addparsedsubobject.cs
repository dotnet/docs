// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomLinkButtonAddParsedSubObject : System.Web.UI.WebControls.LinkButton
    {
        protected override void AddParsedSubObject(object obj)
        {
            // If the server control contains any child controls.
            if (this.HasControls()) 
            {
                // Notify the base server control that an element, either XML or HTML, 
                // was parsed, and adds the element to the server control's 
                // ControlCollection object.
                base.AddParsedSubObject(obj);
            }
            else // Else the server control doesn't contain any child controls.
            {
                // If the parsed element is a LiteralControl.
                if (obj is System.Web.UI.LiteralControl) 
                {
                    // Set the server control's Text property to the parsed element's Text value.
                    this.Text = ((System.Web.UI.LiteralControl)obj).Text;
                }
                else // Else the parsed element is not a LiteralControl.
                {
                    // If the server control has a value in the the Text property.
                    string currentText = this.Text;
                    if (currentText.Length != 0) 
                    {
                        // Set the server control's Text property to an empty string.
                        this.Text = System.String.Empty;

                        // Notify the base server control that a new LiteralControl was parsed, 
                        // and adds the element to the server control's ControlCollection object.
                        base.AddParsedSubObject(new System.Web.UI.LiteralControl(currentText));
                    }
                    base.AddParsedSubObject(obj);
                }
            }
        }
    }
}
// </Snippet2>
