    void Application_Start(object sender, EventArgs e) 
    {
        RegisterRoutes(RouteTable.Routes);
    }

    public static void RegisterRoutes(RouteCollection routes)
    {
        Route reportRoute = new Route("{locale}/{year}", new ReportRouteHandler());
        reportRoute.Defaults = new RouteValueDictionary { { "locale", "en-US" }, { "year", DateTime.Now.Year.ToString() } };
        reportRoute.Constraints = new RouteValueDictionary { { "locale", "[a-z]{2}-[a-z]{2}" }, { "year", @"\d{4}" } };
        reportRoute.DataTokens = new RouteValueDictionary { { "format", "short" } };
        routes.Add(reportRoute);
    }