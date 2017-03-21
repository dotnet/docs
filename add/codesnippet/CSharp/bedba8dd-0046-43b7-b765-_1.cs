      string myStringUrl1 = "http://localhost/dataservice.disco";
      if (myDiscoveryClientReferenceCollection.Contains(myStringUrl1))
      {
          Console.WriteLine("The document reference {0} is part of the"
              + " collection.", myStringUrl1);
      }