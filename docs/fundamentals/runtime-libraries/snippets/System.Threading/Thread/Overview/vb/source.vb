' <Snippet1>
Imports System.Threading

' Simple threading scenario:  Start a Shared method running
' on a second thread.
Public Class ThreadExample
    ' The ThreadProc method is called when the thread starts.
    ' It loops ten times, writing to the console and yielding 
    ' the rest of its time slice each time, and then ends.
    Public Shared Sub ThreadProc()
        Dim i As Integer
        For i = 0 To 9
            Console.WriteLine("ThreadProc: {0}", i)
            ' Yield the rest of the time slice.
            Thread.Sleep(0)
        Next
    End Sub

    Public Shared Sub Main()
        Console.WriteLine("Main thread: Start a second thread.")
        ' The constructor for the Thread class requires a ThreadStart 
        ' delegate.  The Visual Basic AddressOf operator creates this
        ' delegate for you.
        Dim t As New Thread(AddressOf ThreadProc)

        ' Start ThreadProc.  Note that on a uniprocessor, the new 
        ' thread does not get any processor time until the main thread 
        ' is preempted or yields.  Uncomment the Thread.Sleep that 
        ' follows t.Start() to see the difference.
        t.Start()
        'Thread.Sleep(0)

        Dim i As Integer
        For i = 1 To 4
            Console.WriteLine("Main thread: Do some work.")
            Thread.Sleep(0)
        Next

        Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.")
        t.Join()
        Console.WriteLine("Main thread: ThreadProc.Join has returned.  Press Enter to end program.")
        Console.ReadLine()
    End Sub
End Class
' </Snippet1>
