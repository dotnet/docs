' <Snippet1>
Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports System.Threading
Public Class ServicePointExample

    ' Pass in the name of the Web page to retrieve.
    Public Shared Sub Main(ByVal args() As String)
        Dim page As String
        If args Is Nothing OrElse args.Length = 0 OrElse args(0).Length = 0 Then
            page = "http://www.contoso.com/default.html"
        Else
            page = args(0)
        End If

        Dim request As HttpWebRequest = CType(WebRequest.Create(page), HttpWebRequest)
        ' Get the service point that handles the request's socket connection.
        Dim point As ServicePoint = request.ServicePoint
        ' Set the receive buffer size on the underlying socket.
        point.ReceiveBufferSize = 2048
        ' Set the connection lease timeout to infinite.
        point.ConnectionLeaseTimeout = Timeout.Infinite
        ' Send the request.
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        Dim responseStream As Stream = response.GetResponseStream()
        Dim s As New StreamReader(responseStream)
        ' Display the response.
        Console.WriteLine(s.ReadToEnd())
        responseStream.Close()
        response.Close()
    End Sub 'Main
End Class
'</Snippet1>