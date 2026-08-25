' <Snippet1>
Imports System.Threading

Module Example
    Public Sub Main()
        ' Interrupt a sleeping thread.
        Dim sleepingThread = New Thread(AddressOf SleepIndefinitely)
        sleepingThread.Name = "Sleeping"
        sleepingThread.Start()
        Thread.Sleep(2000)
        sleepingThread.Interrupt()
        sleepingThread.Join()
    End Sub

    Private Sub SleepIndefinitely()
        Console.WriteLine("Thread '{0}' about to sleep indefinitely.",
                          Thread.CurrentThread.Name)
        Try
            Thread.Sleep(Timeout.Infinite)
        Catch ex As ThreadInterruptedException
            Console.WriteLine("Thread '{0}' awoken.",
                              Thread.CurrentThread.Name)
        Finally
            Console.WriteLine("Thread '{0}' executing finally block.",
                              Thread.CurrentThread.Name)
        End Try
        Console.WriteLine("Thread '{0}' finishing normal execution.",
                          Thread.CurrentThread.Name)
        Console.WriteLine()
    End Sub
End Module
' The example displays the following output:
'       Thread 'Sleeping' about to sleep indefinitely.
'       Thread 'Sleeping' awoken.
'       Thread 'Sleeping' executing finally block.
'       Thread 'Sleeping' finishing normal execution.
' </Snippet1>
