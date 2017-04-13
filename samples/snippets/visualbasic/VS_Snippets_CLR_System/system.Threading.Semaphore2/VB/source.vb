'<Snippet1>
Imports System
Imports System.Threading

Public Class Example

    ' A semaphore that simulates a limited resource pool.
    '
    Private Shared _pool As Semaphore

    ' A padding interval to make the output more orderly.
    Private Shared _padding As Integer

    <MTAThread> _
    Public Shared Sub Main()
        ' Create a semaphore that can satisfy up to three
        ' concurrent requests. Use an initial count of zero,
        ' so that the entire semaphore count is initially
        ' owned by the main program thread.
        '
        _pool = New Semaphore(0, 3)

        ' Create and start five numbered threads. 
        '
        For i As Integer = 1 To 5
            Dim t As New Thread(New ParameterizedThreadStart(AddressOf Worker))
            'Dim t As New Thread(AddressOf Worker)

            ' Start the thread, passing the number.
            '
            t.Start(i)
        Next i

        ' Wait for half a second, to allow all the
        ' threads to start and to block on the semaphore.
        '
        Thread.Sleep(500)

        ' The main thread starts out holding the entire
        ' semaphore count. Calling Release(3) brings the 
        ' semaphore count back to its maximum value, and
        ' allows the waiting threads to enter the semaphore,
        ' up to three at a time.
        '
        Console.WriteLine("Main thread calls Release(3).")
        _pool.Release(3)

        Console.WriteLine("Main thread exits.")
    End Sub

    Private Shared Sub Worker(ByVal num As Object)
        ' Each worker thread begins by requesting the
        ' semaphore.
        Console.WriteLine("Thread {0} begins " _
            & "and waits for the semaphore.", num)
        _pool.WaitOne()

        ' A padding interval to make the output more orderly.
        Dim padding As Integer = Interlocked.Add(_padding, 100)

        Console.WriteLine("Thread {0} enters the semaphore.", num)
        
        ' The thread's "work" consists of sleeping for 
        ' about a second. Each thread "works" a little 
        ' longer, just to make the output more orderly.
        '
        Thread.Sleep(1000 + padding)

        Console.WriteLine("Thread {0} releases the semaphore.", num)
        Console.WriteLine("Thread {0} previous semaphore count: {1}", _
            num, _
            _pool.Release())
    End Sub
End Class
'</Snippet1>
