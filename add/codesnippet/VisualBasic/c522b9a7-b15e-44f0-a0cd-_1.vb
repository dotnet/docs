      Dim lipa As IPHostEntry = Dns.Resolve("host.contoso.com")
      Dim lep As New IPEndPoint(lipa.AddressList(0), 11000)
      
      Dim s As New Socket(lep.Address.AddressFamily, SocketType.DGram, ProtocolType.Udp)
      
      Dim sender As New IPEndPoint(IPAddress.Any, 0)
      Dim tempRemoteEP As EndPoint = CType(sender, EndPoint)
      s.Connect(sender)
      Try
         While True
            allDone.Reset()
            Dim so2 As New StateObject()
            so2.workSocket = s
            Console.WriteLine("Attempting to Receive data from host.contoso.com")
            
            s.BeginReceiveFrom(so2.buffer, 0, StateObject.BUFFER_SIZE, 0, tempRemoteEP, New AsyncCallback(AddressOf Async_Send_Receive.ReceiveFrom_Callback), so2)
            allDone.WaitOne()
         End While
      Catch e As Exception
         Console.WriteLine(e.ToString())
      End Try
   End Sub 'ReceiveFrom