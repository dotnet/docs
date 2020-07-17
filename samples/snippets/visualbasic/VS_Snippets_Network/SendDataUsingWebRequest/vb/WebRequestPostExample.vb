Imports System.IO
Imports System.Net
Imports System.Text

Namespace Examples.System.Net
    Public Class WebRequestPostExample
        Public Shared Sub Main()
            ' Create a request using a URL that can receive a post.   
            Dim request As WebRequest = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx ")
            ' Set the Method property of the request to POST.  
            request.Method = "POST"

            ' Create POST data and convert it to a byte array.  
            Dim postData As String = "This is a test that posts this string to a Web server."
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)

            ' Set the ContentType property of the WebRequest.  
            request.ContentType = "application/x-www-form-urlencoded"
            ' Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length

            ' Get the request stream.  
            Dim dataStream As Stream = request.GetRequestStream()
            ' Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length)
            ' Close the Stream object.  
            dataStream.Close()

            ' Get the response.  
            Dim response As WebResponse = request.GetResponse()
            ' Display the status.  
            Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)

            ' Get the stream containing content returned by the server.  
            ' The using block ensures the stream is automatically closed.
            Using dataStream1 As Stream = response.GetResponseStream()
                ' Open the stream using a StreamReader for easy access.  
                Dim reader As New StreamReader(dataStream1)
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
