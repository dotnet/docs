// <Snippet1>
namespace ControlTest 
{
   using System;
   using System.Web.UI;
   using System.Web.UI.WebControls;

   // Renders the following HTML: 
   // <span onclick="alert('Hello');" style="color:Red;">Custom Contents</span>

   public class MyWebControl: WebControl {

      public MyWebControl() : base(HtmlTextWriterTag.Span) 
      { }

      [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
      protected override void AddAttributesToRender(HtmlTextWriter writer) 
      {

         writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "alert('Hello');");
         writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "Red");
         base.AddAttributesToRender(writer);

      }

      [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
      protected override void RenderContents(HtmlTextWriter writer) 
      {
         writer.Write("Custom Contents");
         base.RenderContents(writer);
      }
   }
}

// </Snippet1>