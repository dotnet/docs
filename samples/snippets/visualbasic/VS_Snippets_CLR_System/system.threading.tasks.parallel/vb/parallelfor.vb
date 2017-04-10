'<snippet03>
Imports System.Threading
Imports System.Threading.Tasks


Module ParallelForDemo

    ' Demonstrated features:
    '   Parallel.For()
    '   ParallelOptions
    ' Expected results:
    '   An iteration for each argument value (0, 1, 2, 3, 4, 5, 6, 7, 8, 9) is executed.
    '   The order of execution of the iterations is undefined.
    '   Verify that no more than two threads have been used for the iterations.
    ' Documentation:
    '   http://msdn.microsoft.com/en-us/library/system.threading.tasks.parallel.for(VS.100).aspx
    Sub Main()
        Dim options As New ParallelOptions()
        options.MaxDegreeOfParallelism = 2 ' -1 is for unlimited. 1 is for sequential.
        Try
            Parallel.For(0, 9, options, Sub(i)
                                            Console.WriteLine("Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i)

                                        End Sub)
        Catch e As AggregateException
            ' No exception is expected in this example, but if one is still thrown from a task,
            ' it will be wrapped in AggregateException and propagated to the main thread.
            Console.WriteLine("Parallel.For has thrown the following (unexpected) exception:" & vbLf & "{0}", e)
        End Try
    End Sub

End Module
'</snippet03>