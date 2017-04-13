// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{

  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomHtmlTextAreaAddParsedSubObject : System.Web.UI.HtmlControls.HtmlTextArea
  {
    protected override void AddParsedSubObject(object obj)
    {
      // If the object is a LiteralControl or a DataBoundLiteralControl control, 
      // then pass the object to the base class's AddParsedSubObject method.
      if (obj is System.Web.UI.LiteralControl || 
          obj is System.Web.UI.DataBoundLiteralControl)
      {
        base.AddParsedSubObject(obj);
      }
      else
      {
        throw new System.Web.HttpException("You cannot have a child control of type " 
         + obj.GetType().Name.ToString() + ".");
      }
    }
  }
}
// </Snippet2>
