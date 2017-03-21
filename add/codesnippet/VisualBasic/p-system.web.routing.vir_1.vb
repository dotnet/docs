        Dim vpd As VirtualPathData
        Dim parameters As RouteValueDictionary

        parameters = New RouteValueDictionary(New With {.action = "show", .categoryName = "bikes"})
        vpd = RouteTable.Routes.GetVirtualPath(Nothing, parameters)
        HyperLink1.NavigateUrl = vpd.VirtualPath