' System.Net.WebException.WebException(String,InnerException,Status,WebResponse);

' This program demonstrates the 'WebException(String,InnerException,Status,WebResponse)' constructor of
' 'WebException' class.
' A 'HttpConnect' class is defined which extends the 'WebResponse' class.  Then a 'HttpConnect' object is 
' created by taking an uri(intranet) from the user as input and 'ConnectHttpServer' method is called to connect
' the InternetServer at the specified 'URL'. It asks for a file named 'nhjj.htm' ,gets the response from the 
' InternetServer and checks the status of the response. If status is '404 File not Found' a 'WebResponse' object
' is created and then a new 'WebException' object is created and thrown.That exception is caught in the calling
' method and the error message along with the response obtained from the InternetServer is displayed to the 
' console.
'


Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Imports Microsoft.VisualBasic



Public Class HttpConnect
    Inherits WebResponse
    
    Public getStream As Stream = Nothing
    
    
    Shared Sub Main()
        Try
            Console.WriteLine("Please give any Intranet Site Address (eg:manjeera.wipro.com)")
            Dim uriConnect As [String] = Console.ReadLine()
            Dim myHttpConnect As New HttpConnect()
            myHttpConnect.ConnectHttpServer(uriConnect)
        Catch e As WebException
            Console.WriteLine((ControlChars.Cr + "The  WebException is :" + e.Message))
            Console.WriteLine((ControlChars.Cr + "The status of the WebException is :" + e.Status.ToString()))
            Console.WriteLine((ControlChars.Cr + "The Inner Exception is :'" + e.InnerException.ToString() + "'"))
            Console.WriteLine(ControlChars.Cr + "The Web Response is:" + ControlChars.Cr)
            Dim readStream As New StreamReader(e.Response.GetResponseStream())
            Console.WriteLine(readStream.ReadToEnd())
        Catch e As Exception
            Console.WriteLine(e)
        End Try
    End Sub ' Main
    
    
    ' Default constructor
    Sub New()
    End Sub ' New
    
    
    ' Constructor accepting stream as a parameter.
    Sub New(getStream As Stream)
        Me.getStream = getStream
    End Sub ' New
    
    
    ' Override 'GetResponseStream' method of the  'WebResponse' class.
    Public Overrides Function GetResponseStream() As Stream
        Return getStream
    End Function ' GetResponseStream
    
    
    
    Public Sub ConnectHttpServer(connectUri As [String])

' <Snippet1>
 
   	  ' Send the data. 
        Dim ASCII As Encoding = Encoding.ASCII
        Dim requestPage As String = "GET /nhjj.htm HTTP/1.1" + ControlChars.Lf + ControlChars.Cr + "Host: " + connectUri + ControlChars.Lf + ControlChars.Cr + "Connection: Close" + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr
        Dim byteGet As [Byte]() = ASCII.GetBytes(requestPage)
        Dim recvBytes(256) As [Byte]
        
        ' Create an 'IPEndPoint' object.
        Dim hostEntry As IPHostEntry = Dns.Resolve(connectUri)
        Dim serverAddress As IPAddress = hostEntry.AddressList(0)
        Dim endPoint As New IPEndPoint(serverAddress, 80)
        
        ' Create a 'Socket' object  for sending data.
        Dim connectSocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        
        ' Connect to host using 'IPEndPoint' object.
        connectSocket.Connect(endPoint)
        
        ' Sent the 'requestPage' text to the host.
        connectSocket.Send(byteGet, byteGet.Length, 0)
        
        ' Receive the information sent by the server.
        Dim bytesReceived As Int32 = connectSocket.Receive(recvBytes, recvBytes.Length, 0)
        Dim headerString As [String] = ASCII.GetString(recvBytes, 0, bytesReceived)
       
        ' Check whether 'status 404' is there or not in the information sent by server.
        If headerString.IndexOf("404") <> False Then
            bytesReceived = connectSocket.Receive(recvBytes, recvBytes.Length, 0)
            Dim memoryStream As New MemoryStream(recvBytes)
            getStream = CType(memoryStream, Stream)
            
            ' Create a 'WebResponse' object.
            Dim myWebResponse As WebResponse = CType(New HttpConnect(getStream), WebResponse)
            Dim myException As New Exception("File Not found")
            
            ' Throw the 'WebException' object with a message string, message status,InnerException and WebResponse.
            Throw New WebException("The Requested page is not found.", myException, WebExceptionStatus.ProtocolError, myWebResponse)
        End If 

        connectSocket.Close()
      

' </Snippet1>
    End Sub ' ConnectHttpServer 
End Class ' HttpConnect
