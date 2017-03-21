// Create the XslCompiledTransform object.
XslCompiledTransform xslt = new XslCompiledTransform();

// Create a resolver and set the credentials to use.
XmlSecureResolver resolver = new XmlSecureResolver(new XmlUrlResolver(), "http://serverName/data/");
resolver.Credentials = CredentialCache.DefaultCredentials;
  
XmlReader reader = XmlReader.Create("http://serverName/data/xsl/sort.xsl");

// Create the XsltSettings object with script enabled.
XsltSettings settings = new XsltSettings(false,true);

// Load the style sheet.
xslt.Load(reader, settings, resolver);