        routes.MapPageRoute("SalesCurrentYearRoute",
            "SalesReportCurrent/{locale}/{year}/{*queryvalues}", "~/sales.aspx",
            false,
            new RouteValueDictionary(New With _ 
                { .locale = "US", .year = DateTime.Now.Year.ToString()}))