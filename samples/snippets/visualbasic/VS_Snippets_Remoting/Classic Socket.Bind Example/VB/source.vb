Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Public Class Sample
    
    Protected Sub Method(aSocket As Socket, anEndPoint As EndPoint)
' <Snippet1>
 Try
     aSocket.Bind(anEndPoint)
 Catch e As Exception
     Console.WriteLine("Winsock error: " & e.ToString())
 End Try

' </Snippet1>
    End Sub
End Class
