      ' Sets the amount of time to linger after closing, using the LingerOption public property.
      Dim lingerOption As New LingerOption(True, 10)
      tcpClient.LingerState = lingerOption
      
      ' Gets the amount of linger time set, using the LingerOption public property.
      If tcpClient.LingerState.LingerTime = 10 Then
         Console.WriteLine(("The linger state setting was successfully set to " + tcpClient.LingerState.LingerTime.ToString()))
      End If