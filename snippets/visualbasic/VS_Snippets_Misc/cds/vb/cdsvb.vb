Imports System
Imports System.Collections.Concurrent
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks

Module Module1
    Sub Main()

    End Sub

    '<snippet01>

    Class Program

        ' Limit the collection size to 2000 items
        ' at any given time.
        Const upperLimit As Integer = 2000

        Shared collection As New BlockingCollection(Of Long)(upperLimit)

        ' Variables for diagnostic output only.
        Shared sw As New Stopwatch()
        Shared additions As Integer = 0
        Shared subtractions As Integer = 0


        Private Shared Sub Main(ByVal args As String())

            ' Start the stopwatch.
            sw.Start()

            ' Queue the ProduceData thread.
            ThreadPool.QueueUserWorkItem(New WaitCallback(Sub(RunProducer)

                                                          End Sub))
            ' Queue the ConsumeData thread.
            ThreadPool.QueueUserWorkItem(New WaitCallback(Sub(RunConsumer)

                                                          End Sub))
            ' ThreadPool.QueueUserWorkItem(New WaitCallback(Sub(RunConsumer2)
            ' End Sub))

            ' Keep the console window open while the
            ' consumer thread completes its output.

            Console.ReadKey()
        End Sub

        Private Shared Sub RunProducer()

            For i As Integer = 0 To 99

                Dim ticks As Long = sw.ElapsedTicks

                ' Uncomment this line to see interleaved additions and subtractions.
                Console.WriteLine("adding tick value {0}. item# {1}", ticks, additions)

                collection.Add(ticks)


                ' Counter for demonstration purposes only.

                ' For demonstration purposes, uncomment this line to 
                ' slow down the producer thread without sleeping.

                ' Thread.SpinWait(100000); 


                additions += 1
            Next

            ' Important!!! Tell consumers that no more items will be added.
            collection.CompleteAdding()

            Console.WriteLine("Done adding: {0} items", additions)
        End Sub


        Private Shared Sub RunConsumer()
            ' GetConsumingEnumerable returns the enumerator for the 
            ' underlying collection.
            For Each item In collection.GetConsumingEnumerable()
                Console.WriteLine("Consuming tick value {0} : item# {1} ", item.ToString("D18"), System.Math.Max(System.Threading.Interlocked.Increment(subtractions), subtractions - 1))
            Next

            Console.WriteLine("Total added: {0} Total consumed: {1} Current count: {2} ", additions, subtractions, collection.Count())
            sw.[Stop]()

            Console.WriteLine("Press any key to exit")
        End Sub

        '<snippet02>
        Private Shared Sub RunConsumer2()
            ' Count may be zero while still waiting for more items.
            ' IsCompleted may be true while Count is still > 0.
            ' Therefore, iterate as long as either condition is true.
            While collection.IsCompleted = False OrElse collection.Count > 0
                Dim ticks As Long = 0
                Dim b As Boolean = collection.TryTake(ticks, 30)
                If b = True Then
                    Console.WriteLine("Consuming {0} : {1} ", ticks.ToString("D18"), System.Math.Max(System.Threading.Interlocked.Increment(subtractions), subtractions - 1))
                Else
                    ' Do something else useful before trying again.
                    Console.WriteLine("Doing something useful here")
                End If
            End While

            Console.WriteLine("Total added: {0} Total consumed: {1} Current count: {2} ", additions, subtractions, collection.Count)
        End Sub
        '</snippet02>
    End Class
    '</snippet01>



    '<snippet08>

    Class MyBarrier
        Const Partitions As Integer = 3

        Shared data As Byte()() = New Byte(Partitions - 1)() {}
        Shared results As Double() = New Double(Partitions - 1) {}

        Private Shared Sub Main()
            ' Create a new barrier, specifying a participant count and a 
            ' delegate to invoke when the first phase is complete. 
            Dim b As New Barrier(Partitions)

            Dim tasks As Task() = New Task(Partitions - 1) {}
            For i As Integer = 0 To Partitions - 1
                ' Declare a variable that captures
                ' changing value of i on each iteration.
                Dim index As Integer = i

            tasks(i) = Task.Run(Sub()

                                   ' Fill each buffer, then wait.
                                   GenerateDataForMyPartition(index)
                                   b.SignalAndWait()

                                   ' Compare results from all
                                   ComputeForMyPartition(index)

                                   b.SignalAndWait()
                                End Sub)
        Next

        Console.WriteLine("Press a key to exit")
        Console.ReadKey()
    End Sub

        ' Toy implementation to generate some data.
        Private Shared Sub GenerateDataForMyPartition(ByVal taskNumber As Integer)
            data(taskNumber) = New Byte(99) {}
            Dim rand = New Random()
            rand.NextBytes(data(taskNumber))

            Console.WriteLine("Generate for {0}", taskNumber)
            Dim total As Integer = 0
            For Each b In data(taskNumber)
                total += b
            Next
            results(taskNumber) = CDbl((CDbl(total) / data(taskNumber).Length))


            Console.WriteLine("results[{0}] = {1}", taskNumber, results(taskNumber))
        End Sub




        ' In this example, we simply take the average and compare it to other partitions.
        ' In a real-world application, this would be a more computationally expensive
        ' operation.
        Private Shared Sub ComputeForMyPartition(ByVal index As Integer)
            Dim myAverage As Double = results(index)
            Dim sb = New StringBuilder()
            sb.AppendFormat("results for buffer[{0}]:" & vbLf, index)
            For i As Integer = 0 To results.Length - 1
                If i = index Then
                    Continue For
                End If
                ' Don't compare to myself.
                Dim them = results(i)
                Dim diff = Math.Abs(them - myAverage)

                If myAverage > them Then
                    sb.AppendFormat(" greater than buffer[{0}] by {1}" & vbLf, i, diff)
                ElseIf myAverage = them Then
                    sb.AppendFormat(" equal to buffer[{0}]" & vbLf, i, diff)
                ElseIf myAverage < them Then
                    sb.AppendFormat(" less than buffer[{0}] by {1}" & vbLf, i, diff)
                End If
            Next

            Console.WriteLine(sb.ToString())
        End Sub
    End Class
    '</snippet08>
End Module
