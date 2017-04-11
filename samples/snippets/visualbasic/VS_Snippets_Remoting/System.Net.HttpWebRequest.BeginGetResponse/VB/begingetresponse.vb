' File name begingetresponse.vb
' <Snippet1>

Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic

Public Class RequestState
   ' This class stores the State of the request.
   Private BUFFER_SIZE As Integer = 1024
   Public requestData As StringBuilder
   Public BufferRead() As Byte
   Public request As HttpWebRequest
   Public response As HttpWebResponse
   Public streamResponse As Stream
   
   Public Sub New()
      BufferRead = New Byte(BUFFER_SIZE) {}
      requestData = New StringBuilder("")
      request = Nothing
      streamResponse = Nothing
   End Sub 'New
End Class 'RequestState


Class HttpWebRequest_BeginGetResponse

   Public Shared allDone As New ManualResetEvent(False)
   Private BUFFER_SIZE As Integer = 1024
   Private DefaultTimeout As Integer = 2 * 60 * 1000

    ' 2 minutes timeout
   ' Abort the request if the timer fires.
   Private Shared Sub TimeoutCallback(state As Object, timedOut As Boolean)
      If timedOut Then
         Dim request As HttpWebRequest = state 
        
         If Not (request Is Nothing) Then
            request.Abort()
         End If
      End If
   End Sub 'TimeoutCallback
   
   
   Shared Sub Main()
     
      Try
         ' Create a HttpWebrequest object to the desired URL. 
            Dim myHttpWebRequest As HttpWebRequest = WebRequest.Create("http://www.contoso.com")
         
         ' Create an instance of the RequestState and assign the previous myHttpWebRequest
         ' object to its request field.  
         
         Dim myRequestState As New RequestState()
         myRequestState.request = myHttpWebRequest

         Dim myResponse As New HttpWebRequest_BeginGetResponse()
         
         ' Start the asynchronous request.
         Dim result As IAsyncResult = CType(myHttpWebRequest.BeginGetResponse(New AsyncCallback(AddressOf RespCallback), myRequestState), IAsyncResult)
         
            ' this line implements the timeout, if there is a timeout, the callback fires and the request aborts.
         ThreadPool.RegisterWaitForSingleObject(result.AsyncWaitHandle, New WaitOrTimerCallback(AddressOf TimeoutCallback), myHttpWebRequest, myResponse.DefaultTimeout, True)
         
         ' The response came in the allowed time. The work processing will happen in the 
         ' callback function.
         allDone.WaitOne()
         
         ' Release the HttpWebResponse resource.
         myRequestState.response.Close()
      Catch e As WebException
         Console.WriteLine(ControlChars.Lf + "Main Exception raised!")
         Console.WriteLine(ControlChars.Lf + "Message:{0}", e.Message)
         Console.WriteLine(ControlChars.Lf + "Status:{0}", e.Status)
         Console.WriteLine("Press any key to continue..........")
      Catch e As Exception
         Console.WriteLine(ControlChars.Lf + "Main Exception raised!")
         Console.WriteLine("Source :{0} ", e.Source)
         Console.WriteLine("Message :{0} ", e.Message)
         Console.WriteLine("Press any key to continue..........")
         Console.Read()
      End Try
   End Sub 'Main
   
   Private Shared Sub RespCallback(asynchronousResult As IAsyncResult)
      Try
         ' State of request is asynchronous.
         Dim myRequestState As RequestState = CType(asynchronousResult.AsyncState, RequestState)
         Dim myHttpWebRequest As HttpWebRequest = myRequestState.request
         myRequestState.response = CType(myHttpWebRequest.EndGetResponse(asynchronousResult), HttpWebResponse)
         
         ' Read the response into a Stream object.
         Dim responseStream As Stream = myRequestState.response.GetResponseStream()
         myRequestState.streamResponse = responseStream
         
         ' Begin the Reading of the contents of the HTML page and print it to the console.
         Dim asynchronousInputRead As IAsyncResult = responseStream.BeginRead(myRequestState.BufferRead, 0, 1024, New AsyncCallback(AddressOf ReadCallBack), myRequestState)
         Return
      Catch e As WebException
         Console.WriteLine(ControlChars.Lf + "RespCallback Exception raised!")
         Console.WriteLine(ControlChars.Lf + "Message:{0}", e.Message)
         Console.WriteLine(ControlChars.Lf + "Status:{0}", e.Status)
      End Try
      allDone.Set()
   End Sub 'RespCallback
   
   Private Shared Sub ReadCallBack(asyncResult As IAsyncResult)
      Try
         
         Dim myRequestState As RequestState = CType(asyncResult.AsyncState, RequestState)
         Dim responseStream As Stream = myRequestState.streamResponse
         Dim read As Integer = responseStream.EndRead(asyncResult)
         ' Read the HTML page and then print it to the console.
         If read > 0 Then
            myRequestState.requestData.Append(Encoding.ASCII.GetString(myRequestState.BufferRead, 0, read))
            Dim asynchronousResult As IAsyncResult = responseStream.BeginRead(myRequestState.BufferRead, 0, 1024, New AsyncCallback(AddressOf ReadCallBack), myRequestState)
            Return
         Else
            Console.WriteLine(ControlChars.Lf + "The contents of the Html page are : ")
            If myRequestState.requestData.Length > 1 Then
               Dim stringContent As String
               stringContent = myRequestState.requestData.ToString()
               Console.WriteLine(stringContent)
            End If
            Console.WriteLine("Press any key to continue..........")
            Console.ReadLine()
            
            responseStream.Close()
         End If
      
      Catch e As WebException
         Console.WriteLine(ControlChars.Lf + "ReadCallBack Exception raised!")
         Console.WriteLine(ControlChars.Lf + "Message:{0}", e.Message)
         Console.WriteLine(ControlChars.Lf + "Status:{0}", e.Status)
      End Try
      allDone.Set()
   End Sub 'ReadCallBack 
End Class 'HttpWebRequest_BeginGetResponse

' </Snippet1>
