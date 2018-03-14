<%@ Application Language="VB" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    ' <Snippet1>
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        RegisterRoutes(RouteTable.Routes)
    End Sub
    ' </Snippet1>
    
    ' <Snippet122>
    Sub RegisterRoutes(ByVal routes As RouteCollection)
        '<Snippet140>
        routes.MapPageRoute("",
            "SalesReport/{locale}/{year}/{*queryvalues}", "~/sales.aspx")

        routes.MapPageRoute("SalesSummaryRoute",
            "SalesReportSummary/{locale}", "~/sales.aspx")
        '</Snippet140>

        '<Snippet145>
        routes.MapPageRoute("SalesDetailRoute",
            "SalesReportDetail/{locale}/{year}/{*queryvalues}", "~/sales.aspx",
            False)
        '</Snippet145>

        '<Snippet150>
        routes.MapPageRoute("SalesCurrentYearRoute",
            "SalesReportCurrent/{locale}/{year}/{*queryvalues}", "~/sales.aspx",
            false,
            new RouteValueDictionary(New With _ 
                { .locale = "US", .year = DateTime.Now.Year.ToString()}))
        '</Snippet150>

        '<Snippet155>
        routes.MapPageRoute("ExpenseCurrentYearRoute",
            "ExpenseReportCurrent/{locale}", "~/expenses.aspx",
            false,
            new RouteValueDictionary(New With _
                { .locale = "US", .year = DateTime.Now.Year.ToString()}),
            new RouteValueDictionary(New With _
                { .locale = "[a-z]{2}", .year = "\d{4}" }))
        '</Snippet155>

        '<Snippet160>
        routes.MapPageRoute("ExpenseDetailRoute",
            "ExpenseReportDetail/{locale}/{year}/{*queryvalues}", "~/expenses.aspx",
            false,
            new RouteValueDictionary(New With _
                { .locale = "US", .year = DateTime.Now.Year.ToString()}),
            new RouteValueDictionary(New With _ 
                { .locale = "[a-z]{2}", .year = "\d{4}" }),
            new RouteValueDictionary(New With _
                { .account = "1234", .subaccount = "5678" }))
        '</Snippet160>
    End Sub
    '</Snippet122>
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub

</script>