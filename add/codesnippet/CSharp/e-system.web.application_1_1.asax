    void Application_Start(object sender, EventArgs e)
    {
        System.Web.ApplicationServices.AuthenticationService.CreatingCookie 
            += new EventHandler<System.Web.ApplicationServices.CreatingCookieEventArgs>
            (AuthenticationService_CreatingCookie);
    }