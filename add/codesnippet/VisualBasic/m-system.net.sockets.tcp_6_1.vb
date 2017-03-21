   Public Shared Sub DoStart(t As TcpListener, backlog As Integer)
      ' Start listening for client connections with the 
      ' specified backlog.
      t.Start(backlog)
      Console.WriteLine("started listening")
   End Sub 'DoStart