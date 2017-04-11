
Imports System
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports Microsoft.VisualBasic

Public Class Sample
   
   
   Public Shared Sub DoSocketGet(server As String)
      'Set up variables and String to write to the server.
      Dim ASCII As Encoding = Encoding.ASCII
      Dim [Get] As String = "GET / HTTP/1.1" + ControlChars.Lf + ControlChars.Cr + "Host: " + server + ControlChars.Lf + ControlChars.Cr + "Connection: Close" + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr
      Dim ByteGet As [Byte]() = ASCII.GetBytes([Get])
      Dim RecvBytes(256) As [Byte]
      Dim strRetPage As [String] = Nothing
      
      
      ' IPAddress and IPEndPoint represent the endpoint that will
      '   receive the request.
      ' Get first IPAddress in list return by DNS.
      
      Dim hostadd As IPAddress = Dns.GetHostEntry(server).AddressList(0)
      Dim EPhost As New IPEndPoint(hostadd, 80)
      '<Snippet1>
      'Creates the Socket for sending data over TCP.
      Dim s As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
      
      ' Connects to host using IPEndPoint.
      s.Connect(EPhost)
      If Not s.Connected Then
         strRetPage = "Unable to connect to host"
      End If
      ' Use the SelectWrite enumeration to obtain Socket status.
      If s.Poll(- 1, SelectMode.SelectWrite) Then
         Console.WriteLine("This Socket is writable.")
      Else
         If s.Poll(- 1, SelectMode.SelectRead) Then
            Console.WriteLine(("This Socket is readable. "))
         Else
            If s.Poll(- 1, SelectMode.SelectError) Then
               Console.WriteLine("This Socket has an error.")
            End If
         End If 
      End If 
      '</Snippet1>
      ' Sent the GET text to the host.
      s.Send(ByteGet, ByteGet.Length, 0)
      
      ' Receives the page, loops until all bytes are received.
      Dim bytes As Int32 = s.Receive(RecvBytes, RecvBytes.Length, 0)
      strRetPage = "Default HTML page on " + server + ":" + ControlChars.Lf + ControlChars.Cr
      strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes)
      
      While bytes > 0
         bytes = s.Receive(RecvBytes, RecvBytes.Length, 0)
         strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes)
      End While 
   End Sub 'DoSocketGet
   
   Public Shared Sub Main()
      DoSocketGet("www.contoso.com")
   End Sub 'Main
End Class 'Sample 


