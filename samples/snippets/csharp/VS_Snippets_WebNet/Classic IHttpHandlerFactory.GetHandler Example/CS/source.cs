// <Snippet1>
// Name this C# file HandlerFactoryTest.cs and compile it with the
// command line: csc /t:Library /r:System.Web.dll HandlerFactoryTest.cs.
// Copy HandlerFactoryTest.dll to your \bin directory.

namespace test
{
   using System;
   using System.Web;

   // Factory class that creates a handler object based on a request 
   // for either abc.aspx or xyz.aspx as specified in the Web.config file.
   public class MyFactory : IHttpHandlerFactory
   {
      [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
      public virtual IHttpHandler GetHandler(HttpContext context, 
                                             String requestType, 
                                             String url, 
                                             String pathTranslated)
      {
         String fname = url.Substring(url.LastIndexOf('/')+1);
         String cname = fname.Substring(0, fname.IndexOf('.'));
         String className = "test." + cname;

         Object h = null;

         // Try to create the handler object.
         try 
         {
            // Create the handler by calling class abc or class xyz.
            h = Activator.CreateInstance(Type.GetType(className));
         }
         catch(Exception e)
         {
            throw new HttpException("Factory couldn't create instance " +
                                    "of type " + className, e);
         }
         return (IHttpHandler)h;
      }

      // This is a must override method.
      public virtual void ReleaseHandler(IHttpHandler handler)
      {
      }
   }
   
   // Class definition for abc.aspx handler.
   public class abc : IHttpHandler
   {
      public virtual void ProcessRequest(HttpContext context)
      {
         context.Response.Write("<html><body>");
         context.Response.Write("<p>ABC Handler</p>\n");
         context.Response.Write("</body></html>");
      }
    
      public virtual bool IsReusable
      {
         get { return true; }
      }
   }

   // Class definition for xyz.aspx handler.
   public class xyz : IHttpHandler
   {
      public virtual void ProcessRequest(HttpContext context)
      {
         context.Response.Write("<html><body>");
         context.Response.Write("<p>XYZ Handler</p>\n");
         context.Response.Write("</body></html>");
      }
    
      public virtual bool IsReusable
      {
         get { return true; }
      }
   }
}

/*
______________________________________________________________

To use the handler factory, use the following lines in a 
Web.config file.

<configuration>
   <system.web>
      <httpHandlers>
         <add verb="*" path="abc.aspx" type="test.MyFactory,HandlerFactoryTest" />
         <add verb="*" path="xyz.aspx" type="test.MyFactory,HandlerFactoryTest" />
      </httpHandlers>     
   </system.web>
</configuration>
*/
   
// </Snippet1>
