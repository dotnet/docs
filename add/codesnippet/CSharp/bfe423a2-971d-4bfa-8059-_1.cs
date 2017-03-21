      DiscoveryClientDocumentCollection myDiscoveryClientDocumentCollection = 
         new DiscoveryClientDocumentCollection();
      DiscoveryDocument myDiscoveryDocument = new DiscoveryDocument();
      string myStringUrl = "http://www.contoso.com/service.disco";
      string myStringUrl1 = "http://www.contoso.com/service1.disco";
      
      myDiscoveryClientDocumentCollection.Add(myStringUrl, myDiscoveryDocument);
      myDiscoveryClientDocumentCollection.Add(myStringUrl1, myDiscoveryDocument);