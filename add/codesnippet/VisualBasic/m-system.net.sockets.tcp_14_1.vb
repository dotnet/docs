   ' Thread signal.
   Public Shared clientConnected As New ManualResetEvent(False)
   
   
   ' Accept one client connection asynchronously.
   Public Shared Sub DoBeginAcceptSocket(listener As TcpListener)
      ' Set the event to nonsignaled state.
      clientConnected.Reset()
      
      ' Start to listen for connections from a client.
      Console.WriteLine("Waiting for a connection...")
      
      ' Accept the connection. 
      ' BeginAcceptSocket() creates the accepted socket.
      listener.BeginAcceptSocket(New AsyncCallback(AddressOf DoAcceptSocketCallback), listener)
      ' Wait until a connection is made and processed before 
      ' continuing.
      clientConnected.WaitOne()
   End Sub 'DoBeginAcceptSocket
   
   
   ' Process the client connection.
   Public Shared Sub DoAcceptSocketCallback(ar As IAsyncResult)
      ' Get the listener that handles the client request.
      Dim listener As TcpListener = CType(ar.AsyncState, TcpListener)
      
      ' End the operation and display the received data on the
      'console.
      Dim clientSocket As Socket = listener.EndAcceptSocket(ar)
      
      ' Process the connection here. (Add the client to a 
      ' server table, read data, etc.)
      Console.WriteLine("Client connected completed")
      
      ' Signal the calling thread to continue.
      clientConnected.Set()
   End Sub 'DoAcceptSocketCallback