'<snippet03>
Option Strict On
Option Explicit On
Imports System.Diagnostics
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Collections.Concurrent


Module EnumerateBC

    Class Program
        ' Limit the collection size to 2000 items
        ' at any given time. Set itemsToProduce to >500
        ' to hit the limit.
        Const upperLimit As Integer = 1000

        ' Adjust this number to see how it impacts
        ' the producing-consuming pattern.
        Const itemsToProduce As Integer = 100

        Shared collection As BlockingCollection(Of Long) = New BlockingCollection(Of Long)(upperLimit)

        ' Variables for diagnostic output only.
        Shared sw As New Stopwatch()
        Shared totalAdditions As Integer = 0

        ' Counter for synchronizing producers.
        Shared producersStillRunning As Integer = 2

        Shared Sub Main()

            ' Start the stopwatch.
            sw.Start()
            ' Queue the Producer threads. 

            Dim task1 = Task.Factory.StartNew(Sub() RunProducer("A", 0))
            Dim task2 = Task.Factory.StartNew(Sub() RunProducer("B", itemsToProduce))

            ' Store in an array for use with ContinueWhenAll
            Dim producers() As Task = {task1, task2}

            ' Create a cleanup task that will call CompleteAdding after
            ' all producers are done adding items.
            Dim cleanup As Task = Task.Factory.ContinueWhenAll(producers, Sub(p) collection.CompleteAdding())

            ' Queue the Consumer thread. Put this call
            ' before Parallel.Invoke to begin consuming as soon as
            ' the producers add items.
            Task.Factory.StartNew(Sub() RunConsumer())

            ' Keep the console window open while the
            ' consumer thread completes its output.
            Console.ReadKey()

        End Sub

        Shared Sub RunProducer(ByVal ID As String, ByVal start As Integer)
            Dim additions As Integer = 0

            For i As Integer = start To start + itemsToProduce - 1

                ' The data that is added to the collection.
                Dim ticks As Long = sw.ElapsedTicks

                'Display additions and subtractions.
                Console.WriteLine("{0} adding tick value {1}. item# {2}", ID, ticks, i)

                ' Don't try to add item after CompleteAdding
                ' has been called.
                If collection.IsAddingCompleted = False Then
                    collection.Add(ticks)
                End If

                ' Counter for demonstration purposes only.
                additions = additions + 1

                ' Uncomment this line to 
                ' slow down the producer threads without sleeping.
                Thread.SpinWait(100000)

            Next
            Interlocked.Add(totalAdditions, additions)
            Console.WriteLine("{0} is done adding: {1} items", ID, additions)

        End Sub

        Shared Sub RunConsumer()
            ' GetConsumingEnumerable returns the enumerator for the 
            ' underlying collection.
            Dim subtractions As Integer = 0

            For Each item In collection.GetConsumingEnumerable

                subtractions = subtractions + 1
                Console.WriteLine("Consuming tick value {0} : item# {1} : current count = {2}",
                                  item.ToString("D18"), subtractions, collection.Count)
            Next

            Console.WriteLine("Total added: {0} Total consumed: {1} Current count: {2} ",
                                    totalAdditions, subtractions, collection.Count())
            sw.Stop()

            Console.WriteLine("Press any key to exit.")
        End Sub

    End Class
End Module
'</snippet03>
