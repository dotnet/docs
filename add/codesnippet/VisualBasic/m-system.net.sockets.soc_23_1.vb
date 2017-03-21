      ' create the socket
      Dim listenSocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
      
      ' bind the listening socket to the port
      Dim hostIP As IPAddress = Dns.Resolve(IPAddress.Any.ToString()).AddressList(0)
      Dim ep As New IPEndPoint(hostIP, port)
      listenSocket.Bind(ep)
      
      ' start listening
      listenSocket.Listen(backlog)
   End Sub 'CreateAndListen