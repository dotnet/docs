Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Public Class Sample
    
    Protected Sub Method(mySocket As Socket)
' <Snippet1>
 Dim myOpts As New LingerOption(True, 1)
        
 mySocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, _
    myOpts)

' </Snippet1>
    End Sub
End Class
