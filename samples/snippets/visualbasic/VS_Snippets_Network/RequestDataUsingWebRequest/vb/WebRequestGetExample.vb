Imports System.IO
Imports System.Net

Namespace Examples.System.Net
    Public Class WebRequestGetExample
        Public Shared Sub Main()
            ' Create a request for the URL.   
            Dim request As WebRequest =
              WebRequest.Create("https://docs.microsoft.com")
            ' If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials

            ' Get the response.  
            Dim response As WebResponse = request.GetResponse()
            ' Display the status.  
            Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)

            ' Get the stream containing content returned by the server. 
            ' The using block ensures the stream is automatically closed.
            Using dataStream As Stream = response.GetResponseStream()
                ' Open the stream using a StreamReader for easy access.  
                Dim reader As New StreamReader(dataStream)
                ' Read the content.  
                Dim responseFromServer As String = reader.ReadToEnd()
                ' Display the content.  
                Console.WriteLine(responseFromServer)
            End Using

            ' Clean up the response.
            response.Close()
        End Sub
    End Class
End Namespace
