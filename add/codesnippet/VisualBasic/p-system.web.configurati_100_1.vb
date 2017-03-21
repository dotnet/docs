        ' Get CookieRequireSSL.
        Dim cookieRequireSSL As Boolean = _
        anonymousIdentificationSection.CookieRequireSSL
        Console.WriteLine("Cookie require SSL: {0}", _
        cookieRequireSSL.ToString())