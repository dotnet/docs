        ' Create an XmlUrlResolver with default credentials.
        Dim resolver As New XmlUrlResolver()
        resolver.Credentials = CredentialCache.DefaultCredentials
        
        ' Create the reader.
        Dim settings As New XmlReaderSettings()
        settings.XmlResolver = resolver
        Dim reader As XmlReader = _
           XmlReader.Create("http://serverName/data/books.xml", settings)
