' Create an XmlSecureResolver with default credentials.
Dim myResolver As New XmlSecureResolver(New XmlUrlResolver(), "http://serverName/data/")
myResolver.Credentials = CredentialCache.DefaultCredentials

Dim settings As New XmlReaderSettings()
settings.XmlResolver = myResolver

' Create the reader.
Dim reader As XmlReader = XmlReader.Create("http://serverName/data/books.xml", settings)
