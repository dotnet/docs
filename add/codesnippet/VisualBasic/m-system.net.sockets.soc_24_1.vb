      Dim lipa As IPHostEntry = Dns.Resolve("host.contoso.com")
      Dim lep As New IPEndPoint(lipa.AddressList(0), 11000)
      
      Dim s As New Socket(lep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
      Try
         s.Bind(lep)
         s.Listen(1000)
         
         While True
            allDone.Reset()
            
            Console.WriteLine("Waiting for a connection...")
            s.BeginAccept(New AsyncCallback(AddressOf Async_Send_Receive.Listen_Callback), s)
            
            allDone.WaitOne()
         End While
      Catch e As Exception
         Console.WriteLine(e.ToString())
      End Try
   End Sub 'Listen