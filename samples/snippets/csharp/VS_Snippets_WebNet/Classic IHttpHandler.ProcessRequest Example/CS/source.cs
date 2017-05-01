// <Snippet1>
// Name this C# file HandlerTest.cs and compile it with the
// command line: csc /t:library /r:System.Web.dll HandlerTest.cs.
// Copy HandlerTest.dll to your \bin directory.

using System.Web;

namespace HandlerExample
{
   public class MyHttpHandler : IHttpHandler
   {
      // Override the ProcessRequest method.
      public void ProcessRequest(HttpContext context)
      {
         context.Response.Write("<H1>This is an HttpHandler Test.</H1>");      
         context.Response.Write("<p>Your Browser:</p>");
         context.Response.Write("Type: " + context.Request.Browser.Type + "<br>");
         context.Response.Write("Version: " + context.Request.Browser.Version);
      }

      // Override the IsReusable property.
      public bool IsReusable
      {
         get { return true; }
      }
   }
}

/*
______________________________________________________________

To use this handler, include the following lines in a Web.config file.

<configuration>
   <system.web>
      <httpHandlers>
         <add verb="*" path="handler.aspx" type="HandlerExample.MyHttpHandler,HandlerTest"/>
      </httpHandlers>
   </system.web>
</configuration>
*/

// </Snippet1>
