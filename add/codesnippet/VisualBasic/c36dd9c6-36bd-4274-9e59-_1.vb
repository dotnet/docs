' Create a resolver and specify the necessary credentials.
Dim resolver As New XmlSecureResolver(New XmlUrlResolver(), "http://serverName/data/")
Dim myCred As System.Net.NetworkCredential
myCred = New System.Net.NetworkCredential(UserName, SecurelyStoredPassword, Domain)
resolver.Credentials = myCred
        
Dim settings As New XsltSettings()
settings.EnableDocumentFunction = True
        
' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("http://serverName/data/xsl/sort.xsl", settings, resolver)
        
' Transform the file.
        Using reader As XmlReader = XmlReader.Create("books.xml")

            Using writer As XmlWriter = XmlWriter.Create("output.xml")
                xslt.Transform(reader, Nothing, writer, resolver)
            End Using

        End Using