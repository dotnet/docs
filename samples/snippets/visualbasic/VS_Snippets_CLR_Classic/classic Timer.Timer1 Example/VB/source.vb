' <Snippet1>
Imports System.Timers

Public Module Example
    Private aTimer As System.Timers.Timer

    Public Sub Main()
        ' Create a timer with a 1.5 second interval.
        Dim interval As Double = 1500.0
        aTimer = New System.Timers.Timer(interval)

        ' Hook up the event handler for the Elapsed event.
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent

        ' Only raise the event the first time Interval elapses.
        aTimer.AutoReset = False
        aTimer.Enabled = True
        
        
        ' Ensure the event fires before the exit message appears.
        System.Threading.Thread.Sleep(CInt(interval * 2))
        Console.WriteLine("Press the Enter key to exit the program.")
        Console.ReadLine()

        ' If the timer is declared in a long-running method, use
        ' KeepAlive to prevent garbage collection from occurring
        ' before the method ends.
        'GC.KeepAlive(aTimer)
    End Sub

    ' Specify what you want to happen when the Elapsed event is 
    ' raised.
    Private Sub OnTimedEvent(source As Object, e As ElapsedEventArgs)
        Console.WriteLine("Hello World!")
    End Sub
End Module
' This example displays the following output:
'       Hello World!
'       Press the Enter key to exit the program.
' </Snippet1>
