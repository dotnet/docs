// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomCustomValidatorEvaluateIsValid : System.Web.UI.WebControls.CustomValidator
    {
        protected override bool EvaluateIsValid()
        {
            bool isValid = false;
            
            // Get the name of the control to validate.
            string controlToValidate = this.ControlToValidate;
            if (controlToValidate.Length > 0) 
            {
            // Get the control's value.
            string controlValue = GetControlValidationValue(controlToValidate);

            // If the value is not null and not empty, test whether 
            // check if the value entered into the text box is even,
            // if so return true, else return false in all other cases.
            if ((controlValue != null) && (!controlValue.Trim().Equals(System.String.Empty)))
            {
                try 
                {
                int i = int.Parse(controlValue);
                isValid = ((i%2) == 0);
                }
                catch
                {}
            }  
            } 
            return isValid;   
        }
    }
}
// </Snippet2>
