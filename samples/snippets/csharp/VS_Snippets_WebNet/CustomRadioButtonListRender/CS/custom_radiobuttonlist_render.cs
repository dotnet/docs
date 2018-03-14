// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomRadioButtonListRender : System.Web.UI.WebControls.RadioButtonList
  {
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
      // Call the base RenderContents method.
      base.Render(writer);

      // Append some text to the Image.
      writer.Write("Experience Windows Server 2003 and Visual Studio® .NET 2003.");
    }
  }
}
// </Snippet2>
