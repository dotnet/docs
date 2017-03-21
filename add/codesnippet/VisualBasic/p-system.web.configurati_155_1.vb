        ' Get CookieTimeout.
        Dim cookieTimeout As TimeSpan = _
        anonymousIdentificationSection.CookieTimeout
        Console.WriteLine( _
        "Cookie timeout: {0}", cookieTimeout.ToString())