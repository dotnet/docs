// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomCompareValidatorEvaluateIsValid : System.Web.UI.WebControls.CompareValidator
    {
    protected override bool EvaluateIsValid()
    {
      // Get the values from the two controls
      string controlToValidateValue = this.GetControlValidationValue(this.ControlToValidate);
      string controlToCompareValue = this.GetControlValidationValue(this.ControlToCompare);

      // If the values are the same, return true, else return false.
      if (System.String.Compare(controlToValidateValue, 0, controlToCompareValue, 0, controlToCompareValue.Length, false, System.Globalization.CultureInfo.InvariantCulture) == 0) 
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}
// </Snippet2>