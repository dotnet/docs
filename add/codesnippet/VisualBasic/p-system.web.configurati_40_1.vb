        ' Get CookieProtection.
        Dim cookieProtection _
        As System.Web.Security.CookieProtection = _
        anonymousIdentificationSection.CookieProtection
        Console.WriteLine( _
        "Cookie protection: {0}", cookieProtection)