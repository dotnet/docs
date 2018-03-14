Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Public Class Sample
' <Snippet1>    
    Protected Sub AcceptMethod(listeningSocket As Socket)
        

 Dim mySocket As Socket = listeningSocket.Accept()
        
    End Sub
' </Snippet1>
End Class
