        ' Create an XmlUrlResolver with the credentials necessary to access the Web server.
        Dim resolver As New XmlUrlResolver()
        Dim myCred As System.Net.NetworkCredential
        myCred = New System.Net.NetworkCredential(UserName, SecurelyStoredPassword, Domain)
        resolver.Credentials = myCred
        
        Dim settings As New XmlReaderSettings()
        settings.XmlResolver = resolver
        
        ' Create the reader.
        Dim reader As XmlReader = XmlReader.Create("http://serverName/data/books.xml", settings)