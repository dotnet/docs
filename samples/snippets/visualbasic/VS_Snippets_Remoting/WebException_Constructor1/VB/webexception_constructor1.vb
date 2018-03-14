' System.Net.WebException.WebException(); 

' This program demonstrates the 'WebException()' constructor of 'WebException' class.
' It creates a 'HttpConnect' object and calls the 'ConnectHttpServer' method with an invalid 'URL'.
' When the method tries to establish a socket connection to that address an exception is thrown.In 
' the 'catch' block  a new 'WebException' object is created  and  thrown to the caller.That exception 
' is caught in the calling method and the error message is dispalyed to the console.



Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports Microsoft.VisualBasic

Class HttpConnect
Public shared Sub Main()
        Try
            Dim myHttpConnect As New HttpConnect()
            ' If the Uri is valid  then 'ConnectHttpServer' method will connect 
	         ' to the server sucessfully.
            myHttpConnect.ConnectHttpServer("www.contoso.com")
        Catch e As WebException
            Console.WriteLine(("The Exception is :" + e.Message))
            Console.WriteLine("The Exception is : Unable to Contact the server")
        End Try
    End Sub ' Main

    Public Sub ConnectHttpServer(connectUri As [String])

' <Snippet1>    
        Try
            ' A 'Socket' object has been created.
            Dim httpSocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            
            ' The IPaddress of the unknown uri is resolved using the 'Dns.Resolve' method. 
	         ' which leads to the 'SocketException' exception. 
            
            Dim hostEntry As IPHostEntry = Dns.Resolve("http://www.contoso.com")
            
            Dim serverAddress As IPAddress = hostEntry.AddressList(0)
            Dim endPoint As New IPEndPoint(serverAddress, 80)
            httpSocket.Connect(endPoint)
            Console.WriteLine("Connection created successfully")
            httpSocket.Close()
        Catch e As SocketException
            Dim exp As [String] = e.Message
            ' Throw the WebException with no parameters.
            Throw New WebException()
        End Try

' </Snippet1>
    End Sub 'ConnectHttpServer
End Class 'HttpConnect 