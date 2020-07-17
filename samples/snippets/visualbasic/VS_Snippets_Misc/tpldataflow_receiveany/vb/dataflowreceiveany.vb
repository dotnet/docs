' <snippet1> 
Imports System.Threading
Imports System.Threading.Tasks.Dataflow

' Demonstrates how to unlink dataflow blocks.
Friend Class DataflowReceiveAny
    ' Receives the value from the first provided source that has 
    ' a message.
    Public Shared Function ReceiveFromAny(Of T)(ParamArray ByVal sources() As ISourceBlock(Of T)) As T
        ' Create a WriteOnceBlock<T> object and link it to each source block.
        Dim writeOnceBlock = New WriteOnceBlock(Of T)(Function(e) e)
        For Each source In sources
            ' Setting MaxMessages to one instructs
            ' the source block to unlink from the WriteOnceBlock<T> object
            ' after offering the WriteOnceBlock<T> object one message.
            source.LinkTo(writeOnceBlock, New DataflowLinkOptions With {.MaxMessages = 1})
        Next source
        ' Return the first value that is offered to the WriteOnceBlock object.
        Return writeOnceBlock.Receive()
    End Function

    ' Demonstrates a function that takes several seconds to produce a result.
    Private Shared Function TrySolution(ByVal n As Integer, ByVal ct As CancellationToken) As Integer
        ' Simulate a lengthy operation that completes within three seconds
        ' or when the provided CancellationToken object is cancelled.
        SpinWait.SpinUntil(Function() ct.IsCancellationRequested, New Random().Next(3000))

        ' Return a value.
        Return n + 42
    End Function

    Shared Sub Main(ByVal args() As String)
        ' Create a shared CancellationTokenSource object to enable the 
        ' TrySolution method to be cancelled.
        Dim cts = New CancellationTokenSource()

        ' Create three TransformBlock<int, int> objects. 
        ' Each TransformBlock<int, int> object calls the TrySolution method.
        Dim action As Func(Of Integer, Integer) = Function(n) TrySolution(n, cts.Token)
        Dim trySolution1 = New TransformBlock(Of Integer, Integer)(action)
        Dim trySolution2 = New TransformBlock(Of Integer, Integer)(action)
        Dim trySolution3 = New TransformBlock(Of Integer, Integer)(action)

        ' Post data to each TransformBlock<int, int> object.
        trySolution1.Post(11)
        trySolution2.Post(21)
        trySolution3.Post(31)

        ' Call the ReceiveFromAny<T> method to receive the result from the 
        ' first TransformBlock<int, int> object to finish.
        Dim result As Integer = ReceiveFromAny(trySolution1, trySolution2, trySolution3)

        ' Cancel all calls to TrySolution that are still active.
        cts.Cancel()

        ' Print the result to the console.
        Console.WriteLine("The solution is {0}.", result)

        cts.Dispose()
    End Sub
End Class

' Sample output:
'The solution is 53.
'
' </snippet1>
