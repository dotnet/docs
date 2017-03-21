    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        RegisterRoutes(RouteTable.Routes)
    End Sub
    
    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        Dim urlPattern As String
        Dim categoryRoute As Route
        
        urlPattern = "Category/{action}/{categoryName}"
        
        categoryRoute = New Route(urlPattern, New CategoryRouteHandler)
        
        routes.Add(categoryRoute)
    End Sub