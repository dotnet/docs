' <snippet3>
Imports System
Imports System.Threading

' TaskInfo contains data that will be passed to the callback
' method.
Public Class TaskInfo
    public Handle As RegisteredWaitHandle = Nothing
    public OtherInfo As String = "default"
End Class

Public Class Example
    Public Shared Sub Main()
        ' The main thread uses AutoResetEvent to signal the
        ' registered wait handle, which executes the callback
        ' method.
        Dim ev As New AutoResetEvent(false)

        Dim ti As New TaskInfo()
        ti.OtherInfo = "First task"
        ' The TaskInfo for the task includes the registered wait
        ' handle returned by RegisterWaitForSingleObject.  This
        ' allows the wait to be terminated when the object has
        ' been signaled once (see WaitProc).
        ti.Handle = ThreadPool.RegisterWaitForSingleObject( _
            ev, _
            New WaitOrTimerCallback(AddressOf WaitProc), _
            ti, _
            1000, _
            false _
        )

        ' The main thread waits about three seconds, to demonstrate 
        ' the time-outs on the queued task, and then signals.
        Thread.Sleep(3100)
        Console.WriteLine("Main thread signals.")
        ev.Set()

        ' The main thread sleeps, which should give the callback
        ' method time to execute.  If you comment out this line, the
        ' program usually ends before the ThreadPool thread can execute.
        Thread.Sleep(1000)
        ' If you start a thread yourself, you can wait for it to end
        ' by calling Thread.Join.  This option is not available with 
        ' thread pool threads.
    End Sub
   
    ' The callback method executes when the registered wait times out,
    ' or when the WaitHandle (in this case AutoResetEvent) is signaled.
    ' WaitProc unregisters the WaitHandle the first time the event is 
    ' signaled.
    Public Shared Sub WaitProc(state As Object, timedOut As Boolean)
        ' The state object must be cast to the correct type, because the
        ' signature of the WaitOrTimerCallback delegate specifies type
        ' Object.
        Dim ti As TaskInfo = CType(state, TaskInfo)

        Dim cause As String = "TIMED OUT"
        If Not timedOut Then
            cause = "SIGNALED"
            ' If the callback method executes because the WaitHandle is
            ' signaled, stop future execution of the callback method
            ' by unregistering the WaitHandle.
            If Not ti.Handle Is Nothing Then
                ti.Handle.Unregister(Nothing)
            End If
        End If 

        Console.WriteLine("WaitProc( {0} ) executes on thread {1}; cause = {2}.", _
            ti.OtherInfo, _
            Thread.CurrentThread.GetHashCode().ToString(), _
            cause _
        )
    End Sub
End Class
' </snippet3>
