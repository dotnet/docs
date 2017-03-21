      ' Sets the send time out using the SendTimeout public property.
      tcpClient.SendTimeout = 5000
      
      ' Gets the send time out using the SendTimeout public property.
      If tcpClient.SendTimeout = 5000 Then
         Console.WriteLine(("The send time out limit was successfully set " + tcpClient.SendTimeout.ToString()))
      End If