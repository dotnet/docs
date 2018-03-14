
Imports System
Imports System.Text
Imports System.Net
Imports System.Net.Sockets



Public Class Example
   
   <STAThread()>  _
   Shared Sub Main()
      '<Snippet1>
      Dim client As New TcpClient()
      Dim s As Socket = client.Client
      
      If Not s.Connected Then
         s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, 16384)
         Console.WriteLine("client is not connected, ReceiveBuffer set" + ControlChars.Lf)
      Else
         Console.WriteLine("client is connected")
      End If 
      '</Snippet1>
   End Sub 'Main
End Class 'Example