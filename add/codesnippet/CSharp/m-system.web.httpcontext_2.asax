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