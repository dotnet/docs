
Imports System.IO
Imports System.Net
Imports System.Net.Sockets



Public Class Sample

    Public Shared Sub SocketClose()
        Dim aSocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        ' <Snippet1>
        Try
            aSocket.Shutdown(SocketShutdown.Both)
        Finally
            aSocket.Close()
        End Try

    End Sub
    ' </Snippet1>

    Public Shared Sub Main()
        SocketClose()

    End Sub
End Class
