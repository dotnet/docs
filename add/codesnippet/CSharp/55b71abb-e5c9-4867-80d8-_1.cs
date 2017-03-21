      string myDiscoFile = "http://localhost/MathService_cs.vsdisco";
      string myEncoding = "";
      DiscoveryClientProtocol myDiscoveryClientProtocol = 
            new DiscoveryClientProtocol();

      Stream myStream = myDiscoveryClientProtocol.Download
            (ref myDiscoFile,ref myEncoding);
      Console.WriteLine("The length of the stream in bytes: "+
            myStream.Length);
      Console.WriteLine("The MIME encoding of the downloaded "+
            "discovery document: "+ myEncoding);
      myStream.Close();