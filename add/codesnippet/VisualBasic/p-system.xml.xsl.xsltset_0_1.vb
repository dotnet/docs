' Create a resolver and specify the necessary credentials.
Dim resolver As New XmlSecureResolver(New XmlUrlResolver(), "http://serverName/data/")
Dim myCred As System.Net.NetworkCredential
myCred = New System.Net.NetworkCredential(UserName, SecurelyStoredPassword, Domain)
resolver.Credentials = myCred
        
' Create the XslCompiledTransform object and load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("http://serverName/data/script.xsl", XsltSettings.TrustedXslt, resolver)