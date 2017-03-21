// Create an XmlSecureResolver with default credentials.
XmlSecureResolver myResolver = new XmlSecureResolver(new XmlUrlResolver(), "http://serverName/data/");
myResolver.Credentials = CredentialCache.DefaultCredentials;

XmlReaderSettings settings = new XmlReaderSettings();
settings.XmlResolver = myResolver;

// Create the reader.
XmlReader reader = XmlReader.Create("http://serverName/data/books.xml", settings);
