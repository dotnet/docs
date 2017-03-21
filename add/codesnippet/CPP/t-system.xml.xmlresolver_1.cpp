   // Create a resolver with default credentials.
   XmlUrlResolver^ resolver = gcnew XmlUrlResolver;
   resolver->Credentials = System::Net::CredentialCache::DefaultCredentials;

    // Set the reader settings object to use the resolver.
    settings->XmlResolver = resolver;
   
   // Create the XmlReader object.
   XmlReader^ reader = XmlReader::Create( L"http://ServerName/data/books.xml", settings );
   