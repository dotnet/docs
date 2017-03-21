      // Reference the schema document.
      String^ myStringUrl = "c:\\Inetpub\\wwwroot\\dataservice.xsd";
      XmlSchema^ myXmlSchema;
      
      // Create the client protocol.
      DiscoveryClientProtocol^ myDiscoveryClientProtocol = gcnew DiscoveryClientProtocol;
      myDiscoveryClientProtocol->Credentials = CredentialCache::DefaultCredentials;
      
      //  Create a schema reference.
      SchemaReference^ mySchemaReferenceNoParam = gcnew SchemaReference;
      SchemaReference^ mySchemaReference = gcnew SchemaReference( myStringUrl );
      
      // Set the client protocol.
      mySchemaReference->ClientProtocol = myDiscoveryClientProtocol;
      
      // Access the default file name associated with the schema reference.
      Console::WriteLine( "Default filename is : {0}", mySchemaReference->DefaultFilename );
      
      // Access the namespace associated with schema reference class.
      Console::WriteLine( "Namespace is : {0}", SchemaReference::Namespace );
      FileStream^ myStream = gcnew FileStream( myStringUrl,FileMode::OpenOrCreate );
      
      // Read the document in a stream.
      mySchemaReference->ReadDocument( myStream );
      
      // Get the schema of referenced document.
      myXmlSchema = mySchemaReference->Schema;
      Console::WriteLine( "Reference is : {0}", mySchemaReference->Ref );
      Console::WriteLine( "Target namespace (default empty) is : {0}", mySchemaReference->TargetNamespace );
      Console::WriteLine( "URL is : {0}", mySchemaReference->Url );
      
      // Write the document in the stream.
      mySchemaReference->WriteDocument( myXmlSchema, myStream );
      myStream->Close();
      mySchemaReference = nullptr;
      