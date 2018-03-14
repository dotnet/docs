<%@ Application Language="C#" %>
<%@ Import Namespace="System.IdentityModel.Services.Configuration" %>
<%@ Import Namespace="System.IdentityModel.Services" %>

<script runat="server">

    void Application_Init(object sender, EventArgs e)
    {
        // Code that runs on application init.
        FederatedAuthentication.WSFederationAuthenticationModule.RedirectingToIdentityProvider += new EventHandler<RedirectingToIdentityProviderEventArgs>(WSFederationAuthentication_RedirectingToIdentityProvider);
    }

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

    //<Snippet3>
    void WSFederationAuthentication_RedirectingToIdentityProvider(object sender, RedirectingToIdentityProviderEventArgs e)
    {
        // Check if 'whr' parameter is specified.
        string identityProviderUri = HttpContext.Current.Request.QueryString["whr"];
        string action = HttpContext.Current.Request.QueryString["wa"];

        if (action == "wsignin1.0")
        {
            if (String.IsNullOrEmpty(identityProviderUri))
            {
                // Forward the user to the IdentityProvider selection page.
                identityProviderUri = "http://localhost:3000/FPSTS/homeRealmSelectionPage.aspx";
            }

            e.SignInRequestMessage.BaseUri = new Uri(identityProviderUri);
            e.SignInRequestMessage.Realm = "http://localhost:3000/FPSTS/Default.aspx";
            e.SignInRequestMessage.Context = HttpContext.Current.Request.QueryString.ToString();
        }
    }
    //</Snippet3>
       
</script>
