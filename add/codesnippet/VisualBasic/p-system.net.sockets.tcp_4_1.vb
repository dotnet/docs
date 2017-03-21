      'Sets the send buffer size using the SendBufferSize public property.
      tcpClient.SendBufferSize = 1024
      
      ' Gets the send buffer size using the SendBufferSize public property.
      If tcpClient.SendBufferSize = 1024 Then
         Console.WriteLine(("The send buffer was successfully set to " + tcpClient.SendBufferSize.ToString()))
      End If