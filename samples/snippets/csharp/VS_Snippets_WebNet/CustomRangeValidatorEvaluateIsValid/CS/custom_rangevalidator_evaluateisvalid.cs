// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomRangeValidatorEvaluateIsValid : System.Web.UI.WebControls.RangeValidator
  {
    protected override bool EvaluateIsValid()
    {
      // Get the value of the control to validate.
      string controlValue = GetControlValidationValue(ControlToValidate);

      // If no value was entered, show the validation error by returning false.
      if (controlValue.Trim().Length == 0) 
      {
        return false;
      }

      // Compare the ControlToValidate's value against the minimum and maximum values.
      return(Compare(controlValue, this.MinimumValue, System.Web.UI.WebControls.ValidationCompareOperator.GreaterThanEqual, this.Type) &&
        Compare(controlValue, this.MaximumValue, System.Web.UI.WebControls.ValidationCompareOperator.LessThanEqual, this.Type));
    }            
  }
}
// </Snippet2>
