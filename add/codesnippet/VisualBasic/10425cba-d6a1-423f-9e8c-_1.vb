        Dim myCache As New CredentialCache()
        
        myCache.Add(New Uri("http://www.contoso.com/"), "Basic", New NetworkCredential(UserName, SecurelyStoredPassword))
        myCache.Add(New Uri("http://www.contoso.com/"), "Digest", New NetworkCredential(UserName, SecurelyStoredPassword, Domain))
        
        wReq.Credentials = myCache