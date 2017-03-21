      DiscoveryClientReferenceCollection myDiscoveryClientReferenceCollection = 
          new DiscoveryClientReferenceCollection();
      
      ContractReference myContractReference = new ContractReference();
      string myStringUrl1 = "http://www.contoso.com/service1.disco";
      myContractReference.Ref = myStringUrl1;
      myDiscoveryClientReferenceCollection.Add(myContractReference);

      // myDiscoveryClientReferenceCollection is an instance collection.
      object myObject = myDiscoveryClientReferenceCollection[myStringUrl1];
      Console.WriteLine("Object representing the URL: " + myObject.ToString());