// <Snippet1>
/*
   This example shows a code-behind page that includes a custom control,
   MyControl. The control overrides its Render method to write some HTML
   to the page, while the Page uses the Control's constructor to instantiate
   MyControl. The page also overrides its own constructor to ensure that a
   custom Load event is used when the page is called by a request.
*/

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Samples.AspNet.CS
{

[AspNetHostingPermission(SecurityAction.Demand, 
   Level=AspNetHostingPermissionLevel.Minimal)]
public sealed class MyControl : Control
{
   // Override the Render method.
   protected override void Render(HtmlTextWriter w)
   {
       w.Write("<h2>Implementation Of Control</h2>");
       w.Write("<h3><i><font color=green>Reference : " + 
                                ((LiteralControl)Controls[0]).Text + 
                                "</font></i></h3>");
   }
}

public class MyPage : Page
{
   // Create an instance of the MyControl class.
   protected MyControl ctlOne = new MyControl();
   
   // <snippet2>
   // This is the constructor for a custom Page class. 
   // When this constructor is called, it associates the Control.Load event,
   // which the Page class inherits from the Control class, with the Page_Load
   // event handler for this version of the page.
   public MyPage()
   {
      Load += new EventHandler(Page_Load);
   }
   // </snippet2>

   private void Page_Load(object sender, System.EventArgs e)
   {
      Page.Controls.Add(ctlOne);
      // Add a LiteralControl to ctlOne.
      ctlOne.Controls.Add(new LiteralControl("<h4> MSDN Library <h4>"));      
   }  
}
}
// </Snippet1>
