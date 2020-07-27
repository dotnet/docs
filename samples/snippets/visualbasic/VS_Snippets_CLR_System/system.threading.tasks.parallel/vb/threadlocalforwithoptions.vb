'<snippet04>
Imports System.Threading
Imports System.Threading.Tasks

Module ThreadLocalForWithOptions

    ' The number of parallel iterations to perform.
    Const N As Integer = 1000000

    Sub Main()
        ' The result of all thread-local computations.
        Dim result As Integer = 0

        ' This example limits the degree of parallelism to four.
        ' You might limit the degree of parallelism when your algorithm
        ' does not scale beyond a certain number of cores or when you 
        ' enforce a particular quality of service in your application.

        Parallel.For(0, N, New ParallelOptions With {.MaxDegreeOfParallelism = 4},
           Function()
             ' Initialize the local states 
             Return 0
           End Function,
           Function(i, loopState, localState)
             ' Accumulate the thread-local computations in the loop body
             Return localState + Compute(i)
           End Function,
           Sub(localState)
             ' Combine all local states
             Interlocked.Add(result, localState)
           End Sub
        )

        ' Print the actual and expected results.
        Console.WriteLine("Actual result: {0}. Expected 1000000.", result)
    End Sub

    ' Simulates a lengthy operation.
    Function Compute(ByVal n As Integer) As Integer
        For i As Integer = 0 To 10000
        Next
        Return 1
    End Function
End Module
'</snippet04>
