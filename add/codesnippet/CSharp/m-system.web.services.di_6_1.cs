      // Call the constructor of the DiscoveryClientProtocol class.
      DiscoveryClientProtocol myDiscoveryClientProtocol =
                  new DiscoveryClientProtocol();
      myDiscoveryClientProtocol.Credentials =  CredentialCache.DefaultCredentials;
     // 'dataservice.disco' is a sample discovery document.
     string myStringUrl = "http://localhost:80/dataservice.disco";

      Stream myStream = myDiscoveryClientProtocol.Download(ref myStringUrl);

      Console.WriteLine("Size of the discovery document downloaded");
      Console.WriteLine("is : {0} bytes", myStream.Length.ToString());
      myStream.Close();