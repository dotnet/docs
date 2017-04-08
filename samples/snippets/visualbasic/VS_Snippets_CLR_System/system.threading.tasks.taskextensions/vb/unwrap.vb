'<snippet01>
Imports System.Threading
Imports System.Threading.Tasks

Module UnwrapDemo
    ' Demonstrated features:
    '   Task.Unwrap()
    '    Task.Factory.StartNew()
    '   Task.ContinueWith()
    ' Expected results:
    ' 	Indicates that continuation chains can be set up virtually instantaneously using Unwrap(), and then left to run on their own.
    '   The results of the RemoteIncrement(0) chain and the RemoteIncrement(4) chain may be intermixed with each other.
    '   The results of the sequence that starts with RemoteIncrement(4) are in strict order.
    ' Documentation:
    '   http://msdn.microsoft.com/en-us/library/dd781129(VS.100).aspx
    ' More information:
    '   http://blogs.msdn.com/pfxteam/archive/2009/11/04/9917581.aspx
    ' Other notes:
    '   The combination of Task<T>, ContinueWith() and Unwrap() can be particularly useful for setting up a chain of long-running
    '   tasks where each task uses the results of its predecessor.

    Sub Main()
        ' Invoking individual tasks is straightforward
        Dim t1 As Task(Of Integer) = RemoteIncrement(0)
        Console.WriteLine("Started RemoteIncrement(0)")

        ' Chain together the results of (simulated) remote operations.
        ' The use of Unwrap() instead of .Result below prevents this thread from blocking while setting up this continuation chain.
        ' RemoteIncrement() returns Task<int> so no unwrapping is needed for the first continuation.
        ' ContinueWith() here returns Task<Task<int>>. Therefore unwrapping is needed.
        ' and on it goes...
        Dim t2 As Task(Of Integer) = RemoteIncrement(4).ContinueWith(Function(t) RemoteIncrement(t.Result)).Unwrap().ContinueWith(Function(t) RemoteIncrement(t.Result)).Unwrap().ContinueWith(Function(t) RemoteIncrement(t.Result)).Unwrap()
        Console.WriteLine("Started RemoteIncrement(...(RemoteIncrement(RemoteIncrement(4))...)")

        Try
            t1.Wait()
            Console.WriteLine("Finished RemoteIncrement(0)" & vbLf)

            t2.Wait()
            Console.WriteLine("Finished RemoteIncrement(...(RemoteIncrement(RemoteIncrement(4))...)")
        Catch e As AggregateException
            Console.WriteLine("A task has thrown the following (unexpected) exception:" & vbLf & "{0}", e)

        End Try
    End Sub

    ' This method represents a remote API.
    Function RemoteIncrement(ByVal n As Integer) As Task(Of Integer)
        Return Task(Of Integer).Factory.StartNew(Function(obj)
                                                     ' Simulate a slow operation
                                                     Thread.Sleep(1 * 1000)

                                                     Dim x As Integer = CInt(obj)
                                                     Console.WriteLine("Thread={0}, Next={1}", Thread.CurrentThread.ManagedThreadId, System.Threading.Interlocked.Increment(x))
                                                     Return x
                                                 End Function, n)
    End Function


End Module
'</snippet01>