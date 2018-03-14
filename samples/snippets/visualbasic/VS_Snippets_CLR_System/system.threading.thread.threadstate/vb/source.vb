' <Snippet1>
Imports System.Threading

Public Module Example
    Public Sub Main()
        Dim newThread As Thread = New Thread(AddressOf ThreadMethod)

        Console.WriteLine("ThreadState: {0}", newThread.ThreadState)
        newThread.Start()

        ' Wait for newThread to start and go to sleep.
        Thread.Sleep(300)
        Console.WriteLine("ThreadState: {0}", newThread.ThreadState)

        ' Wait for newThread to restart.
        Thread.Sleep(1000)
        Console.WriteLine("ThreadState: {0}", newThread.ThreadState)
    End Sub

    Sub ThreadMethod()
        Thread.Sleep(1000)
    End Sub
End Module
' The example displays the following output:
'       ThreadState: Unstarted
'       ThreadState: WaitSleepJoin
'       ThreadState: Stopped
' </Snippet1>