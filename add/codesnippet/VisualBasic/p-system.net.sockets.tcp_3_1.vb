      ' Sends data immediately upon calling NetworkStream.Write.
      tcpClient.NoDelay = True
      
      ' Determines if the delay is enabled by using the NoDelay property.
      If tcpClient.NoDelay = True Then
         Console.WriteLine(("The delay was set successfully to " + tcpClient.NoDelay.ToString()))
      End If