      ' Call the constructor of the DiscoveryClientProtocol class.
      Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()
      myDiscoveryClientProtocol.Credentials = CredentialCache.DefaultCredentials
      ' 'dataservice.disco' is a sample discovery document.
      Dim myStringUrl As String = "http://localhost:80/dataservice.disco"

      Dim myStream As Stream = myDiscoveryClientProtocol.Download(myStringUrl)
      Console.WriteLine("Size of the discovery document downloaded")
      Console.WriteLine("is : {0} bytes", myStream.Length.ToString())
      myStream.Close()