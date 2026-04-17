Imports System
Imports System.Collections.Concurrent
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Net
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Threading.Tasks.Dataflow

' Stub types/methods used throughout examples
Module Stubs
    Public Function DownloadStringTaskAsync(url As String, Optional ct As CancellationToken = Nothing) As Task(Of String)
        Return Task.FromResult("")
    End Function

    Public Function DownloadDataAsync(url As String, Optional ct As CancellationToken = Nothing) As Task(Of Byte())
        Return Task.FromResult(Array.Empty(Of Byte)())
    End Function

    Public Function SaveToDiskAsync(path As String, data As Byte(), ct As CancellationToken) As Task
        Return Task.CompletedTask
    End Function

    Public Function SendMailAsync(addr As String, Optional ct As CancellationToken = Nothing) As Task
        Return Task.CompletedTask
    End Function

    Public Function GetBuyRecommendation1Async(symbol As String, Optional ct As CancellationToken = Nothing) As Task(Of Boolean)
        Return Task.FromResult(True)
    End Function

    Public Function GetBuyRecommendation2Async(symbol As String, Optional ct As CancellationToken = Nothing) As Task(Of Boolean)
        Return Task.FromResult(True)
    End Function

    Public Function GetBuyRecommendation3Async(symbol As String, Optional ct As CancellationToken = Nothing) As Task(Of Boolean)
        Return Task.FromResult(True)
    End Function

    Public Function GetBitmapAsync(url As String, Optional ct As CancellationToken = Nothing) As Task(Of Bitmap)
        Return Task.FromResult(New Bitmap(1, 1))
    End Function

    Public Function ConvertImage(bmp As Bitmap) As Bitmap
        Return bmp
    End Function

    Public Function Mashup(b1 As Bitmap, b2 As Bitmap) As Bitmap
        Return b1
    End Function

    Public Function DownloadFirstImageAsync() As Task(Of Bitmap)
        Return Task.FromResult(New Bitmap(1, 1))
    End Function

    Public Function DownloadSecondImageAsync() As Task(Of Bitmap)
        Return Task.FromResult(New Bitmap(1, 1))
    End Function

    Public Sub BuyStock(symbol As String)
    End Sub

    Public Sub Log(o As Object)
    End Sub

    Public Sub ProcessNextItem(item As Integer)
    End Sub

    Public Function TryGetCachedValue(ByRef value As Integer) As Boolean
        value = 0
        Return False
    End Function

    Public addrs As String() = Array.Empty(Of String)()
    Public urls As String() = Array.Empty(Of String)()
End Module

Module Examples

    ' ---- Yield example ----
    ' <YieldLoop>
    Public Async Function YieldLoopExample() As Task
        Await Task.Run(Async Sub()
                           For i As Integer = 0 To 999999
                               Await Task.Yield() ' fork the continuation into a separate work item
                           Next
                       End Sub)
    End Function
    ' </YieldLoop>

    ' ---- Task.Run examples ----
    ' <TaskRunBasic>
    Public Async Function TaskRunBasicExample() As Task
        Dim answer As Integer = 42
        Dim result As String = Await Task.Run(Function()
                                                  ' … do compute-bound work here
                                                  Return answer.ToString()
                                              End Function)
        Console.WriteLine(result)
    End Function
    ' </TaskRunBasic>

    ' <TaskRunAsync>
    Public Async Function TaskRunAsyncExample() As Task
        Dim image As Bitmap = Await Task.Run(Async Function()
                                                 Using bmp1 As Bitmap = Await Stubs.DownloadFirstImageAsync()
                                                     Using bmp2 As Bitmap = Await Stubs.DownloadSecondImageAsync()
                                                         Return Stubs.Mashup(bmp1, bmp2)
                                                     End Using
                                                 End Using
                                             End Function)
    End Function
    ' </TaskRunAsync>

    ' ---- Task.FromResult ----
    ' <TaskFromResult>
    Public Function GetValueAsync(key As String) As Task(Of Integer)
        Dim cachedValue As Integer
        If Stubs.TryGetCachedValue(cachedValue) Then
            Return Task.FromResult(cachedValue)
        Else
            Return GetValueAsyncInternal(key)
        End If
    End Function

    Private Async Function GetValueAsyncInternal(key As String) As Task(Of Integer)
        Await Task.Delay(1)
        Return 0
    End Function
    ' </TaskFromResult>

    ' ---- Task.WhenAll ----
    ' <WhenAllBasic>
    Public Async Function WhenAllBasic() As Task
        Dim asyncOps As IEnumerable(Of Task) = From addr In Stubs.addrs Select Stubs.SendMailAsync(addr)
        Await Task.WhenAll(asyncOps)
    End Function
    ' </WhenAllBasic>

    ' <WhenAllWithCatch>
    Public Async Function WhenAllWithCatch() As Task
        Dim asyncOps As IEnumerable(Of Task) = From addr In Stubs.addrs Select Stubs.SendMailAsync(addr)
        Try
            Await Task.WhenAll(asyncOps)
        Catch exc As Exception
            Console.WriteLine(exc)
        End Try
    End Function
    ' </WhenAllWithCatch>

    ' <WhenAllExamineExceptions>
    Public Async Function WhenAllExamineExceptions() As Task
        Dim asyncOps As Task() = (From addr In Stubs.addrs Select Stubs.SendMailAsync(addr)).ToArray()
        Try
            Await Task.WhenAll(asyncOps)
        Catch exc As Exception
            For Each faulted As Task In asyncOps.Where(Function(t) t.IsFaulted)
                Console.WriteLine($"Faulted: {faulted.Exception}")
            Next
        End Try
    End Function
    ' </WhenAllExamineExceptions>

    ' <WhenAllDownloadPages>
    Public Async Function WhenAllDownloadPages() As Task
        Dim pages As String() = Await Task.WhenAll(
            From url In Stubs.urls Select Stubs.DownloadStringTaskAsync(url))
        Console.WriteLine(pages.Length)
    End Function
    ' </WhenAllDownloadPages>

    ' <WhenAllDownloadPagesExceptions>
    Public Async Function WhenAllDownloadPagesExceptions() As Task
        Dim asyncOps As Task(Of String)() =
            (From url In Stubs.urls Select Stubs.DownloadStringTaskAsync(url)).ToArray()
        Try
            Dim pages As String() = Await Task.WhenAll(asyncOps)
            Console.WriteLine(pages.Length)
        Catch exc As Exception
            For Each faulted As Task(Of String) In asyncOps.Where(Function(t) t.IsFaulted)
                Console.WriteLine($"Faulted: {faulted.Exception}")
            Next
        End Try
    End Function
    ' </WhenAllDownloadPagesExceptions>

    ' ---- Task.WhenAny ----
    ' <WhenAnyRedundancy>
    Public Async Function WhenAnyRedundancy(symbol As String) As Task
        Dim recommendations As New List(Of Task(Of Boolean)) From {
            Stubs.GetBuyRecommendation1Async(symbol),
            Stubs.GetBuyRecommendation2Async(symbol),
            Stubs.GetBuyRecommendation3Async(symbol)
        }
        Dim recommendation As Task(Of Boolean) = Await Task.WhenAny(recommendations)
        If Await recommendation Then Stubs.BuyStock(symbol)
    End Function
    ' </WhenAnyRedundancy>

    ' <WhenAnyRetryOnException>
    Public Async Function WhenAnyRetryOnException(symbol As String) As Task
        Dim allRecommendations As Task(Of Boolean)() = {
            Stubs.GetBuyRecommendation1Async(symbol),
            Stubs.GetBuyRecommendation2Async(symbol),
            Stubs.GetBuyRecommendation3Async(symbol)
        }
        Dim remaining As List(Of Task(Of Boolean)) = allRecommendations.ToList()
        While remaining.Count > 0
            Dim recommendation As Task(Of Boolean) = Await Task.WhenAny(remaining)
            Try
                If Await recommendation Then Stubs.BuyStock(symbol)
                Exit While
            Catch ex As WebException
                remaining.Remove(recommendation)
            End Try
        End While
    End Function
    ' </WhenAnyRetryOnException>

    ' <WhenAnyCancelRemainder>
    Public Async Function WhenAnyCancelRemainder(symbol As String) As Task
        Dim cts As New CancellationTokenSource()
        Dim recommendations As New List(Of Task(Of Boolean)) From {
            Stubs.GetBuyRecommendation1Async(symbol, cts.Token),
            Stubs.GetBuyRecommendation2Async(symbol, cts.Token),
            Stubs.GetBuyRecommendation3Async(symbol, cts.Token)
        }

        Dim recommendation As Task(Of Boolean) = Await Task.WhenAny(recommendations)
        cts.Cancel()
        If Await recommendation Then Stubs.BuyStock(symbol)
    End Function
    ' </WhenAnyCancelRemainder>

    ' <WhenAnyInterleaving>
    Public Async Function WhenAnyInterleaving(imageUrls As String()) As Task
        Dim imageTasks As List(Of Task(Of Bitmap)) =
            (From imageUrl In imageUrls Select Stubs.GetBitmapAsync(imageUrl)).ToList()
        While imageTasks.Count > 0
            Try
                Dim imageTask As Task(Of Bitmap) = Await Task.WhenAny(imageTasks)
                imageTasks.Remove(imageTask)

                Dim image As Bitmap = Await imageTask
                Console.WriteLine($"Got image: {image.Width}x{image.Height}")
            Catch
            End Try
        End While
    End Function
    ' </WhenAnyInterleaving>

    ' <WhenAnyInterleavingWithProcessing>
    Public Async Function WhenAnyInterleavingWithProcessing(imageUrls As String()) As Task
        Dim imageTasks As List(Of Task(Of Bitmap)) =
            (From imageUrl In imageUrls
             Select Stubs.GetBitmapAsync(imageUrl).ContinueWith(Function(t) Stubs.ConvertImage(t.Result))).ToList()
        While imageTasks.Count > 0
            Try
                Dim imageTask As Task(Of Bitmap) = Await Task.WhenAny(imageTasks)
                imageTasks.Remove(imageTask)

                Dim image As Bitmap = Await imageTask
                Console.WriteLine($"Got image: {image.Width}x{image.Height}")
            Catch
            End Try
        End While
    End Function
    ' </WhenAnyInterleavingWithProcessing>

    ' <WhenAnyThrottling>
    Public Async Function WhenAnyThrottling(uriList As Uri()) As Task
        Const CONCURRENCY_LEVEL As Integer = 15
        Dim nextIndex As Integer = 0
        Dim imageTasks As New List(Of Task(Of Bitmap))
        While nextIndex < CONCURRENCY_LEVEL AndAlso nextIndex < uriList.Length
            imageTasks.Add(Stubs.GetBitmapAsync(uriList(nextIndex).ToString()))
            nextIndex += 1
        End While

        While imageTasks.Count > 0
            Try
                Dim imageTask As Task(Of Bitmap) = Await Task.WhenAny(imageTasks)
                imageTasks.Remove(imageTask)

                Dim image As Bitmap = Await imageTask
                Console.WriteLine($"Got image: {image.Width}x{image.Height}")
            Catch exc As Exception
                Stubs.Log(exc)
            End Try

            If nextIndex < uriList.Length Then
                imageTasks.Add(Stubs.GetBitmapAsync(uriList(nextIndex).ToString()))
                nextIndex += 1
            End If
        End While
    End Function
    ' </WhenAnyThrottling>

    ' <EarlyBailout>
    Public Async Function UntilCompletionOrCancellation(
        asyncOp As Task, ct As CancellationToken) As Task(Of Task)
        Dim tcs As New TaskCompletionSource(Of Boolean)()
        Using ct.Register(Sub() tcs.TrySetResult(True))
            Await Task.WhenAny(asyncOp, tcs.Task)
        End Using
        Return asyncOp
    End Function
    ' </EarlyBailout>

    ' ---- LogCompletionIfFailed ----
    ' <LogCompletionIfFailed>
    Private Async Sub LogCompletionIfFailed(tasks As IEnumerable(Of Task))
        For Each task In tasks
            Try
                Await task
            Catch exc As Exception
                Stubs.Log(exc)
            End Try
        Next
    End Sub
    ' </LogCompletionIfFailed>

    ' ---- Task.Delay timeout ----
    Private Sub TraceMsg(message As String)
        Console.WriteLine(message)
    End Sub

    ' <DelayTimeout>
    Public Async Function DownloadWithTimeout(url As String) As Task(Of Bitmap)
        Dim download As Task(Of Bitmap) = Stubs.GetBitmapAsync(url)
        If download Is Await Task.WhenAny(download, Task.Delay(3000)) Then
            Return Await download
        Else
            Dim ignored = download.ContinueWith(Sub(t) TraceMsg($"Task finally completed: {t.Status}"))
            Return Nothing
        End If
    End Function
    ' </DelayTimeout>

    ' <DelayTimeoutMultiple>
    Public Async Function DownloadMultipleWithTimeout(imageUrls As String()) As Task(Of Bitmap())
        Dim downloads As Task(Of Bitmap()) =
            Task.WhenAll(From url In imageUrls Select Stubs.GetBitmapAsync(url))
        If downloads Is Await Task.WhenAny(downloads, Task.Delay(3000)) Then
            Return downloads.Result
        Else
            downloads.ContinueWith(Sub(t) Stubs.Log(t))
            Return Nothing
        End If
    End Function
    ' </DelayTimeoutMultiple>

    ' ---- Combinators ----
    ' <RetryOnFaultSync>
    Public Function RetryOnFaultSync(Of T)(func As Func(Of T), maxTries As Integer) As T
        For i As Integer = 0 To maxTries - 1
            Try
                Return func()
            Catch
                If i = maxTries - 1 Then Throw
            End Try
        Next
        Return Nothing
    End Function
    ' </RetryOnFaultSync>

    ' <RetryOnFaultAsync>
    Public Async Function RetryOnFault(Of T)(func As Func(Of Task(Of T)), maxTries As Integer) As Task(Of T)
        For i As Integer = 0 To maxTries - 1
            Try
                Return Await func().ConfigureAwait(False)
            Catch
                If i = maxTries - 1 Then Throw
            End Try
        Next
        Return Nothing
    End Function
    ' </RetryOnFaultAsync>

    ' <RetryOnFaultWithDelay>
    Public Async Function RetryOnFaultWithDelay(Of T)(
        func As Func(Of Task(Of T)), maxTries As Integer, retryWhen As Func(Of Task)) As Task(Of T)
        For i As Integer = 0 To maxTries - 1
            Try
                Return Await func().ConfigureAwait(False)
            Catch
                If i = maxTries - 1 Then Throw
            End Try
            Await retryWhen().ConfigureAwait(False)
        Next
        Return Nothing
    End Function
    ' </RetryOnFaultWithDelay>

    ' <NeedOnlyOne>
    Public Async Function NeedOnlyOne(Of T)(
        ParamArray functions As Func(Of CancellationToken, Task(Of T))()) As Task(Of T)
        Dim cts As New CancellationTokenSource()
        Dim tasks As Task(Of T)() = (From func In functions Select func(cts.Token)).ToArray()
        Dim completed As Task(Of T) = Await Task.WhenAny(tasks).ConfigureAwait(False)
        cts.Cancel()
        For Each task In tasks
            Dim ignored = task.ContinueWith(
                Sub(tsk) Stubs.Log(tsk), TaskContinuationOptions.OnlyOnFaulted)
        Next
        Return Await completed
    End Function
    ' </NeedOnlyOne>

    ' <Interleaved>
    Public Function Interleaved(Of T)(tasks As IEnumerable(Of Task(Of T))) As IEnumerable(Of Task(Of T))
        Dim inputTasks As List(Of Task(Of T)) = tasks.ToList()
        Dim sources As List(Of TaskCompletionSource(Of T)) =
            (From _i In Enumerable.Range(0, inputTasks.Count) Select New TaskCompletionSource(Of T)()).ToList()
        Dim indexRef As Integer() = {-1}
        For Each inputTask In inputTasks
            inputTask.ContinueWith(Sub(completed)
                                       Dim idx = Interlocked.Increment(indexRef(0))
                                       Dim source = sources(idx)
                                       If completed.IsFaulted Then
                                           source.TrySetException(completed.Exception.InnerExceptions)
                                       ElseIf completed.IsCanceled Then
                                           source.TrySetCanceled()
                                       Else
                                           source.TrySetResult(completed.Result)
                                       End If
                                   End Sub,
                                   CancellationToken.None,
                                   TaskContinuationOptions.ExecuteSynchronously,
                                   TaskScheduler.Default)
        Next
        Return From source In sources Select source.Task
    End Function
    ' </Interleaved>

    ' <WhenAllOrFirstException>
    Public Function WhenAllOrFirstException(Of T)(tasks As IEnumerable(Of Task(Of T))) As Task(Of T())
        Dim inputs As List(Of Task(Of T)) = tasks.ToList()
        Dim ce As New CountdownEvent(inputs.Count)
        Dim tcs As New TaskCompletionSource(Of T())()

        Dim onCompleted As Action(Of Task) = Sub(completed As Task)
                                                 If completed.IsFaulted Then
                                                     tcs.TrySetException(completed.Exception.InnerExceptions)
                                                 End If
                                                 If ce.Signal() AndAlso Not tcs.Task.IsCompleted Then
                                                     tcs.TrySetResult(inputs.Select(Function(taskItem) DirectCast(taskItem, Task(Of T)).Result).ToArray())
                                                 End If
                                             End Sub

        For Each t In inputs
            t.ContinueWith(onCompleted)
        Next
        Return tcs.Task
    End Function
    ' </WhenAllOrFirstException>

    ' ---- AsyncCache usage ----
    ' <AsyncCacheUsage>
    Private m_webPages As New AsyncCache(Of String, String)(Function(url) Stubs.DownloadStringTaskAsync(url))

    Public Async Function UseWebPageCache(url As String) As Task
        Dim contents As String = Await m_webPages(url)
        Console.WriteLine(contents.Length)
    End Function
    ' </AsyncCacheUsage>

    ' ---- AsyncProducerConsumerCollection usage ----
    ' <AsyncProducerConsumerUsage>
    Private m_data As New AsyncProducerConsumerCollection(Of Integer)()

    Public Async Function ConsumerAsync() As Task
        While True
            Dim nextItem As Integer = Await m_data.Take()
            Stubs.ProcessNextItem(nextItem)
        End While
    End Function

    Public Sub Produce(data As Integer)
        m_data.Add(data)
    End Sub
    ' </AsyncProducerConsumerUsage>

    ' <BufferBlockUsage>
    Private m_dataBlock As New BufferBlock(Of Integer)()

    Public Async Function ConsumerAsyncBlock() As Task
        While True
            Dim nextItem As Integer = Await m_dataBlock.ReceiveAsync()
            Stubs.ProcessNextItem(nextItem)
        End While
    End Function

    Public Sub ProduceBlock(data As Integer)
        m_dataBlock.Post(data)
    End Sub
    ' </BufferBlockUsage>

    ' ---- Cancellation examples ----
    ' <CancelSingleDownload>
    Public Async Function CancelSingleDownload(url As String) As Task
        Dim cts As New CancellationTokenSource()
        Dim result As String = Await Stubs.DownloadStringTaskAsync(url, cts.Token)
        ' at some point later, potentially on another thread
        cts.Cancel()
        Console.WriteLine(result)
    End Function
    ' </CancelSingleDownload>

    ' <CancelMultipleDownloads>
    Public Async Function CancelMultipleDownloads(urlList As String()) As Task
        Dim cts As New CancellationTokenSource()
        Dim results As IList(Of String) = Await Task.WhenAll(
            From url In urlList Select Stubs.DownloadStringTaskAsync(url, cts.Token))
        ' at some point later, potentially on another thread
        cts.Cancel()
        Console.WriteLine(results.Count)
    End Function
    ' </CancelMultipleDownloads>

    ' <CancelSubsetDownloads>
    Public Async Function CancelSubsetDownloads(url As String, outputPath As String) As Task
        Dim cts As New CancellationTokenSource()
        Dim data As Byte() = Await Stubs.DownloadDataAsync(url, cts.Token)
        Await Stubs.SaveToDiskAsync(outputPath, data, CancellationToken.None)
        ' at some point later, potentially on another thread
        cts.Cancel()
    End Function
    ' </CancelSubsetDownloads>

End Module

' ---- AsyncCache ----
' <AsyncCache>
Public Class AsyncCache(Of TKey, TValue)
    Private ReadOnly _valueFactory As Func(Of TKey, Task(Of TValue))
    Private ReadOnly _map As New ConcurrentDictionary(Of TKey, Lazy(Of Task(Of TValue)))()

    Public Sub New(valueFactory As Func(Of TKey, Task(Of TValue)))
        If valueFactory Is Nothing Then Throw New ArgumentNullException(NameOf(valueFactory))
        _valueFactory = valueFactory
    End Sub

    Default Public ReadOnly Property Item(key As TKey) As Task(Of TValue)
        Get
            If key Is Nothing Then Throw New ArgumentNullException(NameOf(key))
            Return _map.GetOrAdd(key, Function(toAdd) New Lazy(Of Task(Of TValue))(Function() _valueFactory(toAdd))).Value
        End Get
    End Property
End Class
' </AsyncCache>

' ---- AsyncProducerConsumerCollection ----
' <AsyncProducerConsumerCollection>
Public Class AsyncProducerConsumerCollection(Of T)
    Private ReadOnly m_collection As New Queue(Of T)()
    Private ReadOnly m_waiting As New Queue(Of TaskCompletionSource(Of T))()

    Public Sub Add(item As T)
        Dim tcs As TaskCompletionSource(Of T) = Nothing
        SyncLock m_collection
            If m_waiting.Count > 0 Then
                tcs = m_waiting.Dequeue()
            Else
                m_collection.Enqueue(item)
            End If
        End SyncLock
        If tcs IsNot Nothing Then tcs.TrySetResult(item)
    End Sub

    Public Function Take() As Task(Of T)
        SyncLock m_collection
            If m_collection.Count > 0 Then
                Return Task.FromResult(m_collection.Dequeue())
            Else
                Dim tcs As New TaskCompletionSource(Of T)()
                m_waiting.Enqueue(tcs)
                Return tcs.Task
            End If
        End SyncLock
    End Function
End Class
' </AsyncProducerConsumerCollection>

' <EarlyBailoutUI>
Class EarlyBailoutUI
    Private m_cts As CancellationTokenSource

    Public Sub btnCancel_Click(sender As Object, e As EventArgs)
        If m_cts IsNot Nothing Then m_cts.Cancel()
    End Sub

    Public Async Sub btnRun_Click(sender As Object, e As EventArgs)
        m_cts = New CancellationTokenSource()
        Try
            Dim imageDownload As Task(Of Bitmap) = Stubs.GetBitmapAsync("url")
            Await Examples.UntilCompletionOrCancellation(imageDownload, m_cts.Token)
            If imageDownload.IsCompleted Then
                Dim image As Bitmap = Await imageDownload
                Stubs.Log(image)
            Else
                imageDownload.ContinueWith(Sub(t) Stubs.Log(t))
            End If
        Finally
        End Try
    End Sub
End Class
' </EarlyBailoutUI>

' <EarlyBailoutWithTokenUI>
Class EarlyBailoutWithTokenUI
    Private m_cts As CancellationTokenSource

    Public Async Sub btnRun_Click(sender As Object, e As EventArgs)
        m_cts = New CancellationTokenSource()
        Try
            Dim imageDownload As Task(Of Bitmap) = Stubs.GetBitmapAsync("url", m_cts.Token)
            Await Examples.UntilCompletionOrCancellation(imageDownload, m_cts.Token)
            Dim image As Bitmap = Await imageDownload
            Stubs.Log(image)
        Catch ex As OperationCanceledException
        Finally
        End Try
    End Sub
End Class
' </EarlyBailoutWithTokenUI>

Module Program
    Sub Main()
        Console.WriteLine("Done.")
    End Sub
End Module

