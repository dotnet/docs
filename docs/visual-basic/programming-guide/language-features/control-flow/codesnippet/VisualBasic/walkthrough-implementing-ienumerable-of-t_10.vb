        Dim adminRequests = 
            From line In New StreamReaderEnumerable("..\..\log.txt")
            Where line.Contains("admin.aspx 401")

        Dim results = adminRequests.ToList()