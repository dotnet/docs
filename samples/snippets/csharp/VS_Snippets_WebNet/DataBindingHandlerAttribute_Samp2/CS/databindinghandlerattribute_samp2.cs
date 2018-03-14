// <Snippet1>
// The following example uses the Default
// DataBindingHandlerAttribute constructor.
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace MyTextCustomControl
{
   [ DataBindingHandlerAttribute() ]
   [AspNetHostingPermission(SecurityAction.Demand, 
      Level=AspNetHostingPermissionLevel.Minimal)]
   public sealed class MyTextBox : TextBox
   {
      protected override void Render(HtmlTextWriter output)
      {
         output.Write("This class uses the DataBindingHandlerAttribute class.");
      }
   }
}
// </Snippet1>