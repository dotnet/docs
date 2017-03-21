// Create an XmlUrlResolver with the credentials necessary to access the Web server.
XmlUrlResolver resolver = new XmlUrlResolver();
System.Net.NetworkCredential myCred;
myCred  = new System.Net.NetworkCredential(UserName,SecurelyStoredPassword,Domain);  
resolver.Credentials = myCred;

XmlReaderSettings settings = new XmlReaderSettings();
settings.XmlResolver = resolver;

// Create the reader.
XmlReader reader = XmlReader.Create("http://serverName/data/books.xml", settings);