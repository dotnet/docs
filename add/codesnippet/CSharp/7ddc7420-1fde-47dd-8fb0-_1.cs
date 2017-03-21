// Create the XslCompiledTransform object.
XslCompiledTransform xslt = new XslCompiledTransform();

// Create a resolver and set the credentials to use.
XmlSecureResolver resolver = new XmlSecureResolver(new XmlUrlResolver(), "http://serverName/data/");
resolver.Credentials = CredentialCache.DefaultCredentials;
  
// Load the style sheet.
xslt.Load("http://serverName/data/xsl/sort.xsl", null, resolver);