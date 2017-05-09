// <Snippet1>
using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;

// Module that sets Response.SubStatusCode in PostAuthenticateRequest event handler.
namespace Samples
{
    public class ModuleExampleTestCS : IHttpModule
    {
        public ModuleExampleTestCS()
        {
            // Constructor
        }
        public void Init(HttpApplication app)
        {
            app.PostAuthenticateRequest += new EventHandler(PostAuthenticateRequest_Handler);
        }
        public void Dispose()
        {
        }
        public void PostAuthenticateRequest_Handler(object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;

            // Set a SubStatusCode for Failed Request Tracing in IIS7
            context.Response.SubStatusCode = 99;
        }

    }
}
// </Snippet1>