<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    // <Snippet1>
    void Application_Start(object sender, EventArgs e) 
    {
        RegisterRoutes(RouteTable.Routes);
    }
    // </Snippet1>

    // <Snippet122>
     void RegisterRoutes(RouteCollection routes)
    {
        //<Snippet140>
        routes.MapPageRoute("",
            "SalesReport/{locale}/{year}/{*queryvalues}", "~/sales.aspx");

        routes.MapPageRoute("SalesSummaryRoute",
            "SalesReportSummary/{locale}", "~/sales.aspx");
        //</Snippet140>

        //<Snippet145>
        routes.MapPageRoute("SalesDetailRoute",
            "SalesReportDetail/{locale}/{year}/{*queryvalues}", "~/sales.aspx",
            false);
        //</Snippet145>

        //<Snippet150>
        routes.MapPageRoute("SalesCurrentYearRoute",
            "SalesReportCurrent/{locale}/{year}/{*queryvalues}", "~/sales.aspx",
            false,
            new RouteValueDictionary 
                { { "locale", "US" }, { "year", DateTime.Now.Year.ToString() } });
        //</Snippet150>

        //<Snippet155>
        routes.MapPageRoute("ExpenseCurrentYearRoute",
            "ExpenseReportCurrent/{locale}", "~/expenses.aspx",
            false,
            new RouteValueDictionary 
                { { "locale", "US" }, { "year", DateTime.Now.Year.ToString() } },
            new RouteValueDictionary 
                { { "locale", "[a-z]{2}" }, { "year", @"\d{4}" } });
        //</Snippet155>

        //<Snippet160>
        routes.MapPageRoute("ExpenseDetailRoute",
            "ExpenseReportDetail/{locale}/{year}/{*queryvalues}", "~/expenses.aspx",
            false,
            new RouteValueDictionary 
                { { "locale", "US" }, { "year", DateTime.Now.Year.ToString() } },
            new RouteValueDictionary 
                { { "locale", "[a-z]{2}" }, { "year", @"\d{4}" } },
            new RouteValueDictionary 
                { { "account", "1234" }, { "subaccount", "5678" } });
        //</Snippet160>
        //<Snippet121>
    }
    //</Snippet121>
    //</Snippet122>
    
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
