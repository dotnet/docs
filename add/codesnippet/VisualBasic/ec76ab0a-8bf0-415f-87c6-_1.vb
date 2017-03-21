' Create the XslCompiledTransform object.
Dim xslt As New XslCompiledTransform()
        
' Create a resolver and set the credentials to use.
Dim resolver As New XmlSecureResolver(New XmlUrlResolver(), "http://serverName/data/")
resolver.Credentials = CredentialCache.DefaultCredentials
        
Dim reader As XmlReader = XmlReader.Create("http://serverName/data/xsl/sort.xsl")
        
' Create the XsltSettings object with script enabled.
Dim settings As New XsltSettings(False, True)
        
' Load the style sheet.
xslt.Load(reader, settings, resolver)