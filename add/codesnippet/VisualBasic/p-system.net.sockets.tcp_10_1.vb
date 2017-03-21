   Public Shared Sub listenerOption(host As String, port As Integer)
      Dim server As IPHostEntry = Dns.Resolve(host)
      Dim ipAddress As IPAddress = server.AddressList(0)
      
      Console.WriteLine("listening on {0}, port {1}", ipAddress, port)
      Dim listener As New TcpListener(ipAddress, port)
      Dim listenerSocket As Socket = listener.Server
      
      Dim lingerOption As New LingerOption(True, 10)
      listenerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, lingerOption)
      
      ' start listening and process connections here.
      listener.Start()
   End Sub 'listenerOption
   