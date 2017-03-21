   // Create a resolver with default credentials.
   XmlUrlResolver^ resolver = gcnew XmlUrlResolver;
   resolver->Credentials = System::Net::CredentialCache::DefaultCredentials;
   
   // Create the XslTransform object.
   XslTransform^ xslt = gcnew XslTransform;
   
   // Load the stylesheet.
   xslt->Load( "http://myServer/data/authors.xsl", resolver );
   
   // Transform the file.
   xslt->Transform( "books.xml", "books.html", resolver );