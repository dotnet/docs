// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomTextBoxAddParsedSubObject : System.Web.UI.WebControls.TextBox
  {
    protected override void AddParsedSubObject(object obj)
    {
      // If the object is a LiteralControl, then set this control's Text property.
      if (obj is System.Web.UI.LiteralControl) 
      {
        this.Text = ((System.Web.UI.LiteralControl)obj).Text;
      }
      else 
      {
        throw new System.Web.HttpException("You cannot have a child control of type " + obj.GetType().Name.ToString());
      }
    }
  }
}
// </Snippet2>
