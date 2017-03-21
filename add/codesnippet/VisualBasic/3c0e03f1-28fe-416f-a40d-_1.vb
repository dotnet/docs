      Dim lipa As IPHostEntry = Dns.Resolve("host.contoso.com")
      Dim lep As New IPEndPoint(lipa.AddressList(0), 11000)
      
      Dim s As New Socket(lep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
      Try
         
         While True
            allDone.Reset()
            
            Dim buff As Byte() = Encoding.ASCII.GetBytes("This is a test")
            
            Console.WriteLine("Sending Message Now..")
            s.BeginSendTo(buff, 0, buff.Length, 0, lep, New AsyncCallback(AddressOf Async_Send_Receive.SendTo_Callback), s)
            
            allDone.WaitOne()
         End While
      Catch e As Exception
         Console.WriteLine(e.ToString())
      End Try
   End Sub 'SendTo