'<snippet01>
Imports System.Threading
Imports System.Threading.Tasks

Module ThreadLocalDemo

    ' Demonstrates:
    ' ThreadLocal(T) constructor
    ' ThreadLocal(T).Value
    ' One usage of ThreadLocal(T)
    Sub Main()
        ' Thread-Local variable that yields a name for a thread
        Dim ThreadName As New ThreadLocal(Of String)(
            Function()
                Return "Thread" & Thread.CurrentThread.ManagedThreadId
            End Function)

        ' Action that prints out ThreadName for the current thread
        Dim action As Action =
            Sub()
                ' If ThreadName.IsValueCreated is true, it means that we are not the
                ' first action to run on this thread.
                Dim repeat As Boolean = ThreadName.IsValueCreated

                Console.WriteLine("ThreadName = {0} {1}", ThreadName.Value, If(repeat, "(repeat)", ""))
            End Sub

        ' Launch eight of them. On 4 cores or less, you should see some repeat ThreadNames
        Parallel.Invoke(action, action, action, action, action, action, action, action)

        ' Dispose when you are done
        ThreadName.Dispose()
    End Sub
End Module
'</snippet01>