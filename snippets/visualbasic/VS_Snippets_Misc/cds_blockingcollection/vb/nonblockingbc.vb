'<snippet02>
Option Strict On
Option Explicit On
Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks

Class NonBlockingAccess
    Shared inputs As Integer = 2000

    Shared Sub Main()
        ' The token source for issuing the cancelation request.
        Dim cts As New CancellationTokenSource()

        ' A blocking collection that can hold no more than 100 items at a time.
        Dim numberCollection As BlockingCollection(Of Integer) = New BlockingCollection(Of Integer)(100)

        ' Set console buffer to hold our prodigious output.
        Console.SetBufferSize(80, 2000)

        ' The simplest UI thread ever invented.
        Task.Run(Sub()
                     If Console.ReadKey.KeyChar() = "c"c Then
                         cts.Cancel()
                     End If
                 End Sub)

        ' Start one producer and one consumer.
        Dim t1 As Task = Task.Run(Sub() NonBlockingConsumer(numberCollection, cts.Token))
        Dim t2 As Task = Task.Run(Sub() NonBlockingProducer(numberCollection, cts.Token))

        ' Wait for the tasks to complete execution
        Task.WaitAll(t1, t2)

        cts.Dispose()
        Console.WriteLine("Press the Enter key to exit.")
        Console.ReadLine()

    End Sub

    Shared Sub NonBlockingConsumer(ByVal bc As BlockingCollection(Of Integer), ByVal ct As CancellationToken)

        ' IsCompleted is equivalent to (IsAddingCompleted And Count = 0)
        While bc.IsCompleted = False
            Dim nextItem As Integer = 0
            Try
                If bc.TryTake(nextItem, 0, ct) = False Then
                    Console.WriteLine("  Take Blocked.")
                Else
                    Console.WriteLine(" Take: {0}", nextItem)
                End If
            Catch ex As OperationCanceledException
                Console.WriteLine("Taking canceled.")
                Exit While
            End Try
            'Slow down consumer just a little to cause
            ' collection to fill up faster, and lead to "AddBlocked"
            Thread.SpinWait(500000)
        End While

        Console.WriteLine(vbCrLf & "No more items to take.")
    End Sub

    Shared Sub NonBlockingProducer(ByVal bc As BlockingCollection(Of Integer), ByVal ct As CancellationToken)
        Dim itemToAdd As Integer = 0
        Dim success As Boolean = False

        Do
            'Cancellation causes OCE. We know how to handle it.
            Try
                success = bc.TryAdd(itemToAdd, 2, ct)
            Catch ex As OperationCanceledException
                Console.WriteLine("Add loop canceled.")

                ' Let other threads know we're done in case
                ' they aren't monitoring the cancellation token.
                bc.CompleteAdding()
                Exit Do
            End Try

            If success = True Then
                Console.WriteLine(" Add:{0}", itemToAdd)
                itemToAdd = itemToAdd + 1
            Else
                Console.Write("  AddBlocked:{0} Count = {1}", itemToAdd.ToString(), bc.Count)

                ' Don't increment nextItem. Try again on next iteration
                ' Do something else useful instead.
                UpdateProgress(itemToAdd)
            End If
        Loop While itemToAdd < inputs

        ' No lock required here because only one producer.
        bc.CompleteAdding()

    End Sub

    Shared Sub UpdateProgress(ByVal i As Integer)
        Dim percent As Double = (CType(i, Double) / inputs) * 100
        Console.WriteLine("Percent complete: {0}", percent)
    End Sub
End Class
'</snippet02>