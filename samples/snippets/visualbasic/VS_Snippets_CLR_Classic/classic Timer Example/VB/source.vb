' <Snippet1>
' Use this code inside a project created with the Visual Basic > Windows Desktop > Console Application template. 
' Replace the default code in Module1.vb with this code. Then right click the project in Solution Explorer, 
' select Properties, and set the Startup Object to Timer1. 

' To avoid confusion with other Timer classes, this sample always uses the fully-qualified
' name of System.Timers.Timer.

Imports System

Public Class Module1

    Private Shared aTimer As System.Timers.Timer

    Public Shared Sub Main()
        ' Normally, the timer is declared at the class level, so that it stays in scope as long as it
        ' is needed. If the timer is declared in a long-running method, KeepAlive must be used to prevent
        ' the JIT compiler from allowing aggressive garbage collection to occur before the method ends.
        ' You can experiment with this by commenting out the class-level declaration and uncommenting 
        ' the declaration below; then uncomment the GC.KeepAlive(aTimer) at the end of the method.        
        'Dim aTimer As System.Timers.Timer 

        ' Create a timer and set a two second interval.
        aTimer = New System.Timers.Timer()
        aTimer.Interval = 2000

        ' Alternate method: create a Timer with an interval argument to the constructor.
        ' aTimer = New System.Timers.Timer(2000)

        ' Hook up the Elapsed event for the timer.  
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent

        ' Have the timer fire repeated events (true is the default)
        aTimer.AutoReset = True

        ' Start the timer
        aTimer.Enabled = True

        Console.WriteLine("Press the Enter key to exit the program at any time... ")
        Console.ReadLine()

        ' If the timer is declared in a long-running method, use KeepAlive to prevent garbage collection
        ' from occurring before the method ends. 
        'GC.KeepAlive(aTimer) 
    End Sub

    Private Shared Sub OnTimedEvent(source As Object, e As System.Timers.ElapsedEventArgs)
        Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime)
    End Sub
End Class

' This example displays output like the following: 
'       Press the Enter key to exit the program at any time... 
'       The Elapsed event was raised at 5/20/2015 8:48:58 PM 
'       The Elapsed event was raised at 5/20/2015 8:49:00 PM 
'       The Elapsed event was raised at 5/20/2015 8:49:02 PM 
'       The Elapsed event was raised at 5/20/2015 8:49:04 PM 
'       The Elapsed event was raised at 5/20/2015 8:49:06 PM 
' </Snippet1>
