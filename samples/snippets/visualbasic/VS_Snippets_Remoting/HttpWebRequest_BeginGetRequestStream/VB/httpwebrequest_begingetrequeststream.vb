
'  <Snippet2>
Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic

Class HttpWebRequestBeginGetRequest
    Public Shared allDone As New ManualResetEvent(False)

    Shared Sub Main()

        '  <Snippet1>

        ' Create a new HttpWebRequest object.
        Dim request As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com/example.aspx"), _
                 HttpWebRequest)

        ' Set the ContentType property.
        request.ContentType = "application/x-www-form-urlencoded"

        '  Set the Method property to 'POST' to post data to the URI.
        request.Method = "POST"

        ' Start the asynchronous operation.		
        Dim result As IAsyncResult = _
            CType(request.BeginGetRequestStream(AddressOf GetRequestStreamCallback, request), _
            IAsyncResult)

        ' Keep the main thread from continuing while the asynchronous
        ' operation completes. A real world application
        ' could do something useful such as updating its user interface. 
        allDone.WaitOne()
    End Sub ' Main

    Private Shared Sub GetRequestStreamCallback(ByVal asynchronousResult As IAsyncResult)
        Dim request As HttpWebRequest = CType(asynchronousResult.AsyncState, HttpWebRequest)
        
        ' End the operation
        Dim postStream As Stream = request.EndGetRequestStream(asynchronousResult)
        Console.WriteLine("Please enter the input data to be posted:")
        Dim postData As [String] = Console.ReadLine()
        
        '  Convert the string into byte array.
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)

        ' Write to the stream.
        postStream.Write(byteArray, 0, postData.Length)
        postStream.Close()

        ' Start the asynchronous operation to get the response
        Dim result As IAsyncResult = _
            CType(request.BeginGetResponse(AddressOf GetResponseCallback, request), _
            IAsyncResult)
    End Sub ' ReadRequestStreamCallback

    Private Shared Sub GetResponseCallback(ByVal asynchronousResult As IAsyncResult)
        Dim request As HttpWebRequest = CType(asynchronousResult.AsyncState, HttpWebRequest)
        
        '  Get the response.
        Dim response As HttpWebResponse = CType(request.EndGetResponse(asynchronousResult), _
           HttpWebResponse)
        
        Dim streamResponse As Stream = response.GetResponseStream()
        Dim streamRead As New StreamReader(streamResponse)
        Dim responseString As String = streamRead.ReadToEnd()
        
        Console.WriteLine(responseString)
        
        ' Close Stream object.
        streamResponse.Close()
        streamRead.Close()

        ' Release the HttpWebResponse.
        allDone.Set()
        response.Close()
    End Sub ' ReadResponseCallback
            
    '  </Snippet1>
End Class ' HttpWebRequest_BeginGetRequest
    '  </Snippet2>