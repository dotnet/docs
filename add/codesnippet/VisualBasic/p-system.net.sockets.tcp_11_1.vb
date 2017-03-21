      ' Sets the receive time out using the ReceiveTimeout public property.
      tcpClient.ReceiveTimeout = 5
      
      ' Gets the receive time out using the ReceiveTimeout public property.
      If tcpClient.ReceiveTimeout = 5 Then
         Console.WriteLine(("The receive time out limit was successfully set " + tcpClient.ReceiveTimeout.ToString()))
      End If