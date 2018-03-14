// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomRequiredFieldValidatorEvaluateIsValid : System.Web.UI.WebControls.RequiredFieldValidator
  {
    protected override bool EvaluateIsValid()
    {
      // Get the ControlToValidate's value.
      string controlValue = GetControlValidationValue(ControlToValidate);

      // If ControlToValidate's value is null or empty, then return false.
      if ((controlValue == null) || (controlValue.Trim().Equals(System.String.Empty)))
      {
        return false;
      }
      // Else the control contains a value so return true.
      else
      {
        return true;
      }
    }                
  }
}
// </Snippet2>
