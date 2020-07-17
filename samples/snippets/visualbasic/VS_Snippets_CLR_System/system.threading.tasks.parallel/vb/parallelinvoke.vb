'<snippet01>
Imports System.Threading
Imports System.Threading.Tasks

Module InvokeDemo

    ' Demonstrated features:
    '   Parallel.Invoke()
    ' Expected results:
    '   The threads on which each task gets executed may be different.
    '   The thread assignments may be different in different executions.
    '   The tasks may get executed in any order.
    ' Documentation:
    '   http://msdn.microsoft.com/library/dd783942(VS.100).aspx
    Private Sub Main()
        Try
            ' Param #0 - static method
            Parallel.Invoke(AddressOf BasicAction,
                            Sub()
                                ' Param #1 - lambda expression
                                Console.WriteLine("Method=beta, Thread={0}", Thread.CurrentThread.ManagedThreadId)
                            End Sub,
                            Sub()
                                ' Param #2 - in-line delegate
                                Console.WriteLine("Method=gamma, Thread={0}", Thread.CurrentThread.ManagedThreadId)
                            End Sub)
        Catch e As AggregateException
            ' No exception is expected in this example, but if one is still thrown from a task,
            ' it will be wrapped in AggregateException and propagated to the main thread.
            Console.WriteLine("An action has thrown an exception. THIS WAS UNEXPECTED." & vbLf & "{0}", e.InnerException.ToString())
        End Try
    End Sub

    Private Sub BasicAction()
        Console.WriteLine("Method=alpha, Thread={0}", Thread.CurrentThread.ManagedThreadId)
    End Sub



End Module
'</snippet01>
