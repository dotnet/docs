Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Class newListener
   
   ' <Snippet2>
   Public Shared Sub GetSetExclusiveAddressUse(t As TcpListener)
      ' Set Exclusive Address Use for the underlying socket.
      t.ExclusiveAddressUse = True
      Console.WriteLine("ExclusiveAddressUse value is {0}", t.ExclusiveAddressUse)
   End Sub 'GetSetExclusiveAddressUse
   
   ' </Snippet2>
   ' <Snippet3>
   Public Shared Sub DoStart(t As TcpListener, backlog As Integer)
      ' Start listening for client connections with the 
      ' specified backlog.
      t.Start(backlog)
      Console.WriteLine("started listening")
   End Sub 'DoStart
   ' </Snippet3>
   ' <Snippet4>
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
   ' </Snippet4>
   ' <Snippet5>
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
    
   ' </Snippet5>
   <STAThread()>  _
   Shared Sub Main()
      Dim listener As New TcpListener(Dns.GetHostAddresses("")(0), 4242)
      
      GetSetExclusiveAddressUse(listener)
      
      ' Start listening for client connections.
      DoStart(listener, 20)
      
      ' Accept one client connection asynchronously
      DoBeginAcceptSocket(listener)
      DoBeginAcceptTcpClient(listener)
      
      Console.WriteLine("hit any key")
      Console.Read()
   End Sub 'Main
End Class 'newListener
