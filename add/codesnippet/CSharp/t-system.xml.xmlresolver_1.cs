    // Create a resolver with default credentials.
    XmlUrlResolver resolver = new XmlUrlResolver();
    resolver.Credentials = System.Net.CredentialCache.DefaultCredentials;
  
    // Set the reader settings object to use the resolver.
    settings.XmlResolver = resolver;

    // Create the XmlReader object.
    XmlReader reader = XmlReader.Create("http://ServerName/data/books.xml", settings);