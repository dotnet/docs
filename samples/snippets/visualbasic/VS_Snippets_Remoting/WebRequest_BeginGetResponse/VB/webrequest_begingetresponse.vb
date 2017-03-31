' System.Net.WebRequest.BeginGetResponse  System.Net.WebRequest.EndGetResponse 
'  This program demonstrates 'BeginGetResponse' and 'EndGetResponse' methods of 'WebRequest' Class.
'  A new 'WebRequest' object is created to the mentioned Uri.An Asynchronous call is started for response 
'  from the Uri using 'BeginGetResponse' method of 'WebRequest' class. The asynchronous response is ended 
'  by 'EndGetResponse' method of the 'WebRequest' class. The contents of the HTML page of the requested 
'  Uri are displayed to the console.
'

' <Snippet1>
' <Snippet2>

Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic



Public Class RequestState
  ' This class stores the state of the request
  Private Shared BUFFER_SIZE As Integer = 1024
  Public requestData As StringBuilder
  Public bufferRead() As Byte
  Public request As WebRequest
  Public response As WebResponse
  Public responseStream As Stream
  
  Public Sub New()
    bufferRead = New Byte(BUFFER_SIZE) {}
    requestData = New StringBuilder("")
    request = Nothing
    responseStream = Nothing
  End Sub ' New
End Class ' RequestState

Class WebRequest_BeginGetResponse
  Public Shared allDone As New ManualResetEvent(False)
  Private Shared BUFFER_SIZE As Integer = 1024
  
  Shared Sub Main()
    Try


      ' Create a new webrequest to the mentioned URL.
      Dim myWebRequest As WebRequest = WebRequest.Create("http://www.contoso.com")
      'Please, set the proxy to a correct value.
      Dim proxy As New WebProxy("itgproxy:80")
      proxy.Credentials = New NetworkCredential("srikun", "simrin123")
      myWebRequest.Proxy = proxy
      ' Create a new instance of the RequestState.
      Dim myRequestState As New RequestState()
      ' The 'WebRequest' object is associated to the 'RequestState' object.
      myRequestState.request = myWebRequest
      ' Start the Asynchronous call for response.
      Dim asyncResult As IAsyncResult = CType(myWebRequest.BeginGetResponse(AddressOf RespCallback, myRequestState), IAsyncResult)
      allDone.WaitOne()
	  ' Release the WebResponse resource.
	  myRequestState.response.Close()
      Console.Read()
    Catch e As WebException
      Console.WriteLine("WebException raised!")
      Console.WriteLine(ControlChars.Cr + "{0}", e.Message)
      Console.WriteLine(ControlChars.Cr + "{0}", e.Status)
    Catch e As Exception
      Console.WriteLine("Exception raised!")
      Console.WriteLine(("Source : " + e.Source))
      Console.WriteLine(("Message : " + e.Message))
    End Try
  End Sub ' Main

  Private Shared Sub RespCallback(asynchronousResult As IAsyncResult)
    Try
      ' Set the State of request to asynchronous.
      Dim myRequestState As RequestState = CType(asynchronousResult.AsyncState, RequestState)
      Dim myWebRequest1 As WebRequest = myRequestState.request
      ' End the Asynchronous response.
      myRequestState.response = myWebRequest1.EndGetResponse(asynchronousResult)
      ' Read the response into a 'Stream' object.
      Dim responseStream As Stream = myRequestState.response.GetResponseStream()
      myRequestState.responseStream = responseStream
      ' Begin the reading of the contents of the HTML page and print it to the console.
      Dim asynchronousResultRead As IAsyncResult = responseStream.BeginRead(myRequestState.bufferRead, 0, BUFFER_SIZE, AddressOf ReadCallBack, myRequestState)
    Catch e As WebException
      Console.WriteLine("WebException raised!")
      Console.WriteLine(ControlChars.Cr + "{0}", e.Message)
      Console.WriteLine(ControlChars.Cr + "{0}", e.Status)
    Catch e As Exception
      Console.WriteLine("Exception raised!")
      Console.WriteLine(("Source : " + e.Source))
      Console.WriteLine(("Message : " + e.Message))
    End Try
  End Sub ' RespCallback
  Private Shared Sub ReadCallBack(asyncResult As IAsyncResult)
    Try
      ' Result state is set to AsyncState.
      Dim myRequestState As RequestState = CType(asyncResult.AsyncState, RequestState)
      Dim responseStream As Stream = myRequestState.responseStream
      Dim read As Integer = responseStream.EndRead(asyncResult)
      ' Read the contents of the HTML page and then print to the console.
      If read > 0 Then
        myRequestState.requestData.Append(Encoding.ASCII.GetString(myRequestState.bufferRead, 0, read))
        Dim asynchronousResult As IAsyncResult = responseStream.BeginRead(myRequestState.bufferRead, 0, BUFFER_SIZE, AddressOf ReadCallBack, myRequestState)
      Else
        Console.WriteLine(ControlChars.Cr + "The HTML page Contents are:  ")
        If myRequestState.requestData.Length > 1 Then
          Dim sringContent As String
          sringContent = myRequestState.requestData.ToString()
          Console.WriteLine(sringContent)
        End If
        Console.WriteLine(ControlChars.Cr + "Press 'Enter' key to continue........")
        responseStream.Close()
	       allDone.Set()
      End If
    Catch e As WebException
      Console.WriteLine("WebException raised!")
      Console.WriteLine(ControlChars.Cr + "{0}", e.Message)
      Console.WriteLine(ControlChars.Cr + "{0}", e.Status)
    Catch e As Exception
      Console.WriteLine("Exception raised!")
      Console.WriteLine("Source :{0} ", e.Source)
      Console.WriteLine("Message :{0} ", e.Message)
    End Try
  End Sub ' ReadCallBack 

End Class ' WebRequest_BeginGetResponse

' </Snippet2>
' </Snippet1>


