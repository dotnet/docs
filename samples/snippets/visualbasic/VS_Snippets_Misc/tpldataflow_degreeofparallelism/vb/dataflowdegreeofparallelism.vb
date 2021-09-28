' <snippet1>
Imports System.Diagnostics
Imports System.Threading
Imports System.Threading.Tasks.Dataflow

'<Snippet2>
' Demonstrates how to specify the maximum degree of parallelism 
' when using dataflow.
Friend Class Program
    ' Performs several computations by using dataflow and returns the elapsed
    ' time required to perform the computations.
    Private Shared Function TimeDataflowComputations(ByVal maxDegreeOfParallelism As Integer, ByVal messageCount As Integer) As TimeSpan
        ' Create an ActionBlock<int> that performs some work.
        Dim workerBlock = New ActionBlock(Of Integer)(Function(millisecondsTimeout) Pause(millisecondsTimeout), New ExecutionDataflowBlockOptions() With {.MaxDegreeOfParallelism = maxDegreeOfParallelism})
        ' Simulate work by suspending the current thread.
        ' Specify a maximum degree of parallelism.

        ' Compute the time that it takes for several messages to 
        ' flow through the dataflow block.

        Dim stopwatch As New Stopwatch()
        stopwatch.Start()

        For i As Integer = 0 To messageCount - 1
            workerBlock.Post(1000)
        Next i
        workerBlock.Complete()

        ' Wait for all messages to propagate through the network.
        workerBlock.Completion.Wait()

        ' Stop the timer and return the elapsed number of milliseconds.
        stopwatch.Stop()
        Return stopwatch.Elapsed
    End Function

    Private Shared Function Pause(ByVal obj As Object)
        Thread.Sleep(obj)
        Return Nothing
    End Function
    '</Snippet2>
    Shared Sub Main(ByVal args() As String)
        Dim processorCount As Integer = Environment.ProcessorCount
        Dim messageCount As Integer = processorCount

        ' Print the number of processors on this computer.
        Console.WriteLine("Processor count = {0}.", processorCount)

        Dim elapsed As TimeSpan

        ' Perform two dataflow computations and print the elapsed
        ' time required for each.

        ' This call specifies a maximum degree of parallelism of 1.
        ' This causes the dataflow block to process messages serially.
        elapsed = TimeDataflowComputations(1, messageCount)
        Console.WriteLine("Degree of parallelism = {0}; message count = {1}; " & "elapsed time = {2}ms.", 1, messageCount, CInt(Fix(elapsed.TotalMilliseconds)))

        ' Perform the computations again. This time, specify the number of 
        ' processors as the maximum degree of parallelism. This causes
        ' multiple messages to be processed in parallel.
        elapsed = TimeDataflowComputations(processorCount, messageCount)
        Console.WriteLine("Degree of parallelism = {0}; message count = {1}; " & "elapsed time = {2}ms.", processorCount, messageCount, CInt(Fix(elapsed.TotalMilliseconds)))
    End Sub
End Class

' Sample output:
'Processor count = 4.
'Degree of parallelism = 1; message count = 4; elapsed time = 4032ms.
'Degree of parallelism = 4; message count = 4; elapsed time = 1001ms.
'
' </snippet1>
