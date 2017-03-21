    void Application_Start(object sender, EventArgs e) 
    {
        System.Web.ApplicationServices.AuthenticationService.Authenticating += 
            new EventHandler<System.Web.ApplicationServices.AuthenticatingEventArgs>(AuthenticationService_Authenticating);

    }