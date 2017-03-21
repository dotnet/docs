// Create a resolver and specify the necessary credentials.
XmlSecureResolver resolver = new XmlSecureResolver(new XmlUrlResolver(), "http://serverName/data/");
System.Net.NetworkCredential myCred;
myCred  = new System.Net.NetworkCredential(UserName,SecurelyStoredPassword,Domain);  
resolver.Credentials = myCred;

XsltSettings settings = new XsltSettings();
settings.EnableDocumentFunction = true;
  
// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("http://serverName/data/xsl/sort.xsl", settings, resolver);

// Transform the file.
using (XmlReader reader = XmlReader.Create("books.xml"))
{
   using (XmlWriter writer = XmlWriter.Create("output.xml")) 
   {
      xslt.Transform(reader, null, writer, resolver);
   }
}