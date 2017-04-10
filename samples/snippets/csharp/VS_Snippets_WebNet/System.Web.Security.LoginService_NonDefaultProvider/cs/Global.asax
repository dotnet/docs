<%@ Application Language="C#" %>

<script runat="server">

    // <Snippet1>
    void Application_Start(object sender, EventArgs e)
    {
        System.Web.ApplicationServices.AuthenticationService.Authenticating +=
            new EventHandler<System.Web.ApplicationServices.AuthenticatingEventArgs>(AuthenticationService_Authenticating);
    }
    // </Snippet1>

    // <Snippet2>
    void AuthenticationService_Authenticating(object sender, System.Web.ApplicationServices.AuthenticatingEventArgs e)
    {
        if (e.UserName.IndexOf("@contoso.com") >= 0)
        {
            e.Authenticated = Membership.Providers["ContosoSqlProvider"].ValidateUser(e.UserName, e.Password);
        }
        else if (e.UserName.IndexOf("@fabrikam.com") >= 0)
        {
            e.Authenticated = Membership.Providers["FabrikamSqlProvider"].ValidateUser(e.UserName, e.Password);
        }
        else
        {
            e.Authenticated = Membership.Provider.ValidateUser(e.UserName, e.Password);
        }
        e.AuthenticationIsComplete = true;
    }
    // </Snippet2>
    
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
       
</script>
