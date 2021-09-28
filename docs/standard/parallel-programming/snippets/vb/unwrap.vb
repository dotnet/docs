Imports System.Threading

Module UnwrapExample
    Sub Main()
        Dim taskOne As Task(Of Integer) = RemoteIncrement(0)
        Console.WriteLine("Started RemoteIncrement(0)")

        Dim taskTwo As Task(Of Integer) = RemoteIncrement(4).
            ContinueWith(Function(t) RemoteIncrement(t.Result)).
            Unwrap().ContinueWith(Function(t) RemoteIncrement(t.Result)).
            Unwrap().ContinueWith(Function(t) RemoteIncrement(t.Result)).
            Unwrap()

        Console.WriteLine("Started RemoteIncrement(...(RemoteIncrement(RemoteIncrement(4))...)")

        Try
            taskOne.Wait()
            Console.WriteLine("Finished RemoteIncrement(0)")

            taskTwo.Wait()
            Console.WriteLine("Finished RemoteIncrement(...(RemoteIncrement(RemoteIncrement(4))...)")
        Catch e As AggregateException
            Console.WriteLine($"A task has thrown the following (unexpected) exception:{vbLf}{e}")
        End Try
    End Sub

    Function RemoteIncrement(ByVal number As Integer) As Task(Of Integer)
        Return Task(Of Integer).Factory.StartNew(
            Function(obj)
                Thread.Sleep(1000)

                Dim x As Integer = CInt(obj)
                Console.WriteLine("Thread={0}, Next={1}", Thread.CurrentThread.ManagedThreadId, Interlocked.Increment(x))
                Return x
            End Function, number)
    End Function
End Module

' The example displays the similar output:
'     Started RemoteIncrement(0)
'     Started RemoteIncrement(...(RemoteIncrement(RemoteIncrement(4))...)
'     Thread=4, Next=1
'     Finished RemoteIncrement(0)
'     Thread=5, Next=5
'     Thread=6, Next=6
'     Thread=6, Next=7
'     Thread=6, Next=8
'     Finished RemoteIncrement(...(RemoteIncrement(RemoteIncrement(4))...)
