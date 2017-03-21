      ' Sets the receive buffer size using the ReceiveBufferSize public property.
      tcpClient.ReceiveBufferSize = 1024
      
      ' Gets the receive buffer size using the ReceiveBufferSize public property.
      If tcpClient.ReceiveBufferSize = 1024 Then
         Console.WriteLine(("The receive buffer was successfully set to " + tcpClient.ReceiveBufferSize.ToString()))
      End If