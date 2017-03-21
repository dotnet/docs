    ' Create a resolver with default credentials.
    Dim resolver as XmlUrlResolver = new XmlUrlResolver()
    resolver.Credentials = System.Net.CredentialCache.DefaultCredentials

    ' Set the reader settings object to use the resolver.
    settings.XmlResolver = resolver

    ' Create the XmlReader object.
    Dim reader as XmlReader = XmlReader.Create("http://ServerName/data/books.xml", settings)