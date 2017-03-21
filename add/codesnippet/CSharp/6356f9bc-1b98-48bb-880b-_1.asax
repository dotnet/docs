        routes.MapPageRoute("ExpenseCurrentYearRoute",
            "ExpenseReportCurrent/{locale}", "~/expenses.aspx",
            false,
            new RouteValueDictionary 
                { { "locale", "US" }, { "year", DateTime.Now.Year.ToString() } },
            new RouteValueDictionary 
                { { "locale", "[a-z]{2}" }, { "year", @"\d{4}" } });