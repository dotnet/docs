
Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets



Public Class Sample
    
    Public Shared Sub SocketClose() 
        Dim aSocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        ' <Snippet1>
        aSocket.Shutdown(SocketShutdown.Both)
        aSocket.Close()
    
    End Sub 'SocketClose
     ' </Snippet1>
    
    Public Shared Sub Main() 
        SocketClose()
    
    End Sub 'Main 
End Class 'Sample