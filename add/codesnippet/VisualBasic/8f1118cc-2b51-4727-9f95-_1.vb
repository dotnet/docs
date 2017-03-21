' Create a resolver and specify the necessary credentials.
Dim resolver As New XmlUrlResolver()
Dim myCred As System.Net.NetworkCredential
myCred = New System.Net.NetworkCredential(UserName, SecurelyStoredPassword, Domain)
resolver.Credentials = myCred
        
' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load(New XPathDocument("http://serverName/data/xsl/sort.xsl"), XsltSettings.Default, resolver)