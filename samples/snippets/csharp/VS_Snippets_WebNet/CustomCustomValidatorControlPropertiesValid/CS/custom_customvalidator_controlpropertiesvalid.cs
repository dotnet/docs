// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomCustomValidatorControlPropertiesValid : System.Web.UI.WebControls.CustomValidator
    {
        protected override bool ControlPropertiesValid()
        {
            string controlToValidate = this.ControlToValidate;

            // Determine whether the ControlToValidate is on the page 
            // and contains a valid validation property. 
            if (controlToValidate.Length > 0) 
            {
            base.CheckControlValidationProperty(controlToValidate, "ControlToValidate");
            }

            // If the control is visible, then control is valid 
            // and is ready for validation.
            System.Web.UI.Control control = this.FindControl(controlToValidate);
            return control.Visible;
        }
    }
}
// </Snippet2>
