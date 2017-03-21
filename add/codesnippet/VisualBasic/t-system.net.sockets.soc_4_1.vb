      'Creates the Socket for sending data over TCP.
      Dim s As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
      
      ' Connects to host using IPEndPoint.
      s.Connect(EPhost)
      If Not s.Connected Then
         strRetPage = "Unable to connect to host"
      End If
      ' Use the SelectWrite enumeration to obtain Socket status.
      If s.Poll(- 1, SelectMode.SelectWrite) Then
         Console.WriteLine("This Socket is writable.")
      Else
         If s.Poll(- 1, SelectMode.SelectRead) Then
            Console.WriteLine(("This Socket is readable. "))
         Else
            If s.Poll(- 1, SelectMode.SelectError) Then
               Console.WriteLine("This Socket has an error.")
            End If
         End If 
      End If 