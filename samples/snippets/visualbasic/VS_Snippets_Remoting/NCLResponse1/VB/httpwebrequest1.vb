 ' <Snippet1>
Imports System
Imports System.Net
Imports System.Text
Imports System.IO


    Public Class Test

        ' Specify the URL to receive the request.
        Public Shared Sub Main(ByVal args() As String)
        Dim request As HttpWebRequest = CType(WebRequest.Create(args(0)), HttpWebRequest)


        ' Set some reasonable limits on resources used by this request
        request.MaximumAutomaticRedirections = 4
        request.MaximumResponseHeadersLength = 4

        ' Set credentials to use for this request.
        request.Credentials = CredentialCache.DefaultCredentials

        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

        Console.WriteLine("Content length is {0}", response.ContentLength)
        Console.WriteLine("Content type is {0}", response.ContentType)

        ' Get the stream associated with the response.
        Dim receiveStream As Stream = response.GetResponseStream()

        ' Pipes the stream to a higher level stream reader with the required encoding format. 
        Dim readStream As New StreamReader(receiveStream, Encoding.UTF8)

        Console.WriteLine("Response stream received.")
        Console.WriteLine(readStream.ReadToEnd())
        response.Close()
        readStream.Close()
    End Sub 'Main
End Class 'Test
'
'The output from this example will vary depending on the value passed into Main 
'but will be similar to the following:
'
'Content length is 1542
'Content type is text/html; charset=utf-8
'Response stream received.
'<html>
'...
'</html>
'
'
' </Snippet1>