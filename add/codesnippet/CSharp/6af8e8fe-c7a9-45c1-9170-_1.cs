         string myUrl = "http://localhost/Sample_cs.vsdisco";
         DiscoveryClientProtocol myProtocol = new DiscoveryClientProtocol();
         DiscoveryDocumentReference myReference = new DiscoveryDocumentReference(myUrl);
         Stream myFileStream = myProtocol.Download(ref myUrl);
         DiscoveryDocument myDiscoveryDocument = 
                           (DiscoveryDocument)myReference.ReadDocument(myFileStream);