    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        RegisterRoutes(RouteTable.Routes)
    End Sub
    
    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        Dim urlPattern As String
        Dim reportRoute As Route
        
        urlPattern = "{locale}/{year}"
        
        reportRoute = New Route(urlPattern, New ReportRouteHandler)
        
        reportRoute.Defaults = New RouteValueDictionary(New With {.months = "all"})
        
        routes.Add(reportRoute)
    End Sub