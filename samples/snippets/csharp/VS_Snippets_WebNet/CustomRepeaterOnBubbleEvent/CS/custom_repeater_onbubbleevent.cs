// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class CustomRepeaterOnBubbleEvent : System.Web.UI.WebControls.Repeater
  {
    protected override bool OnBubbleEvent(object source, System.EventArgs args)
    {
      // If the EventArgs are of type RepeaterCommandEventArgs,
      // then call the OnItemCommand event handler and return true (bubble up the event)
      // else return false (don't bubble up the event).
      bool isHandled = false;
      if (args is System.Web.UI.WebControls.RepeaterCommandEventArgs) 
      {
        this.OnItemCommand((System.Web.UI.WebControls.RepeaterCommandEventArgs)args);
        isHandled = true;
      }
      return isHandled;
    }
  }
}
// </Snippet2>
