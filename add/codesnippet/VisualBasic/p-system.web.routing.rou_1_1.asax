    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        RegisterRoutes(RouteTable.Routes)
    End Sub
    
    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        Dim urlPattern As String
        Dim reportRoute As Route
        
        urlPattern = "{locale}/{year}"
        
        reportRoute = New Route(urlPattern, New ReportRouteHandler)
        reportRoute.Defaults = New RouteValueDictionary(New With {.locale = "en-US", .year = DateTime.Now.Year.ToString()})
        reportRoute.Constraints = New RouteValueDictionary(New With {.locale = "[a-z]{2}-[a-z]{2}", .year = "\d{4}"})
        reportRoute.DataTokens = New RouteValueDictionary(New With {.format = "short"})

        routes.Add(reportRoute)
    End Sub