' <Snippet1>
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Namespace Examples.System.Net
    Public Class WebRequestGetExample

        Public Shared Sub Main()
            ' <Snippet2>
            ' Create a request for the URL. 		
            Dim request As WebRequest = WebRequest.Create("http://www.contoso.com/default.html")
            ' If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials
            ' Get the response.
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            ' </Snippet2>
            ' Display the status.
            Console.WriteLine(response.StatusDescription)
            ' Get the stream containing content returned by the server.
            Dim dataStream As Stream = response.GetResponseStream()
            ' Open the stream using a StreamReader for easy access.
            Dim reader As New StreamReader(dataStream)
            ' Read the content.
            Dim responseFromServer As String = reader.ReadToEnd()
            ' Display the content.
            Console.WriteLine(responseFromServer)
            ' Cleanup the streams and the response.
            reader.Close()
            dataStream.Close()
            response.Close()
        End Sub 'Main
    End Class 'WebRequestGetExample
End Namespace
' </Snippet1>