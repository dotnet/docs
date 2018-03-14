'<snippet02>
' How to: Stop or Break from a Parallel.For Loop
Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks

Module ParallelForStop
    Sub Main()
        StopLoop()
        BreakAtThreshold()

        Console.WriteLine("Press any key to exit.")
        Console.ReadKey()
    End Sub

    Sub StopLoop()
        Console.WriteLine("Stop loop...")
        Dim source As Double() = MakeDemoSource(1000, 1)
        Dim results As New ConcurrentStack(Of Double)()

        ' i is the iteration variable. loopState is a 
        ' compiler-generated ParallelLoopState
        Parallel.For(0, source.Length, Sub(i, loopState)
                                           ' Take the first 100 values that are retrieved
                                           ' from anywhere in the source.
                                           If i < 100 Then
                                               ' Accessing shared object on each iteration
                                               ' is not efficient. See remarks.
                                               Dim d As Double = Compute(source(i))
                                               results.Push(d)
                                           Else
                                               loopState.[Stop]()
                                               Exit Sub

                                           End If
                                           ' Close lambda expression.
                                       End Sub)
        ' Close Parallel.For
        Console.WriteLine("Results contains {0} elements", results.Count())
    End Sub


    Sub BreakAtThreshold()
        Dim source As Double() = MakeDemoSource(10000, 1.0002)
        Dim results As New ConcurrentStack(Of Double)()

        ' Store all values below a specified threshold.
        Parallel.For(0, source.Length, Function(i, loopState)
                                           Dim d As Double = Compute(source(i))
                                           results.Push(d)
                                           If d > 0.2 Then
                                               ' Might be called more than once!
                                               loopState.Break()
                                               Console.WriteLine("Break called at iteration {0}. d = {1} ", i, d)
                                               Thread.Sleep(1000)
                                           End If
                                           Return d
                                       End Function)

        Console.WriteLine("results contains {0} elements", results.Count())
    End Sub

    Function Compute(ByVal d As Double) As Double
        'Make the processor work just a little bit.
        Return Math.Sqrt(d)
    End Function


    ' Create a contrived array of monotonically increasing
    ' values for demonstration purposes. 
    Function MakeDemoSource(ByVal size As Integer, ByVal valToFind As Double) As Double()
        Dim result As Double() = New Double(size - 1) {}
        Dim initialval As Double = 0.01
        For i As Integer = 0 To size - 1
            initialval *= valToFind
            result(i) = initialval
        Next
        Return result
    End Function
End Module
'</snippet02>