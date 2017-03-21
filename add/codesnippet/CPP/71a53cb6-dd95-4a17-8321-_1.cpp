   DiscoveryDocumentReference^ myDiscoveryDocumentReference = gcnew DiscoveryDocumentReference;
   String^ myStringUrl = "http://www.contoso.com/service.disco";
   myDiscoveryClientReferenceCollection->Add( myStringUrl, myDiscoveryDocumentReference );