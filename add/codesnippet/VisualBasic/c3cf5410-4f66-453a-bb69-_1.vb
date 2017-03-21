      Dim lipa As IPHostEntry = Dns.Resolve("host.contoso.com")
      Dim lep As New IPEndPoint(lipa.AddressList(0), 11000)
      
      Dim s As New Socket(lep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
      Try
         
         While True
            allDone.Reset()
            
            Console.WriteLine("Establishing Connection")
  
            s.BeginConnect(lep, New AsyncCallback(AddressOf Async_Send_Receive.Connect_Callback), s)
            
            allDone.WaitOne()
         End While
      Catch e As Exception
         Console.WriteLine(e.ToString())
      End Try
   End Sub 'Connect