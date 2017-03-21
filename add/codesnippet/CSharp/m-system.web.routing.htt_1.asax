    void Application_Start(object sender, EventArgs e) 
    {
        RegisterRoutes(RouteTable.Routes);
    }

    public static void RegisterRoutes(RouteCollection routes)
    {
        string[] allowedMethods = { "GET", "POST" };
        HttpMethodConstraint methodConstraints = new HttpMethodConstraint(allowedMethods);

        Route reportRoute = new Route("{locale}/{year}", new ReportRouteHandler());
        reportRoute.Constraints = new RouteValueDictionary { { "httpMethod", methodConstraints } };

        routes.Add(reportRoute);
    }