      XmlSchemaCollection^ sc = gcnew XmlSchemaCollection;
      sc->ValidationEventHandler += gcnew ValidationEventHandler( Sample::ValidationCallBack );

      // Create a resolver with the necessary credentials.
      XmlUrlResolver^ resolver = gcnew XmlUrlResolver;
      System::Net::NetworkCredential^ nc;
      nc = gcnew System::Net::NetworkCredential( UserName,SecurelyStoredPassword,Domain );
      resolver->Credentials = nc;

      // Add the new schema to the collection.
      sc->Add( nullptr, gcnew XmlTextReader( "sample.xsd" ), resolver );