      String^ myUrl = "http://localhost/Sample_cs.vsdisco";
      DiscoveryClientProtocol^ myProtocol = gcnew DiscoveryClientProtocol;
      DiscoveryDocumentReference^ myReference = gcnew DiscoveryDocumentReference( myUrl );
      Stream^ myFileStream = myProtocol->Download( myUrl );
      DiscoveryDocument^ myDiscoveryDocument = dynamic_cast<DiscoveryDocument^>(myReference->ReadDocument( myFileStream ));