namespace WebPage
{
   using System;
   using System.IO;
   using System.Web.UI;

   public class MyPage : Page
   {
      public MyPage():base()
      {
      }

      [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
      protected override HtmlTextWriter CreateHtmlTextWriter(TextWriter writer)
      {
         return new MyHtmlTextWriter(writer);
      }

      [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
      protected override void Render(HtmlTextWriter writer)
      {         
         // Write a Font control.
         writer.AddAttribute("color", "red");
         writer.AddAttribute("size", "6pt");
         writer.RenderBeginTag(HtmlTextWriterTag.Font);
         writer.Write("<br>" + "The time on the server:<br> " + System.DateTime.Now.ToLongTimeString());
         writer.RenderEndTag();
      }
   }

   public class MyHtmlTextWriter : HtmlTextWriter
   {
      public MyHtmlTextWriter(TextWriter writer):base(writer)
      {
         writer.Write("<font color=blue> 'MyHtmlTextWriter' is used for rendering.</font>");
      }
   }

}
