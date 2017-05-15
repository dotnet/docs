using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using System.IdentityModel.Services;

namespace WSFAM
{
    public class Global : System.Web.HttpApplication
    {

        //<Snippet1>

        //<Snippet2>
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            //SUBSCRIBE TO WSFAM EVENTS
            FederatedAuthentication.WSFederationAuthenticationModule.AuthorizationFailed += new EventHandler<AuthorizationFailedEventArgs>(WSFederationAuthenticationModule_AuthorizationFailed);
            FederatedAuthentication.WSFederationAuthenticationModule.RedirectingToIdentityProvider += new EventHandler<RedirectingToIdentityProviderEventArgs>(WSFederationAuthenticationModule_RedirectingToIdentityProvider);
            FederatedAuthentication.WSFederationAuthenticationModule.SecurityTokenReceived += new EventHandler<SecurityTokenReceivedEventArgs>(WSFederationAuthenticationModule_SecurityTokenReceived);
            FederatedAuthentication.WSFederationAuthenticationModule.SecurityTokenValidated += new EventHandler<SecurityTokenValidatedEventArgs>(WSFederationAuthenticationModule_SecurityTokenValidated);
            FederatedAuthentication.WSFederationAuthenticationModule.SessionSecurityTokenCreated += new EventHandler<SessionSecurityTokenCreatedEventArgs>(WSFederationAuthenticationModule_SessionSecurityTokenCreated);
            FederatedAuthentication.WSFederationAuthenticationModule.SignedIn += new EventHandler(WSFederationAuthenticationModule_SignedIn);
        }
        //</Snippet2>

        //<Snippet3>
        void WSFederationAuthenticationModule_SignedIn(object sender, EventArgs e)
        {
            //Anything that's needed right after succesful session and before hitting the application code goes here
            System.Diagnostics.Trace.WriteLine("Handling SignIn event");
        }
        //</Snippet3>

        //<Snippet4>
        void WSFederationAuthenticationModule_SessionSecurityTokenCreated(object sender, SessionSecurityTokenCreatedEventArgs e)
        {
            //Manipulate session token here, for example, changing its expiration value
            System.Diagnostics.Trace.WriteLine("Handling SessionSecurityTokenCreated event");
            System.Diagnostics.Trace.WriteLine("Key valid from: " + e.SessionToken.KeyEffectiveTime);
            System.Diagnostics.Trace.WriteLine("Key expires on: " + e.SessionToken.KeyExpirationTime);
        }
        //</Snippet4>

        //<Snippet5>
        void WSFederationAuthenticationModule_SecurityTokenValidated(object sender, SecurityTokenValidatedEventArgs e)
        {
            //All vlidation SecurityTokenHandler checks are successful
            System.Diagnostics.Trace.WriteLine("Handling SecurityTokenValidated event");
        }
        //</Snippet5>

        //<Snippet6>
        void WSFederationAuthenticationModule_SecurityTokenReceived(object sender, SecurityTokenReceivedEventArgs e)
        {
            //Augment token validation with your cusotm validation checks without invalidating the token.
            System.Diagnostics.Trace.WriteLine("Handling SecurityTokenReceived event");
        }
        //</Snippet6>

        //<Snippet7>
        void WSFederationAuthenticationModule_AuthorizationFailed(object sender, AuthorizationFailedEventArgs e)
        {
            //Use this event to report more details regarding the ahorization failure
            System.Diagnostics.Trace.WriteLine("Handling AuthorizationFailed event");

        }
        //</Snippet7>

        //<Snippet8>
        void WSFederationAuthenticationModule_RedirectingToIdentityProvider(object sender, RedirectingToIdentityProviderEventArgs e)
        {
            //Use this event to programmatically modify the sign-in message to the STS.
            System.Diagnostics.Trace.WriteLine("Handling RedirectingToIdentityProvider event");
        }
        //</Snippet8>

        //</Snippet1>

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
