        RouteValueDictionary parameters = new RouteValueDictionary { { "action", "show" }, { "categoryName", "bikes" } };
        VirtualPathData vpd = RouteTable.Routes.GetVirtualPath(null, parameters);
        HyperLink1.NavigateUrl = vpd.VirtualPath;