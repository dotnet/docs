' <Snippet1>
Imports System.Threading

Public Class Example

    ' mre is used to block and release threads manually. It is
    ' created in the unsignaled state.
    Private Shared mre As New ManualResetEvent(False)

    <MTAThreadAttribute> _
    Shared Sub Main()

        Console.WriteLine(vbLf & _
            "Start 3 named threads that block on a ManualResetEvent:" & vbLf)

        For i As Integer = 0 To 2
            Dim t As New Thread(AddressOf ThreadProc)
            t.Name = "Thread_" & i
            t.Start()
        Next i

        Thread.Sleep(500)
        Console.WriteLine(vbLf & _
            "When all three threads have started, press Enter to call Set()" & vbLf & _
            "to release all the threads." & vbLf)
        Console.ReadLine()

        mre.Set()

        Thread.Sleep(500)
        Console.WriteLine(vbLf & _
            "When a ManualResetEvent is signaled, threads that call WaitOne()" & vbLf & _
            "do not block. Press Enter to show this." & vbLf)
        Console.ReadLine()

        For i As Integer = 3 To 4
            Dim t As New Thread(AddressOf ThreadProc)
            t.Name = "Thread_" & i
            t.Start()
        Next i

        Thread.Sleep(500)
        Console.WriteLine(vbLf & _
            "Press Enter to call Reset(), so that threads once again block" & vbLf & _
            "when they call WaitOne()." & vbLf)
        Console.ReadLine()

        mre.Reset()

        ' Start a thread that waits on the ManualResetEvent.
        Dim t5 As New Thread(AddressOf ThreadProc)
        t5.Name = "Thread_5"
        t5.Start()

        Thread.Sleep(500)
        Console.WriteLine(vbLf & "Press Enter to call Set() and conclude the demo.")
        Console.ReadLine()

        mre.Set()

        ' If you run this example in Visual Studio, uncomment the following line:
        'Console.ReadLine()

    End Sub


    Private Shared Sub ThreadProc()

        Dim name As String = Thread.CurrentThread.Name

        Console.WriteLine(name & " starts and calls mre.WaitOne()")

        mre.WaitOne()

        Console.WriteLine(name & " ends.")

    End Sub

End Class

' This example produces output similar to the following:
'
'Start 3 named threads that block on a ManualResetEvent:
'
'Thread_0 starts and calls mre.WaitOne()
'Thread_1 starts and calls mre.WaitOne()
'Thread_2 starts and calls mre.WaitOne()
'
'When all three threads have started, press Enter to call Set()
'to release all the threads.
'
'
'Thread_2 ends.
'Thread_0 ends.
'Thread_1 ends.
'
'When a ManualResetEvent is signaled, threads that call WaitOne()
'do not block. Press Enter to show this.
'
'
'Thread_3 starts and calls mre.WaitOne()
'Thread_3 ends.
'Thread_4 starts and calls mre.WaitOne()
'Thread_4 ends.
'
'Press Enter to call Reset(), so that threads once again block
'when they call WaitOne().
'
'
'Thread_5 starts and calls mre.WaitOne()
'
'Press Enter to call Set() and conclude the demo.
'
'Thread_5 ends.
' </Snippet1>