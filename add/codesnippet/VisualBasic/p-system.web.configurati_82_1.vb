
            ' Get the current RequireSSL.
            Dim requireSSLValue As Boolean = _
            httpCookiesSection.RequireSSL

            ' Set the RequireSSL.
            httpCookiesSection.RequireSSL = _
            False
