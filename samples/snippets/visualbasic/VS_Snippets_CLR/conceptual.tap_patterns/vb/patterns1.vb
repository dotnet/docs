' Visual Basic .NET Document
Option Strict On

Imports System.IO
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Threading.Tasks

Module Example
    ' <Snippet1>
    <Extension()>
    Public Function ReadTask(stream As Stream, buffer() As Byte, 
                             offset As Integer, count As Integer, 
                             state As Object) As Task(Of Integer)
        Dim tcs As New TaskCompletionSource(Of Integer)()
        stream.BeginRead(buffer, offset, count, Sub(ar)
                   Try  
                      tcs.SetResult(stream.EndRead(ar)) 
                   Catch exc As Exception 
                      tcs.SetException(exc)
                   End Try
                End Sub, state)
        Return tcs.Task
    End Function   
    ' </Snippet1>
    
   Dim value As Integer= 0

   ' <Snippet2>
   Public Function MethodAsync(input As String) As Task(Of Integer)
       If input Is Nothing Then Throw New ArgumentNullException("input")

       Return MethodAsyncInternal(input)
   End Function
   
   Private Async Function MethodAsyncInternal(input As String) As Task(Of Integer)

      ' code that uses await goes here
      
      return value
   End Function
   ' </Snippet2>  
     
   ' <Snippet3>
   Friend Function RenderAsync(data As ImageData, cancellationToken As _
                               CancellationToken) As Task(Of Bitmap)
       Return Task.Run( Function()
                           Dim bmp As New Bitmap(data.Width, data.Height)
                           For y As Integer = 0 to data.Height - 1
                              cancellationToken.ThrowIfCancellationRequested()
                              For x As Integer = 0 To data.Width - 1
                                ' render pixel [x,y] into bmp
                              Next
                           Next
                           Return bmp
                        End Function, cancellationToken)
   End Function
   ' </Snippet3>   

    ' <Snippet4>
    Public Function Delay(millisecondsTimeout As Integer) As Task(Of DateTimeOffset) 
        Dim tcs As TaskCompletionSource(Of DateTimeOffset) = Nothing
        Dim timer As Timer = Nothing
        
        timer = New Timer( Sub(obj)
                              timer.Dispose()
                              tcs.TrySetResult(DateTimeOffset.UtcNow)
                           End Sub, Nothing, Timeout.Infinite, Timeout.Infinite)
 
        tcs = New TaskCompletionSource(Of DateTimeOffset)(timer)
        timer.Change(millisecondsTimeout, Timeout.Infinite)
        Return tcs.Task
    End Function
    ' </Snippet4>

   ' <Snippet5>
   Public Async Function Poll(url As Uri, cancellationToken As CancellationToken, 
                              progress As IProgress(Of Boolean)) As Task
       Do While True
           Await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken)
           Dim success As Boolean = False
           Try
               await DownloadStringAsync(url)
               success = true
           Catch
              ' ignore errors
           End Try   
           progress.Report(success)
       Loop
   End Function
   ' </Snippet5>

   Private Function DownloadStringAsync(url As Uri) As Task(Of String) 
      Dim tcs As New TaskCompletionSource(Of String)()
      Return tcs.Task 
   End Function
End Module

Public Module Pattern2
   ' <Snippet6>
   Public Function Delay(millisecondsTimeout As Integer) As Task(Of Boolean)
        Dim tcs As TaskCompletionSource(Of Boolean) = Nothing
        Dim timer As Timer = Nothing
 
        Timer = new Timer( Sub(obj)
                              timer.Dispose()
                              tcs.TrySetResult(True)
                           End Sub, Nothing, Timeout.Infinite, Timeout.Infinite)
 
        tcs = New TaskCompletionSource(Of Boolean)(timer)
        timer.Change(millisecondsTimeout, Timeout.Infinite)
        Return tcs.Task
   End Function
   ' </Snippet6> 

   ' <Snippet7>
   Public Async Function DownloadDataAndRenderImageAsync(
                cancellationToken As CancellationToken) As Task(Of Bitmap) 
       Dim imageData As ImageData = Await DownloadImageDataAsync(cancellationToken)
       Return Await RenderAsync(imageData, cancellationToken)
   End Function
   ' </Snippet7>
   
   Private Async Function DownloadImageDataAsync(c As CancellationToken) As Task(Of ImageData) 
      ' return new TaskCompletionSource<ImageData>().Task;
      Return New ImageData()
   End Function
End Module

Friend Class ImageData
    Public Width As Integer = 0
    Public Height As Integer = 0
End Class