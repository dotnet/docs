
' Create a resolver with default credentials.
Dim resolver as XmlUrlResolver = new XmlUrlResolver()
resolver.Credentials = System.Net.CredentialCache.DefaultCredentials

' Create the XslTransform object.
Dim xslt as XslTransform = new XslTransform()

' Load the stylesheet.
xslt.Load("http://myServer/data/authors.xsl", resolver)

' Transform the file. 
xslt.Transform("books.xml", "titles.xml", resolver)