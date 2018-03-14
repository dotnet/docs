'<Snippet1>
Imports System
Imports System.Threading

Public Class Example

    ' The EventWaitHandle used to demonstrate the difference
    ' between AutoReset and ManualReset synchronization events.
    '
    Private Shared ewh As EventWaitHandle

    ' A counter to make sure all threads are started and
    ' blocked before any are released. A Long is used to show
    ' the use of the 64-bit Interlocked methods.
    '
    Private Shared threadCount As Long = 0

    ' An AutoReset event that allows the main thread to block
    ' until an exiting thread has decremented the count.
    '
    Private Shared clearCount As New EventWaitHandle(False, _
        EventResetMode.AutoReset)

    <MTAThread> _
    Public Shared Sub Main()

        ' Create an AutoReset EventWaitHandle.
        '
        ewh = New EventWaitHandle(False, EventResetMode.AutoReset)

        ' Create and start five numbered threads. Use the
        ' ParameterizedThreadStart delegate, so the thread
        ' number can be passed as an argument to the Start 
        ' method.
        For i As Integer = 0 To 4
            Dim t As New Thread(AddressOf ThreadProc)
            t.Start(i)
        Next i

        ' Wait until all the threads have started and blocked.
        ' When multiple threads use a 64-bit value on a 32-bit
        ' system, you must access the value through the
        ' Interlocked class to guarantee thread safety.
        '
        While Interlocked.Read(threadCount) < 5
            Thread.Sleep(500)
        End While

        ' Release one thread each time the user presses ENTER,
        ' until all threads have been released.
        '
        While Interlocked.Read(threadCount) > 0
            Console.WriteLine("Press ENTER to release a waiting thread.")
            Console.ReadLine()

            ' SignalAndWait signals the EventWaitHandle, which
            ' releases exactly one thread before resetting, 
            ' because it was created with AutoReset mode. 
            ' SignalAndWait then blocks on clearCount, to 
            ' allow the signaled thread to decrement the count
            ' before looping again.
            '
            WaitHandle.SignalAndWait(ewh, clearCount)
        End While
        Console.WriteLine()

        ' Create a ManualReset EventWaitHandle.
        '
        ewh = New EventWaitHandle(False, EventResetMode.ManualReset)

        ' Create and start five more numbered threads.
        '
        For i As Integer = 0 To 4
            Dim t As New Thread(AddressOf ThreadProc)
            t.Start(i)
        Next i

        ' Wait until all the threads have started and blocked.
        '
        While Interlocked.Read(threadCount) < 5
            Thread.Sleep(500)
        End While

        ' Because the EventWaitHandle was created with
        ' ManualReset mode, signaling it releases all the
        ' waiting threads.
        '
        Console.WriteLine("Press ENTER to release the waiting threads.")
        Console.ReadLine()
        ewh.Set()
        
    End Sub

    Public Shared Sub ThreadProc(ByVal data As Object)
        Dim index As Integer = CInt(data)

        Console.WriteLine("Thread {0} blocks.", data)
        ' Increment the count of blocked threads.
        Interlocked.Increment(threadCount)

        ' Wait on the EventWaitHandle.
        ewh.WaitOne()

        Console.WriteLine("Thread {0} exits.", data)
        ' Decrement the count of blocked threads.
        Interlocked.Decrement(threadCount)

        ' After signaling ewh, the main thread blocks on
        ' clearCount until the signaled thread has 
        ' decremented the count. Signal it now.
        '
        clearCount.Set()
    End Sub
End Class
'</Snippet1>
