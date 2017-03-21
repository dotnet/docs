    void Application_Start(object sender, EventArgs e) 
    {
        RegisterRoutes(RouteTable.Routes);
    }

    public static void RegisterRoutes(RouteCollection routes)
    {
        Route reportRoute = new Route("{locale}/{year}", new ReportRouteHandler());
        
        reportRoute.Defaults = new RouteValueDictionary { { "months", "all" } };
        
        routes.Add(reportRoute);
    }