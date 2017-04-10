// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomTextBoxOnTextChanged : System.Web.UI.WebControls.TextBox
  {
    private bool isDirty = false;

    protected override void OnTextChanged(System.EventArgs e)
    {
      // Call the base OnTextChanged method.
      base.OnTextChanged(e);

      // Change the dirty flag to True.
      isDirty = true;
    }
  }
}
// </Snippet2>
