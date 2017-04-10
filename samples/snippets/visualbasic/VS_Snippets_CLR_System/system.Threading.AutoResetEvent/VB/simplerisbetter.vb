'<Snippet3>
Imports System.Threading

' Visual Studio: Replace the default class in a Console project with 
'                the following class.
Class Example

    Private Shared event_1 As New AutoResetEvent(True)
    Private Shared event_2 As New AutoResetEvent(False)

    <MTAThread()> _
    Shared Sub Main()
    
        Console.WriteLine("Press Enter to create three threads and start them." & vbCrLf & _
                          "The threads wait on AutoResetEvent #1, which was created" & vbCrLf & _
                          "in the signaled state, so the first thread is released." & vbCrLf & _
                          "This puts AutoResetEvent #1 into the unsignaled state.")
        Console.ReadLine()
            
        For i As Integer = 1 To 3
            Dim t As New Thread(AddressOf ThreadProc)
            t.Name = "Thread_" & i
            t.Start()
        Next
        Thread.Sleep(250)

        For i As Integer = 1 To 2
            Console.WriteLine("Press Enter to release another thread.")
            Console.ReadLine()

            event_1.Set()
            Thread.Sleep(250)
        Next

        Console.WriteLine(vbCrLf & "All threads are now waiting on AutoResetEvent #2.")
        For i As Integer = 1 To 3
            Console.WriteLine("Press Enter to release a thread.")
            Console.ReadLine()

            event_2.Set()
            Thread.Sleep(250)
        Next

        ' Visual Studio: Uncomment the following line.
        'Console.Readline()
    End Sub

    Shared Sub ThreadProc()
    
        Dim name As String = Thread.CurrentThread.Name

        Console.WriteLine("{0} waits on AutoResetEvent #1.", name)
        event_1.WaitOne()
        Console.WriteLine("{0} is released from AutoResetEvent #1.", name)

        Console.WriteLine("{0} waits on AutoResetEvent #2.", name)
        event_2.WaitOne()
        Console.WriteLine("{0} is released from AutoResetEvent #2.", name)

        Console.WriteLine("{0} ends.", name)
    End Sub
End Class

' This example produces output similar to the following:
'
'Press Enter to create three threads and start them.
'The threads wait on AutoResetEvent #1, which was created
'in the signaled state, so the first thread is released.
'This puts AutoResetEvent #1 into the unsignaled state.
'
'Thread_1 waits on AutoResetEvent #1.
'Thread_1 is released from AutoResetEvent #1.
'Thread_1 waits on AutoResetEvent #2.
'Thread_3 waits on AutoResetEvent #1.
'Thread_2 waits on AutoResetEvent #1.
'Press Enter to release another thread.
'
'Thread_3 is released from AutoResetEvent #1.
'Thread_3 waits on AutoResetEvent #2.
'Press Enter to release another thread.
'
'Thread_2 is released from AutoResetEvent #1.
'Thread_2 waits on AutoResetEvent #2.
'
'All threads are now waiting on AutoResetEvent #2.
'Press Enter to release a thread.
'
'Thread_2 is released from AutoResetEvent #2.
'Thread_2 ends.
'Press Enter to release a thread.
'
'Thread_1 is released from AutoResetEvent #2.
'Thread_1 ends.
'Press Enter to release a thread.
'
'Thread_3 is released from AutoResetEvent #2.
'Thread_3 ends.
'</Snippet3>
