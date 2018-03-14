// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomTextBoxTagKey : System.Web.UI.WebControls.TextBox
  {
    protected override System.Web.UI.HtmlTextWriterTag TagKey
    {
      get 
      {
        // If the TextMode is MultiLine, return a Textarea tag, 
        // else return an Input tag.
        if (this.TextMode == System.Web.UI.WebControls.TextBoxMode.MultiLine)
        {
          return System.Web.UI.HtmlTextWriterTag.Textarea;
        }
        else
        {
          return System.Web.UI.HtmlTextWriterTag.Input;
        }
      }
    }
  }
}
// </Snippet2>
