      ' Start listening to the port.
      Public Sub StartListening(ByVal data As Object) Implements IChannelReceiver.StartListening
         If myListening = False Then
             myTcpListener.Start()
             myListening = True
             Console.WriteLine("Server Started Listening !!!")
         End If
      End Sub 'StartListening