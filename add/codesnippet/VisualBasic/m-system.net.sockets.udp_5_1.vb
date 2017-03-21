      'Creates a UdpClient for reading incoming data.
      Dim receivingUdpClient As New UdpClient(11000)
      
      'Creates an IPEndPoint to record the IP address and port number of the sender. 
      ' The IPEndPoint will allow you to read datagrams sent from any source.
      Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Any, 0)
      Try
         
         ' Blocks until a message returns on this socket from a remote host.
         Dim receiveBytes As [Byte]() = receivingUdpClient.Receive(RemoteIpEndPoint)
         
         Dim returnData As String = Encoding.ASCII.GetString(receiveBytes)
         
         Console.WriteLine(("This is the message you received " + returnData.ToString()))
         Console.WriteLine(("This message was sent from " + RemoteIpEndPoint.Address.ToString() + " on their port number " + RemoteIpEndPoint.Port.ToString()))
      Catch e As Exception
         Console.WriteLine(e.ToString())
      End Try
   End Sub 'MyUdpClientCommunicator
    