/*
   The following program demonstrates the 'CreateHtmlTextWriter' method and constructor of 'Page' class. 
   .
   
   This program creates a custom 'TextWriter' derived from 'HtmlTextWriter' called 
   'MyHtmlTextWriter'. The 'CreateHtmlTextWriter' method is overriden in the 'MyPage' 
   class, derived from 'Page', so that the instance of 'MyHtmlTextWriter' is used in
   rendering the WebControls. The 'Render' method is overridden in  'MyPage' class 
   which will print the current time.
*/
// <Snippet1>
// <Snippet2>
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

// </Snippet2>
// </Snippet1>