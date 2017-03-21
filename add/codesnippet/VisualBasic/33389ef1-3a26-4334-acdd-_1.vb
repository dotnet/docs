' Create the XslTransform object.
Dim xslt as XslTransform = new XslTransform()

' Load the stylesheet.
xslt.Load("titles.xsl")

' Create a resolver and specify the necessary credentials.
Dim resolver as XmlUrlResolver = new XmlUrlResolver()
Dim myCred as System.Net.NetworkCredential 
myCred = new System.Net.NetworkCredential(UserName,SecurelyStoredPassword,Domain)
resolver.Credentials = myCred

' Transform thefile using the resolver. The resolver is used
' to process the XSLT document() function.
Dim doc as XPathDocument = new XPathDocument("books.xml")
Dim reader as XmlReader = xslt.Transform(doc, nothing, resolver)

' Load the reader into a new document for more processing.
Dim xmldoc as XmlDocument = new XmlDocument()
xmldoc.Load(reader)