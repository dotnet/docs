// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomRangeValidatorAddAttributesToRender : System.Web.UI.WebControls.RangeValidator
  {
    protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
    {
      // Show the Validation text as Bold 
      writer.AddStyleAttribute(System.Web.UI.HtmlTextWriterStyle.FontWeight, "bold");
      
      // Call the base AddAttributesToRender method.
      base.AddAttributesToRender(writer);
    }
  }
}
// </Snippet2>
