


' <Snippet3>
Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic

Public Class RequestState
    ' This class stores the request state of the request.
    Public request As WebRequest
    
    Public Sub New()
        request = Nothing
    End Sub ' New
End Class ' RequestState


Class WebRequest_BeginGetRequeststream
    Public Shared allDone As New ManualResetEvent(False)
    
    Shared Sub Main()
' <Snippet1>
          ' Create a new request.
            Dim myWebRequest As WebRequest = WebRequest.Create("http://www.contoso.com/codesnippets/next.asp")
 ' Create an instance of the RequestState and assign 
            ' myWebRequest' to it's request field.
            Dim myRequestState As New RequestState()
            myRequestState.request = myWebRequest
            myWebRequest.ContentType = "application/x-www-form-urlencoded"

            ' Set the 'Method' property  to 'POST' to post data to a Uri.
            myRequestState.request.Method = "POST"
' </Snippet1>
            ' Start the asynchronous 'BeginGetRequestStream' method call.
            Dim r As IAsyncResult = CType(myWebRequest.BeginGetRequestStream(AddressOf ReadCallback, myRequestState), IAsyncResult)
            ' Pause the current thread until the async operation completes.
            allDone.WaitOne()
            ' Send the Post and get the response.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
            Console.WriteLine(ControlChars.Cr + "The string has been posted.")
            Console.WriteLine("Please wait for the response....")
            Dim streamResponse As Stream = myWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuff(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuff, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The contents of the HTML page are ")
            While count > 0
                Dim outputData As New [String](readBuff, 0, count)
                Console.WriteLine(outputData)
                count = streamRead.Read(readBuff, 0, 256)
            End While

           ' Close the Stream Object.
            streamResponse.Close()
            streamRead.Close()
            ' Release the HttpWebResponse Resource.
             myWebResponse.Close()
    End Sub ' Main
     
    Private Shared Sub ReadCallback(asynchronousResult As IAsyncResult)
            Dim myRequestState As RequestState = CType(asynchronousResult.AsyncState, RequestState)
            Dim myWebRequest As WebRequest = myRequestState.request
            ' End the request.
            Dim streamResponse As Stream = myWebRequest.EndGetRequestStream(asynchronousResult)
            ' Create a string that is to be posted to the uri.
            Console.WriteLine(ControlChars.Cr + "Please enter a string to be posted:")
            Dim postData As String = Console.ReadLine()
            Dim encoder As New ASCIIEncoding()
            ' Convert  the string into a byte array.
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            ' Write the data to the stream.
            streamResponse.Write(byteArray, 0, postData.Length)
            streamResponse.Close()
            ' Allow the main thread to resume.
            allDone.Set()
    End Sub ' ReadCallback 
End Class ' WebRequest_BeginGetRequeststream 
' </Snippet3>
