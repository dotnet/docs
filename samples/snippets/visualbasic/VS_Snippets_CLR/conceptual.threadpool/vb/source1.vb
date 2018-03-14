' <snippet1>
Imports System
Imports System.Threading

Public Class Example
    Public Shared Sub Main()
        ' Queue the task.
        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf ThreadProc))

        Console.WriteLine("Main thread does some work, then sleeps.")
        ' If you comment out the Sleep, the main thread exits before
        ' the thread pool task runs.  The thread pool uses background
        ' threads, which do not keep the application running.  (This
        ' is a simple example of a race condition.)
        Thread.Sleep(1000)

        Console.WriteLine("Main thread exits.")
    End Sub

    ' This thread procedure performs the task.
    Shared Sub ThreadProc(stateInfo As Object)
        ' No state object was passed to QueueUserWorkItem, so
        ' stateInfo is null.
        Console.WriteLine("Hello from the thread pool.")
    End Sub
End Class
' </snippet1>
