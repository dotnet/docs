<%@ Application Language="C#" %>

<script runat="server">

    //<snippet1>
    void Application_BeginRequest(Object sender, EventArgs e)
    {
        string originalPath = HttpContext.Current.Request.Path.ToLower();
        if (originalPath.Contains("/page1"))
        {
            Context.RewritePath(originalPath.Replace("/page1", "/RewritePath.aspx?page=page1"));
        }
        if (originalPath.Contains("/page2"))
        {
            Context.RewritePath(originalPath.Replace("/page2", "/RewritePath.aspx"), "pathinfo", "page=page2");
        }
    }    
    //</snippet1>
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
    void Profile_MigrateAnonymous(Object sender,
       ProfileMigrateEventArgs e)
    {
        if (Profile.GetProfile(e.AnonymousID).PostalCode != String.Empty)
        {
            Profile.PostalCode =
                Profile.GetProfile(e.AnonymousID).PostalCode;
        }
    }
  
</script>
