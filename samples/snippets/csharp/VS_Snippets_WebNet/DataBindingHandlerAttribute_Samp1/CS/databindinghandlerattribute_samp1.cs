// <Snippet1>
// The following example uses the 
// DataBindingHandlerAttribute(String) constructor to designate
// the custom DataBindingHandler class, named MyDataBindingHandler,
// for the custom MyWebControl class.
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.ComponentModel.Design;
using System.Security.Permissions;

namespace MyTextCustomControl
{
   [ DataBindingHandlerAttribute("MyTextCustomControl.MyDataBindingHandler") ]
   [AspNetHostingPermission(SecurityAction.Demand, 
      Level=AspNetHostingPermissionLevel.Minimal)]
   public sealed class MyWebControl : WebControl
   {
      protected override void Render(HtmlTextWriter output)
      {
         output.Write("This class uses the DataBindingHandlerAttribute class.");
      }
   }

   public class MyDataBindingHandler : TextDataBindingHandler
   {
      public override void DataBindControl(IDesignerHost host, Control myControl)
      {
         ((TextBox)myControl).Text = "Added by MyDataBindingHandler";
      }
   }
}
// </Snippet1>