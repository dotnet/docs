   DiscoveryClientDocumentCollection^ myDiscoveryClientDocumentCollection = gcnew DiscoveryClientDocumentCollection;

   DiscoveryDocument^ myDiscoveryDocument = gcnew DiscoveryDocument;
   String^ myStringUrl = "http://www.contoso.com/service.disco";
   String^ myStringUrl1 = "http://www.contoso.com/service1.disco";
   myDiscoveryClientDocumentCollection->Add( myStringUrl, myDiscoveryDocument );
   myDiscoveryClientDocumentCollection->Add( myStringUrl1, myDiscoveryDocument );