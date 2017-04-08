// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomCompareValidatorControlPropertiesValid : System.Web.UI.WebControls.CompareValidator
    {
        protected override bool ControlPropertiesValid()
        {
            // Determine whether the ControlToValidate is on the page and contains a validation properties. 
            base.CheckControlValidationProperty(this.ControlToValidate, "ControlToValidate");

            // If the control is visible, then control is valid and is ready for validation.
            System.Web.UI.Control control = this.FindControl(this.ControlToValidate);
            return control.Visible;
        }
    }
}
// </Snippet2>