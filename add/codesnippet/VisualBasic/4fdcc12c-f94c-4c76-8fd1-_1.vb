        ' Get CookieSlidingExpiration.
        Dim cookieSlidingExpiration As Boolean = _
        anonymousIdentificationSection.CookieSlidingExpiration
        Console.WriteLine( _
        "Cookie sliding expiration: {0}", _
        cookieSlidingExpiration.ToString())