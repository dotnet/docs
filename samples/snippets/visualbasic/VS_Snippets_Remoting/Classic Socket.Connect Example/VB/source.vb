
Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets



Public Class Sample
    
    Shared Sub ConnectAndCheck(ByVal client As Socket, ByVal anEndPoint As EndPoint) 
        ' <Snippet1>
        ' .Connect throws an exception if unsuccessful
        client.Connect(anEndPoint)
        
        ' This is how you can determine whether a socket is still connected.
        Dim blockingState As Boolean = client.Blocking
        Try
            Dim tmp(0) As Byte
            
            client.Blocking = False
            client.Send(tmp, 0, 0)
            Console.WriteLine("Connected!")
        Catch e As SocketException
            ' 10035 == WSAEWOULDBLOCK
            If e.NativeErrorCode.Equals(10035) Then
                Console.WriteLine("Still Connected, but the Send would block")
            Else
                Console.WriteLine("Disconnected: error code {0}!", e.NativeErrorCode)
            End If
        Finally
            client.Blocking = blockingState
        End Try
        
        Console.WriteLine("Connected: {0}", client.Connected)
    
    End Sub 'ConnectAndCheck
     ' </Snippet1>
    
    <STAThread()>  _
    Shared Sub Main() 
        Dim s As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        
        Dim host As String = "localhost"
        Dim port As Integer = 80
        
        Dim hostEntry As IPHostEntry = Dns.GetHostEntry(host)
        Dim EPHost As New IPEndPoint(hostEntry.AddressList(0), port)
        
        ConnectAndCheck(s, EPHost)
    
    End Sub 'Main
End Class 'Sample