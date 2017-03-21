        routes.MapPageRoute("SalesCurrentYearRoute",
            "SalesReportCurrent/{locale}/{year}/{*queryvalues}", "~/sales.aspx",
            false,
            new RouteValueDictionary 
                { { "locale", "US" }, { "year", DateTime.Now.Year.ToString() } });