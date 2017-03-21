   ' Thread signal.
   Public Shared tcpClientConnected As New ManualResetEvent(False)
   
   
   ' Accept one client connection asynchronously.
   Public Shared Sub DoBeginAcceptTcpClient(listener As TcpListener)
      ' Set the event to nonsignaled state.
      tcpClientConnected.Reset()
      
      ' Start to listen for connections from a client.
      Console.WriteLine("Waiting for a connection...")
      
      ' Accept the connection. 
      ' BeginAcceptSocket() creates the accepted socket.
      listener.BeginAcceptTcpClient(New AsyncCallback(AddressOf DoAcceptTcpClientCallback), listener)
      
      ' Wait until a connection is made and processed before 
      ' continuing.
      tcpClientConnected.WaitOne()
   End Sub 'DoBeginAcceptTcpClient
   
   
   ' Process the client connection.
   Public Shared Sub DoAcceptTcpClientCallback(ar As IAsyncResult)
      ' Get the listener that handles the client request.
      Dim listener As TcpListener = CType(ar.AsyncState, TcpListener)
      
      ' End the operation and display the received data on 
      ' the console.
      Dim client As TcpClient = listener.EndAcceptTcpClient(ar)
      
      ' Process the connection here. (Add the client to a
      ' server table, read data, etc.)
      Console.WriteLine("Client connected completed")
      
      ' Signal the calling thread to continue.
      tcpClientConnected.Set()
   End Sub 'DoAcceptTcpClientCallback
    