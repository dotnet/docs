' System.Net.WebException.WebException(String, WebExceptionStatus);

' This program demonstrates the 'WebException(String,WebExceptionStatus)' constructor of 'WebException' class.
' It creates a 'HttpConnect' object and calls the 'ConnectHttpServer' method with invalid 'URL'.
' When the method tries to establish a socket connection to that address an exception is thrown and 
' in the 'catch' block  a new 'WebException' object is created  and  thrown.That exception is caught
' in the calling method and the error message is displayed on the console.



Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports Microsoft.VisualBasic

Class HttpConnect
Public Shared Sub Main()
        Try
            Dim myHttpConnect As New HttpConnect()
            ' If the Uri is valid  then 'ConnectHttpServer' method will connect to the server.
	         myHttpConnect.ConnectHttpServer("www.contoso.com")
        Catch e As WebException
            Console.WriteLine((ControlChars.Cr + "The New Message is:" + e.Message))
            Console.WriteLine((ControlChars.Cr + "The Status is :" + e.Status.ToString()))
        End Try
    End Sub ' Main
    

    Public Sub ConnectHttpServer(connectUri As [String])

' <Snippet1>    

        Try
            ' A 'Socket' object has been created.
            Dim httpSocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            
            ' The IPaddress of the unknown uri is resolved using the 'Dns.Resolve' method. 
	         
            Dim hostEntry As IPHostEntry = Dns.Resolve(connectUri)
            
            Dim serverAddress As IPAddress = hostEntry.AddressList(0)
            Dim endPoint As New IPEndPoint(serverAddress, 80)
            httpSocket.Connect(endPoint)
            Console.WriteLine("Connection created successfully")
            httpSocket.Close()
        Catch e As SocketException
            Console.WriteLine((ControlChars.Cr + "Exception thrown." + ControlChars.Cr + "The Original Message is: " + e.Message))
            ' Throw the 'WebException' object with a message string and message status specific to the situation.
            Throw New WebException("Unable to locate the Server with 'www.contoso.com' Uri.", WebExceptionStatus.NameResolutionFailure)
        End Try

' </Snippet1>

    End Sub ' ConnectHttpServer
End Class ' HttpConnect 
