
Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets



Public Class Sample
   
   Shared Sub CreateAndListen(port As Integer, backlog As Integer)
      ' <Snippet1>
      ' create the socket
      Dim listenSocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
      
      ' bind the listening socket to the port
      Dim hostIP As IPAddress = Dns.Resolve(IPAddress.Any.ToString()).AddressList(0)
      Dim ep As New IPEndPoint(hostIP, port)
      listenSocket.Bind(ep)
      
      ' start listening
      listenSocket.Listen(backlog)
   End Sub 'CreateAndListen
    ' </Snippet1>
   
   <STAThread()>  _
   Shared Sub Main()
      CreateAndListen(10042, 10)
      
      Console.WriteLine("enter to exit")
      Console.Read()
   End Sub 'Main
End Class 'Sample 
