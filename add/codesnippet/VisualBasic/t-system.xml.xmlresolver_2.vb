' Create the credentials.
Dim myCred As NetworkCredential = New NetworkCredential(UserName,SecurelyStoredPassword,Domain)
Dim myCache As CredentialCache = New CredentialCache()
myCache.Add(new Uri("http://www.contoso.com/"), "Basic", myCred)
myCache.Add(new Uri("http://app.contoso.com/"), "Basic", myCred)

' Set the credentials on the XmlUrlResolver object.
Dim resolver As XmlUrlResolver = New XmlUrlResolver()
resolver.Credentials = myCache

' Compile the style sheet.
Dim xslt As XslCompiledTransform = New XslCompiledTransform()
xslt.Load("http://serverName/data/xsl/order.xsl", XsltSettings.Default, resolver)
