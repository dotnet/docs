NetworkCredential myCred = new NetworkCredential(
	SecurelyStoredUserName,SecurelyStoredPassword,SecurelyStoredDomain);
 
CredentialCache myCache = new CredentialCache();
 
myCache.Add(new Uri("www.contoso.com"), "Basic", myCred);
myCache.Add(new Uri("app.contoso.com"), "Basic", myCred);
 
WebRequest wr = WebRequest.Create("www.contoso.com");
wr.Credentials = myCache;
