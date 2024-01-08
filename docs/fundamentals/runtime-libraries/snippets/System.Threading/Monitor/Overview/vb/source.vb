' <Snippet1>
Imports System.Threading

Friend Class SyncResource
    ' Use a monitor to enforce synchronization.
    Public Sub Access()
        SyncLock Me
            Console.WriteLine("Starting synchronized resource access on thread #{0}",
                              Thread.CurrentThread.ManagedThreadId)
            If Thread.CurrentThread.ManagedThreadId Mod 2 = 0 Then
                Thread.Sleep(2000)
            End If
            Thread.Sleep(200)
            Console.WriteLine("Stopping synchronized resource access on thread #{0}",
                              Thread.CurrentThread.ManagedThreadId)
        End SyncLock
    End Sub
End Class

Friend Class UnSyncResource
    ' Do not enforce synchronization.
    Public Sub Access()
        Console.WriteLine("Starting unsynchronized resource access on Thread #{0}",
                          Thread.CurrentThread.ManagedThreadId)
        If Thread.CurrentThread.ManagedThreadId Mod 2 = 0 Then
            Thread.Sleep(2000)
        End If
        Thread.Sleep(200)
        Console.WriteLine("Stopping unsynchronized resource access on thread #{0}",
                          Thread.CurrentThread.ManagedThreadId)
    End Sub
End Class

Public Module App
    Private numOps As Integer
    Private opsAreDone As New AutoResetEvent(False)
    Private SyncRes As New SyncResource()
    Private UnSyncRes As New UnSyncResource()

    Public Sub Main()
        ' Set the number of synchronized calls.
        numOps = 5
        For ctr As Integer = 0 To 4
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf SyncUpdateResource))
        Next
        ' Wait until this WaitHandle is signaled.
        opsAreDone.WaitOne()
        Console.WriteLine(vbTab + Environment.NewLine + "All synchronized operations have completed.")
        Console.WriteLine()

        numOps = 5
        ' Reset the count for unsynchronized calls.
        For ctr As Integer = 0 To 4
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf UnSyncUpdateResource))
        Next

        ' Wait until this WaitHandle is signaled.
        opsAreDone.WaitOne()
        Console.WriteLine(vbTab + Environment.NewLine + "All unsynchronized thread operations have completed.")
    End Sub

    Sub SyncUpdateResource()
        ' Call the internal synchronized method.
        SyncRes.Access()

        ' Ensure that only one thread can decrement the counter at a time.
        If Interlocked.Decrement(numOps) = 0 Then
            ' Announce to Main that in fact all thread calls are done.
            opsAreDone.Set()
        End If
    End Sub

    Sub UnSyncUpdateResource()
        ' Call the unsynchronized method.
        UnSyncRes.Access()

        ' Ensure that only one thread can decrement the counter at a time.
        If Interlocked.Decrement(numOps) = 0 Then
            ' Announce to Main that in fact all thread calls are done.
            opsAreDone.Set()
        End If
    End Sub
End Module
' The example displays output like the following:
'    Starting synchronized resource access on thread #6
'    Stopping synchronized resource access on thread #6
'    Starting synchronized resource access on thread #7
'    Stopping synchronized resource access on thread #7
'    Starting synchronized resource access on thread #3
'    Stopping synchronized resource access on thread #3
'    Starting synchronized resource access on thread #4
'    Stopping synchronized resource access on thread #4
'    Starting synchronized resource access on thread #5
'    Stopping synchronized resource access on thread #5
'
'    All synchronized operations have completed.
'
'    Starting unsynchronized resource access on Thread #7
'    Starting unsynchronized resource access on Thread #9
'    Starting unsynchronized resource access on Thread #10
'    Starting unsynchronized resource access on Thread #6
'    Starting unsynchronized resource access on Thread #3
'    Stopping unsynchronized resource access on thread #7
'    Stopping unsynchronized resource access on thread #9
'    Stopping unsynchronized resource access on thread #3
'    Stopping unsynchronized resource access on thread #10
'    Stopping unsynchronized resource access on thread #6
'
'    All unsynchronized thread operations have completed.
' </Snippet1>
