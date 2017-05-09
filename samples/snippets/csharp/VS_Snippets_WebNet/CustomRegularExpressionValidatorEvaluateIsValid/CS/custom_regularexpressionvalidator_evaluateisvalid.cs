// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomRegularExpressionValidatorEvaluateIsValid : System.Web.UI.WebControls.RegularExpressionValidator
  {
    protected override bool EvaluateIsValid()
    {
      // Get the control to validate's validation value
      string controlValue = GetControlValidationValue(this.ControlToValidate);
      
      // If the value is null or empty, then return true
      if (controlValue == null || controlValue.Trim().Length == 0) 
      {
        return true;
      }
      else
      {
        // Else try running the Regular Expression against the value 
        // and see if there is a match.
        try 
        {
          System.Text.RegularExpressions.Match regExpMatch = System.Text.RegularExpressions.Regex.Match(controlValue, this.ValidationExpression);
          return(regExpMatch.Success && regExpMatch.Index == 0 && regExpMatch.Length == controlValue.Length);
        }
        catch 
        {
          return true;
        }
      }
    }
  }
}
// </Snippet2>
