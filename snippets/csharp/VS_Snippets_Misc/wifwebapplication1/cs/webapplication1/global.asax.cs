using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using System.IdentityModel.Services;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {



        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            FederatedAuthentication.WSFederationAuthenticationModule.AuthorizationFailed += new EventHandler<AuthorizationFailedEventArgs>(WSFederationAuthenticationModule_AuthorizationFailed);
            FederatedAuthentication.WSFederationAuthenticationModule.RedirectingToIdentityProvider += new EventHandler<RedirectingToIdentityProviderEventArgs>(WSFederationAuthenticationModule_RedirectingToIdentityProvider);
            FederatedAuthentication.WSFederationAuthenticationModule.SecurityTokenReceived += new EventHandler<SecurityTokenReceivedEventArgs>(WSFederationAuthenticationModule_SecurityTokenReceived);
            FederatedAuthentication.WSFederationAuthenticationModule.SecurityTokenValidated += new EventHandler<SecurityTokenValidatedEventArgs>(WSFederationAuthenticationModule_SecurityTokenValidated);
            FederatedAuthentication.WSFederationAuthenticationModule.SessionSecurityTokenCreated += new EventHandler<SessionSecurityTokenCreatedEventArgs>(WSFederationAuthenticationModule_SessionSecurityTokenCreated);
            FederatedAuthentication.WSFederationAuthenticationModule.SignedIn += new EventHandler(WSFederationAuthenticationModule_SignedIn);
        }

        void WSFederationAuthenticationModule_SignedIn(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Handling SignIn event");
        }

        void WSFederationAuthenticationModule_SessionSecurityTokenCreated(object sender, SessionSecurityTokenCreatedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Handling SessionSecurityTokenCreated event");
        }

        void WSFederationAuthenticationModule_SecurityTokenValidated(object sender, SecurityTokenValidatedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Handling SecurityTokenValidated event");
        }

        void WSFederationAuthenticationModule_SecurityTokenReceived(object sender, SecurityTokenReceivedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Handling SecurityTokenReceived event");
        }
        void WSFederationAuthenticationModule_AuthorizationFailed(object sender, AuthorizationFailedEventArgs e)
        {
            //USE IT FOR CUSTOMIZING ACTION TO BE TAKEN ON FAILED AUTHENTICATION.
            //FOR EXAMPLE REPORT TO LOG. SIMPLE EXAMPLE COULD BE REPORTING TO 
            //TRACE THAT CAN BE CAPTURED USING TRACELISTENER CONFIGURED IN WEB.CONFIG OR USING SYSINTERNAL's DEBUGVIEW
            System.Diagnostics.Trace.WriteLine("WIF AUTHOIRZATON FAILED");

        }
        void WSFederationAuthenticationModule_RedirectingToIdentityProvider(object sender, RedirectingToIdentityProviderEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Handling RedirectingToIdentityProvider event");
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
