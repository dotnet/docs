// <Snippet1>
using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;

// Module that demonstrates one event handler for several events.
namespace Samples
{
    public class ModuleExample : IHttpModule
    {
        public ModuleExample()
        {
            // Constructor
        }
        public void Init(HttpApplication app)
        {
            app.LogRequest += new EventHandler(App_Handler);
            app.PostLogRequest += new EventHandler(App_Handler);
        }
        public void Dispose()
        {
        }
        // One handler for both the LogRequest and the PostLogRequest events.
        public void App_Handler(object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;

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