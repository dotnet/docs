'<snippet02>
Imports System.Threading
Imports System.Threading.Tasks
Module ForEachDemo

    ' Demonstrated features:
    '   Parallel.ForEach()
    '   Thread-local state
    ' Expected results:
    '   This example sums up the elements of an int[] in parallel.
    '   Each thread maintains a local sum. When a thread is initialized, that local sum is set to 0.
    '   On every iteration the current element is added to the local sum.
    '   When a thread is done, it safely adds its local sum to the global sum.
    '   After the loop is complete, the global sum is printed out.
    ' Documentation:
    '   http://msdn.microsoft.com/en-us/library/dd990270(VS.100).aspx
    Private Sub ForEachDemo()
        ' The sum of these elements is 40.
        Dim input As Integer() = {4, 1, 6, 2, 9, 5, _
        10, 3}
        Dim sum As Integer = 0

        Try
            ' source collection
            Parallel.ForEach(input,
                             Function()
                                 ' thread local initializer
                                 Return 0
                             End Function,
                             Function(n, loopState, localSum)
                                 ' body
                                 localSum += n
                                 Console.WriteLine("Thread={0}, n={1}, localSum={2}", Thread.CurrentThread.ManagedThreadId, n, localSum)
                                 Return localSum
                             End Function,
                             Sub(localSum)
                                 ' thread local aggregator
                                 Interlocked.Add(sum, localSum)
                             End Sub)

            Console.WriteLine(vbLf & "Sum={0}", sum)
        Catch e As AggregateException
            ' No exception is expected in this example, but if one is still thrown from a task,
            ' it will be wrapped in AggregateException and propagated to the main thread.
            Console.WriteLine("Parallel.ForEach has thrown an exception. THIS WAS NOT EXPECTED." & vbLf & "{0}", e)
        End Try
    End Sub


End Module
'</snippet02>