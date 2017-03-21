// Create the credentials.
NetworkCredential myCred = new NetworkCredential(UserName,SecurelyStoredPassword,Domain); 
CredentialCache myCache = new CredentialCache(); 
myCache.Add(new Uri("http://www.contoso.com/"), "Basic", myCred); 
myCache.Add(new Uri("http://app.contoso.com/"), "Basic", myCred);

// Set the credentials on the XmlUrlResolver object.
XmlUrlResolver resolver = new XmlUrlResolver();
resolver.Credentials = myCache;

// Compile the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("http://serverName/data/xsl/order.xsl",XsltSettings.Default, resolver);	