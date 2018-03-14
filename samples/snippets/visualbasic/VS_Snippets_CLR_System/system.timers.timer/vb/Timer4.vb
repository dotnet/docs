' <Snippet4>
Imports System.Timers

Public Module Example
    Private aTimer As Timer

    Public Sub Main()
        ' Create a timer and set a two second interval.
        aTimer = New System.Timers.Timer(2000)

        ' Hook up the Elapsed event for the timer.  
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent

        ' Have the timer fire repeated events (true is the default)
        aTimer.AutoReset = True

        ' Start the timer
        aTimer.Enabled = True

        Console.WriteLine("Press the Enter key to exit the program at any time... ")
        Console.ReadLine()
    End Sub

    Private Sub OnTimedEvent(source As Object, e As System.Timers.ElapsedEventArgs)
        Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime)
    End Sub
End Module
' The example displays output like the following: 
'       Press the Enter key to exit the program at any time... 
'       The Elapsed event was raised at 5/20/2015 8:48:58 PM 
'       The Elapsed event was raised at 5/20/2015 8:49:00 PM 
'       The Elapsed event was raised at 5/20/2015 8:49:02 PM 
'       The Elapsed event was raised at 5/20/2015 8:49:04 PM 
'       The Elapsed event was raised at 5/20/2015 8:49:06 PM 
' </Snippet4>
