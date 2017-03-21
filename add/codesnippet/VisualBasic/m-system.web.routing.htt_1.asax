    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        RegisterRoutes(RouteTable.Routes)
    End Sub
    
    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        Dim urlPattern As String
        Dim reportRoute As Route
        Dim allowedMethods() As String = {"GET", "POST"}
        Dim methodConstraints As HttpMethodConstraint  
        
        methodConstraints = New HttpMethodConstraint(allowedMethods)
        
        Dim constraintValues = New With {.httpMethod = methodConstraints}
        
        urlPattern = "{locale}/{year}"
        
        reportRoute = New Route(urlPattern, New ReportRouteHandler)
        reportRoute.Constraints = New RouteValueDictionary(constraintValues)
        
        routes.Add(reportRoute)
    End Sub