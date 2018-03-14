
'<Snippet1>
Imports System
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports Microsoft.VisualBasic

Public Class GetSocket
   
   Private Shared Function ConnectSocket(server As String, port As Integer) As Socket
      Dim s As Socket = Nothing
      Dim hostEntry As IPHostEntry = Nothing      
     
         ' Get host related information.
        hostEntry = Dns.GetHostEntry(server)
         
         ' Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
         ' an exception that occurs when the host host IP Address is not compatible with the address family
         ' (typical in the IPv6 case).
      Dim address As IPAddress
 
        For Each address In  hostEntry.AddressList
            Dim endPoint As New IPEndPoint(address, port)
            Dim tempSocket As New Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
      
            tempSocket.Connect(endPoint)
            
            If tempSocket.Connected Then
               s = tempSocket
               Exit For
            End If

         Next address
      
      Return s
   End Function 
   
   
   ' This method requests the home page content for the specified server.
   
   Private Shared Function SocketSendReceive(server As String, port As Integer) As String
      'Set up variables and String to write to the server.
      Dim ascii As Encoding = Encoding.ASCII
      Dim request As String = "GET / HTTP/1.1" + ControlChars.Cr + ControlChars.Lf + "Host: " + server + ControlChars.Cr + ControlChars.Lf + "Connection: Close" + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf
      Dim bytesSent As [Byte]() = ascii.GetBytes(request)
      Dim bytesReceived(255) As [Byte]
      
      ' Create a socket connection with the specified server and port.
      Dim s As Socket = ConnectSocket(server, port)
      
      If s Is Nothing Then
         Return "Connection failed"
      End If 
      ' Send request to the server.
      s.Send(bytesSent, bytesSent.Length, 0)
      
      ' Receive the server  home page content.
      Dim bytes As Int32
      
      ' Read the first 256 bytes.
      Dim page as [String] = "Default HTML page on " + server + ":" + ControlChars.Cr + ControlChars.Lf
      
      ' The following will block until the page is transmitted.
      Do
         bytes = s.Receive(bytesReceived, bytesReceived.Length, 0)
            page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes)
      Loop While bytes > 0
      
      Return page
   End Function 
   
   'Entry point which delegates to C-style main Private Function
   Public Overloads Shared Sub Main()
      Main(System.Environment.GetCommandLineArgs())
   End Sub
   
   
   Overloads Private Shared Sub Main(args() As String)
      Dim host As String
      Dim port As Integer = 80
      
      If args.Length = 1 Then
         ' If no server name is passed as argument to this program, 
         ' use the current host name as default.
         host = Dns.GetHostName()
      Else
         host = args(1)
      End If 
      
      Dim result As String = SocketSendReceive(host, port)
      
      Console.WriteLine(result)
   End Sub 'Main
End Class  

'</Snippet1>

