    CredentialCache myCache = new CredentialCache();

    myCache.Add(new Uri("http://www.contoso.com/"),"Basic",new NetworkCredential(UserName,SecurelyStoredPassword));
    myCache.Add(new Uri("http://www.contoso.com/"),"Digest", new NetworkCredential(UserName,SecurelyStoredPassword,Domain));

    wReq.Credentials = myCache;