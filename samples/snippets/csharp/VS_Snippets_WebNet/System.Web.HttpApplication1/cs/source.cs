// <Snippet1>
using System;
using System.Web;

namespace Samples.AspNet.CS
{
    public class CustomHTTPModule : IHttpModule
    {
        public CustomHTTPModule()
        {
            // Class constructor.
        }

        // Classes that inherit IHttpModule 
        // must implement the Init and Dispose methods.
        public void Init(HttpApplication app)
        {

            app.AcquireRequestState += new EventHandler(app_AcquireRequestState);
			app.PostAcquireRequestState += new EventHandler(app_PostAcquireRequestState);
		}

        public void Dispose()
        {
            // Add code to clean up the
            // instance variables of a module.
        }

        // Define a custom AcquireRequestState event handler.
        public void app_AcquireRequestState(object o, EventArgs ea)
        {
            HttpApplication httpApp = (HttpApplication)o;
            HttpContext ctx = HttpContext.Current;
            ctx.Response.Write(" Executing AcquireRequestState ");
        }

        // Define a custom PostAcquireRequestState event handler.
		public void app_PostAcquireRequestState(object o, EventArgs ea)
		{
			HttpApplication httpApp = (HttpApplication)o;
			HttpContext ctx = HttpContext.Current;
			ctx.Response.Write(" Executing PostAcquireRequestState ");
		}

	}
}
// </Snippet1>
