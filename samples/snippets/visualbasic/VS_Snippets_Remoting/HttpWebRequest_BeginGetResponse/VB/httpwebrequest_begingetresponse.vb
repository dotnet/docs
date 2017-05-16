' System.Net.HttpWebRequest.BeginGetResponse  System.Net.HttpWebRequest.EndGetResponse
  
  ' Snippet1,Snippet2,Snippet3 go together.
  ' This program shows how to use BeginGetResponse and EndGetResponse methods of the 
  ' HttpWebRequest class.
  ' It uses an asynchronous approach to get the response for the HTTP Web Request.
  ' The RequestState class is defined to chekc the state of the request.
  ' After a HttpWebRequest object is created, its BeginGetResponse method is used to start 
  ' the asynchronous response phase.
  ' Finally, the EndGetResponse method is used to end the asynchronous response phase .*/

Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic



Public Class RequestState
  ' This class stores the State of the request
  Private Shared BUFFER_SIZE As Integer = 1024
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
  End Sub ' New

End Class ' RequestState


Class HttpWebRequest_BeginGetResponse
  Public Shared allDone As New ManualResetEvent(False)
  Private Shared BUFFER_SIZE As Integer = 1024
  
  Shared Sub Main()
' <Snippet1>      
' <Snippet2>
    Try
      ' Create a new HttpWebrequest object to the desired URL.
      Dim myHttpWebRequest1 As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
      
      ' Create an instance of the RequestState and assign the previous myHttpWebRequest1
      ' object to it's request field.  
      Dim myRequestState As New RequestState()
      myRequestState.request = myHttpWebRequest1
      
      ' Start the Asynchronous request.
      Dim result As IAsyncResult = CType(myHttpWebRequest1.BeginGetResponse(AddressOf RespCallback, myRequestState), IAsyncResult)
      allDone.WaitOne()
    
      ' Release the HttpWebResponse resource.
      myRequestState.response.Close()
    Catch e As WebException
      Console.WriteLine(ControlChars.Cr + "Exception raised!")
      Console.WriteLine(ControlChars.Cr + "Message:{0}", e.Message)
      Console.WriteLine(ControlChars.Cr + "Status:{0}", e.Status)
      Console.WriteLine("Press any key to continue..........")
    
    Catch e As Exception
      Console.WriteLine(ControlChars.Cr + "Exception raised!")
      Console.WriteLine("Source :{0} ", e.Source)
      Console.WriteLine("Message : {0}", e.Message)
      Console.WriteLine("Press any key to continue..........")
      Console.Read()
    End Try
  End Sub ' Main
  
  Private Shared Sub RespCallback(asynchronousResult As IAsyncResult)
    Try
      ' State of request is asynchronous.
      Dim myRequestState As RequestState = CType(asynchronousResult.AsyncState, RequestState)
      Dim myHttpWebRequest2 As HttpWebRequest = myRequestState.request
      myRequestState.response = CType(myHttpWebRequest2.EndGetResponse(asynchronousResult), HttpWebResponse)
      ' Read the response into a Stream object.
      Dim responseStream As Stream = myRequestState.response.GetResponseStream()
      myRequestState.streamResponse = responseStream
      ' Begin the Reading of the contents of the HTML page and print it to the console.
      Dim asynchronousInputRead As IAsyncResult = responseStream.BeginRead(myRequestState.BufferRead, 0, BUFFER_SIZE, AddressOf ReadCallBack, myRequestState)
    Catch e As WebException
      Console.WriteLine(ControlChars.Cr + "Exception raised!")
      Console.WriteLine(ControlChars.Cr + "Message:{0}", e.Message)
      Console.WriteLine(ControlChars.Cr + "Status:{0}", e.Status)
    End Try 
  End Sub ' RespCallback
  
  Private Shared Sub ReadCallBack(asyncResult As IAsyncResult)
    Try
      Dim myRequestState As RequestState = CType(asyncResult.AsyncState, RequestState)
      Dim responseStream As Stream = myRequestState.streamResponse
      Dim read As Integer = responseStream.EndRead(asyncResult)
      '  Read the HTML page and then print it to the console.
      If read > 0 Then
        myRequestState.requestData.Append(Encoding.ASCII.GetString(myRequestState.BufferRead, 0, read))
        Dim asynchronousResult As IAsyncResult = responseStream.BeginRead(myRequestState.BufferRead, 0, BUFFER_SIZE, AddressOf ReadCallBack, myRequestState)
      Else
        Console.WriteLine(ControlChars.Cr + "The contents of the Html page are : ")
        If myRequestState.requestData.Length > 1 Then
          Dim stringContent As String
          stringContent = myRequestState.requestData.ToString()
          Console.WriteLine(stringContent)
        End If
        Console.WriteLine("Press any key to continue..........")
        Console.ReadLine()
        responseStream.Close()
        allDone.Set()
      End If
    Catch e As WebException
      Console.WriteLine(ControlChars.Cr + "Exception raised!")
      Console.WriteLine(ControlChars.Cr + "Message:{0}", e.Message)
      Console.WriteLine(ControlChars.Cr + "Status:{0}", e.Status)
    End Try 
  End Sub ' ReadCallBack
' </Snippet2>
' </Snippet1>
End Class ' HttpWebRequest_BeginGetResponse 

