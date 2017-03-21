' Create the XslCompiledTransform object.
Dim xslt As New XslCompiledTransform()
        
' Create a resolver and set the credentials to use.
Dim resolver As New XmlSecureResolver(New XmlUrlResolver(), "http://serverName/data/")
resolver.Credentials = CredentialCache.DefaultCredentials
        
' Load the style sheet.
xslt.Load("http://serverName/data/xsl/sort.xsl", Nothing, resolver)