// <Snippet1>
/* Create a custom WebControl class, named AttribRender, that overrides 
   the Render method to write two introductory strings. Then call the
   AttributeCollection.Render method, which allows the control to write the
   attribute values that are added to it when it is included in a page.
*/
   
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

// Create the namespace that contains the AttribRender and the
// page that accesses it.
namespace AC_Render
{
   // This is the custom WebControl class.
   [AspNetHostingPermission(SecurityAction.Demand, 
      Level=AspNetHostingPermissionLevel.Minimal)]
   public class AttribRender : WebControl
   {
      // This is the overridden WebControl.Render method.
      protected override void Render(HtmlTextWriter output)
      {
         output.Write("<h2>An AttributeCollection.Render Method Example</h2>");
         output.Write("The attributes, and their values, added to the ctl1 control are <br><br>");
         // This is the AttributeCollection.Render method call. When the
         // page that contains this control is requested, the
         // attributes that the page adds, and their values,
         // are rendered to the page.
         Attributes.Render(output);
      }
   }
}
// </Snippet1>