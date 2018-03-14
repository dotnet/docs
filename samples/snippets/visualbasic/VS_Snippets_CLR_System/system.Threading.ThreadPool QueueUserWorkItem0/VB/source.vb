' <Snippet1>
Imports System.Threading

Public Module Example
    Public Sub Main()
        ' Queue the work for execution.
        ThreadPool.QueueUserWorkItem(AddressOf ThreadProc)
        
        Console.WriteLine("Main thread does some work, then sleeps.")

        Thread.Sleep(1000)

        Console.WriteLine("Main thread exits.")
    End Sub

    ' This thread procedure performs the task.
    Sub ThreadProc(stateInfo As Object)
        ' No state object was passed to QueueUserWorkItem, so stateInfo is null.
        Console.WriteLine("Hello from the thread pool.")
    End Sub
End Module
' The example displays output like the following:
'       Main thread does some work, then sleeps.
'       Hello from the thread pool.
'       Main thread exits.
' </Snippet1>
