Imports System
Imports System.Collections
Imports System.Net
Imports System.Net.Sockets


Class Test
   
   Public Shared Sub Main()
'<Snippet1>
      Dim ipHostEntry As IPHostEntry = Dns.Resolve(Dns.GetHostName())
      Dim ipAddress As IPAddress = ipHostEntry.AddressList(0)
      
      Dim socket0 As Socket = Nothing
      Dim socket1 As Socket = Nothing
      Dim socket2 As Socket = Nothing
      Dim socket3 As Socket = Nothing
      Dim socket4 As Socket = Nothing
      Dim socket5 As Socket = Nothing
      
      Dim listenList As New ArrayList()
      listenList.Add(socket0)
      listenList.Add(socket1)
      listenList.Add(socket2)
      
      Dim acceptList As New ArrayList()
      acceptList.Add(socket3)
      acceptList.Add(socket4)
      acceptList.Add(socket5)
      
      Dim i As Integer
      For i = 0 To 2
         listenList(i) = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
         CType(listenList(i), Socket).Bind(New IPEndPoint(ipAddress, 11000 + i))
         CType(listenList(i), Socket).Listen(10)
      Next i
      
      'Only the sockets that contain a connection request
      'will remain in listenList after Select returns.
      Socket.Select(listenList, Nothing, Nothing, 1000)
      
      For i = 0 To listenList.Count - 1
         acceptList(i) = CType(listenList(i), Socket).Accept()
      Next i
'</Snippet1>
   End Sub 'Main
End Class