// <Snippet1>
using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;

// Module that demonstrates one event handler for several events.
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
            app.AuthenticateRequest += new EventHandler(App_Handler);
            app.PostAuthenticateRequest += new EventHandler(App_Handler);
            app.LogRequest += new EventHandler(App_Handler);
            app.PostLogRequest += new EventHandler(App_Handler);
        }
        public void Dispose()
        {
        }
        // One handler for AuthenticationRequest, PostAuthenticateRequest,
	// LogRequest, and PostLogRequest events
        public void App_Handler(object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;

            if (context.CurrentNotification == RequestNotification.AuthenticateRequest)
            {

                if (!context.IsPostNotification)
                {
                    // Put code here that is invoked when the AuthenticateRequest event is raised.
                }
                else
                {
                    // PostAuthenticateRequest 
                    // Put code here that runs after the AuthenticateRequest event completes.
                }
            }
            if (context.CurrentNotification == RequestNotification.LogRequest)
            {
                if (!context.IsPostNotification)
                {
                    // Put code here that is invoked when the LogRequest event is raised.
                }
                else
                {
                    // PostLogRequest
                    // Put code here that runs after the LogRequest event completes.
                }
            }

        }
    }
}
// </Snippet1>