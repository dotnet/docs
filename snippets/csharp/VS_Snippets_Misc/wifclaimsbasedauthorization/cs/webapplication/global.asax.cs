//-----------------------------------------------------------------------------
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
//
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

        }

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
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            // User needs to be redirected back to the originally requested page.
            // WSFAM will only parse the WSFed message and redirect back to the page there, 
            // which is Login/?ReturnUrl=<OriginallyRequestedPage>.
            // So the following code handles the last redirection step.
            // This needs to be in EndRequest, because WsFAM calls Application.CompleteRequest after doing its redirect.
            string wsFamRedirectLocation = HttpContext.Current.Response.RedirectLocation;
            if (wsFamRedirectLocation != null && wsFamRedirectLocation.Contains("ReturnUrl") && User.Identity.IsAuthenticated && User.Identity.AuthenticationType == "Federation")
            {
                HttpContext.Current.Response.RedirectLocation =
                    HttpUtility.ParseQueryString(wsFamRedirectLocation.Split('?')[1])["ReturnUrl"];
            }
        }
    }
}
