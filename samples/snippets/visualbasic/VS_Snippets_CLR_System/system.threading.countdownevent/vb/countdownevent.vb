'<snippet01>
Imports System.Collections.Concurrent
Imports System.Linq
Imports System.Threading
Imports System.Threading.Tasks

Module Example
    Sub Main()
        ' Initialize a queue and a CountdownEvent
        Dim queue As New ConcurrentQueue(Of Integer)(Enumerable.Range(0, 10000))
        Dim cde As New CountdownEvent(10000)
        ' initial count = 10000
        ' This is the logic for all queue consumers
        Dim consumer As Action =
            Sub()
                Dim local As Integer
                ' decrement CDE count once for each element consumed from queue
                While queue.TryDequeue(local)
                    cde.Signal()
                End While
            End Sub

        ' Now empty the queue with a couple of asynchronous tasks
        Dim t1 As Task = Task.Factory.StartNew(consumer)
        Dim t2 As Task = Task.Factory.StartNew(consumer)

        ' And wait for queue to empty by waiting on cde
        cde.Wait()
        ' will return when cde count reaches 0
        Console.WriteLine("Done emptying queue. InitialCount={0}, CurrentCount={1}, IsSet={2}", cde.InitialCount, cde.CurrentCount, cde.IsSet)

        ' Proper form is to wait for the tasks to complete, even if you know that their work
        ' is done already.
        Task.WaitAll(t1, t2)

        ' Resetting will cause the CountdownEvent to un-set, and resets InitialCount/CurrentCount
        ' to the specified value
        cde.Reset(10)

        ' AddCount will affect the CurrentCount, but not the InitialCount
        cde.AddCount(2)

        Console.WriteLine("After Reset(10), AddCount(2): InitialCount={0}, CurrentCount={1}, IsSet={2}", cde.InitialCount, cde.CurrentCount, cde.IsSet)

        ' Now try waiting with cancellation
        Dim cts As New CancellationTokenSource()
        cts.Cancel()
        ' cancels the CancellationTokenSource
        Try
            cde.Wait(cts.Token)
        Catch generatedExceptionName As OperationCanceledException
            Console.WriteLine("cde.Wait(preCanceledToken) threw OCE, as expected")
        Finally
           cts.Dispose()
        End Try

        ' It's good for to release a CountdownEvent when you're done with it.
        cde.Dispose()
    End Sub
End Module
' The example displays the following output:
'    Done emptying queue.  InitialCount=10000, CurrentCount=0, IsSet=True
'    After Reset(10), AddCount(2): InitialCount=10, CurrentCount=12, IsSet=False
'    cde.Wait(preCanceledToken) threw OCE, as expected
' </snippet01>
