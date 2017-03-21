// Create the XslTransform object.
XslTransform xslt = new XslTransform();

// Load the stylesheet.
xslt.Load("titles.xsl");

// Create a resolver and specify the necessary credentials.
XmlUrlResolver resolver = new XmlUrlResolver();
System.Net.NetworkCredential myCred;
myCred  = new System.Net.NetworkCredential(UserName,SecurelyStoredPassword,Domain);  
resolver.Credentials = myCred;

// Transform the file using the resolver. The resolver is used
// to process the XSLT document() function.
XPathDocument doc = new XPathDocument("books.xml");
XmlReader reader = xslt.Transform(doc, null, resolver);

// Load the reader into a new document for more processing.
XmlDocument xmldoc = new XmlDocument();
xmldoc.Load(reader);