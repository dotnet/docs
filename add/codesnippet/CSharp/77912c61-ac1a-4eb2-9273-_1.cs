      DiscoveryDocumentReference myDiscoveryDocumentReference =
          new DiscoveryDocumentReference();
      string myStringUrl = "http://www.contoso.com/service.disco";
      myDiscoveryClientReferenceCollection.Add(myStringUrl, 
          myDiscoveryDocumentReference);
      myDiscoveryClientReferenceCollection.Remove(myStringUrl);