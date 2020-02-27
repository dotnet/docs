<%@ Application Language="C#" %>

<script runat="server">

    // <snippet1>
    void Application_Start(object sender, EventArgs e)
    {
        System.Web.ApplicationServices.AuthenticationService.CreatingCookie 
            += new EventHandler<System.Web.ApplicationServices.CreatingCookieEventArgs>
            (AuthenticationService_CreatingCookie);
    }
    // </snippet1>
    
    
    // <snippet2>
    void AuthenticationService_CreatingCookie(object sender, 
        System.Web.ApplicationServices.CreatingCookieEventArgs e)
    {
        FormsAuthenticationTicket ticket = new
              FormsAuthenticationTicket
                (1,
                 e.UserName,
                 DateTime.Now,
                 DateTime.Now.AddMinutes(30),
                 e.IsPersistent,
                 e.CustomCredential,
                 FormsAuthentication.FormsCookiePath);

        string encryptedTicket =
             FormsAuthentication.Encrypt(ticket);

        HttpCookie cookie = new HttpCookie
             (FormsAuthentication.FormsCookieName,
              encryptedTicket);
        cookie.Expires = DateTime.Now.AddMinutes(30);

        HttpContext.Current.Response.Cookies.Add(cookie);
        e.CookieIsSet = true;
    }
    // </snippet2>

    
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
