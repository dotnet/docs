      Dim myDiscoFile As String = "http://localhost/MathService_vb.vsdisco"
      Dim myEncoding As String = ""
      Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()
      
      Dim myStream As Stream = myDiscoveryClientProtocol.Download(myDiscoFile, myEncoding)
      Console.WriteLine("The length of the stream in bytes: " & myStream.Length)
      Console.WriteLine _
            ("The MIME encoding of the downloaded discovery document: " & myEncoding)
      myStream.Close()