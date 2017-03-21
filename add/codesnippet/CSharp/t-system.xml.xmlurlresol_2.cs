
    // Create an XmlUrlResolver with default credentials.
    XmlUrlResolver resolver = new XmlUrlResolver();
    resolver.Credentials = CredentialCache.DefaultCredentials;

    // Create the reader.
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.XmlResolver = resolver;
    XmlReader reader = 
         XmlReader.Create("http://serverName/data/books.xml", settings);
   