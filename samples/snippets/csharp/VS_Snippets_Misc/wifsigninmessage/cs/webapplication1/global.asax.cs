using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using System.IdentityModel.Services;

namespace SAM
{
    public class Global : System.Web.HttpApplication
    {



        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            //SUBSCRIBE TO SAM EVENTS
            FederatedAuthentication.SessionAuthenticationModule.SessionSecurityTokenCreated += new EventHandler<SessionSecurityTokenCreatedEventArgs>(SessionAuthenticationModule_SessionSecurityTokenCreated);
            FederatedAuthentication.SessionAuthenticationModule.SessionSecurityTokenReceived += new EventHandler<SessionSecurityTokenReceivedEventArgs>(SessionAuthenticationModule_SessionSecurityTokenReceived);
            FederatedAuthentication.SessionAuthenticationModule.SigningOut += new EventHandler<SigningOutEventArgs>(SessionAuthenticationModule_SigningOut);
            FederatedAuthentication.SessionAuthenticationModule.SignedOut += new EventHandler(SessionAuthenticationModule_SignedOut);
            FederatedAuthentication.SessionAuthenticationModule.SignOutError += new EventHandler<ErrorEventArgs>(SessionAuthenticationModule_SignOutError);
        }

        void SessionAuthenticationModule_SignOutError(object sender, ErrorEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Handling SignOutError event");
        }

        void SessionAuthenticationModule_SignedOut(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Handling SignedOut event");
        }

        void SessionAuthenticationModule_SigningOut(object sender, SigningOutEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Handling SigningOut event");
        }

        void SessionAuthenticationModule_SessionSecurityTokenReceived(object sender, SessionSecurityTokenReceivedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Handling SessionSecurityTokenReceived event");
        }

        void SessionAuthenticationModule_SessionSecurityTokenCreated(object sender, SessionSecurityTokenCreatedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Handling SessionSecurityTokenCreated event");
            //Store session on the server-side token cache instead writing the whole token to the cookie.
            //It may improve throughput but introduces server affinity that may affect scalability
            FederatedAuthentication.SessionAuthenticationModule.IsReferenceMode = true;
        }

        //========

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
        
        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
