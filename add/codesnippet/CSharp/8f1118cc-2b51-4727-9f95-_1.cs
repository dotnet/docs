// Create a resolver and specify the necessary credentials.
XmlUrlResolver resolver = new XmlUrlResolver();
System.Net.NetworkCredential myCred;
myCred  = new System.Net.NetworkCredential(UserName,SecurelyStoredPassword,Domain);  
resolver.Credentials = myCred;
  
// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load(new XPathDocument("http://serverName/data/xsl/sort.xsl"), XsltSettings.Default, resolver);