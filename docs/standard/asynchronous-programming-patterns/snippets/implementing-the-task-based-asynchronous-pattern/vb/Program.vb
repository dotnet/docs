Imports System
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Threading.Tasks

' <ManualTapImplementation>
Module StreamExtensions
    <Extension()>
    Public Function ReadTask(stream As Stream, buffer As Byte(),
                             offset As Integer, count As Integer,
                             state As Object) As Task(Of Integer)
        Dim tcs As New TaskCompletionSource(Of Integer)()
        stream.BeginRead(buffer, offset, count,
            Sub(ar)
                Try
                    tcs.SetResult(stream.EndRead(ar))
                Catch exc As Exception
                    tcs.SetException(exc)
                End Try
            End Sub, state)
        Return tcs.Task
    End Function
End Module
' </ManualTapImplementation>

' <HybridApproach>
Class Calculator
    Private value As Integer = 0

    Public Function MethodAsync(input As String) As Task(Of Integer)
        If input Is Nothing Then Throw New ArgumentNullException(NameOf(input))
        Return MethodAsyncInternal(input)
    End Function

    Private Async Function MethodAsyncInternal(input As String) As Task(Of Integer)
        ' code that uses await goes here
        Await Task.Delay(1)
        Return value
    End Function
End Class
' </HybridApproach>

Friend Class ImageData
    Public Property Width As Integer = 1
    Public Property Height As Integer = 1
End Class

Module ImageRenderer
    ' <ComputeBoundTask>
    Friend Function RenderAsync(data As ImageData, cancellationToken As CancellationToken) As Task(Of Bitmap)
        Return Task.Run(Function()
                            Dim bmp As New Bitmap(data.Width, data.Height)
                            For y As Integer = 0 To data.Height - 1
                                cancellationToken.ThrowIfCancellationRequested()
                                For x As Integer = 0 To data.Width - 1
                                    ' render pixel [x,y] into bmp
                                Next
                            Next
                            Return bmp
                        End Function, cancellationToken)
    End Function
    ' </ComputeBoundTask>

    ' <MixedBoundTask>
    Public Async Function DownloadDataAndRenderImageAsync(cancellationToken As CancellationToken) As Task(Of Bitmap)
        Dim imageData As ImageData = Await DownloadImageDataAsync(cancellationToken)
        Return Await RenderAsync(imageData, cancellationToken)
    End Function
    ' </MixedBoundTask>

    Private Function DownloadImageDataAsync(ct As CancellationToken) As Task(Of ImageData)
        Return Task.FromResult(New ImageData())
    End Function
End Module

Module TimerExamples
    ' <DelayWithTimer>
    Public Function Delay(millisecondsTimeout As Integer) As Task(Of DateTimeOffset)
        Dim tcs As TaskCompletionSource(Of DateTimeOffset) = Nothing
        Dim timer As Timer = Nothing

        timer = New Timer(Sub(obj)
                              timer.Dispose()
                              tcs.TrySetResult(DateTimeOffset.UtcNow)
                          End Sub, Nothing, Timeout.Infinite, Timeout.Infinite)

        tcs = New TaskCompletionSource(Of DateTimeOffset)(timer)
        timer.Change(millisecondsTimeout, Timeout.Infinite)
        Return tcs.Task
    End Function
    ' </DelayWithTimer>

    ' <DelayBoolResult>
    Public Function DelaySimple(millisecondsTimeout As Integer) As Task(Of Boolean)
        Dim tcs As TaskCompletionSource(Of Boolean) = Nothing
        Dim timer As Timer = Nothing

        timer = New Timer(Sub(obj)
                              timer.Dispose()
                              tcs.TrySetResult(True)
                          End Sub, Nothing, Timeout.Infinite, Timeout.Infinite)

        tcs = New TaskCompletionSource(Of Boolean)(timer)
        timer.Change(millisecondsTimeout, Timeout.Infinite)
        Return tcs.Task
    End Function
    ' </DelayBoolResult>

    ' <PollingLoop>
    Public Async Function Poll(url As Uri, cancellationToken As CancellationToken,
                               progress As IProgress(Of Boolean)) As Task
        Do While True
            Await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken)
            Dim success As Boolean = False
            Try
                Await DownloadStringAsync(url)
                success = True
            Catch
                ' ignore errors
            End Try
            progress.Report(success)
        Loop
    End Function
    ' </PollingLoop>

    Private Function DownloadStringAsync(url As Uri) As Task(Of String)
        Return Task.FromResult(String.Empty)
    End Function
End Module

Module Program
    Sub Main()
        Dim bmp As Bitmap = ImageRenderer.DownloadDataAndRenderImageAsync(CancellationToken.None).GetAwaiter().GetResult()
        Console.WriteLine($"Rendered {bmp.Width}x{bmp.Height} image.")
    End Sub
End Module

