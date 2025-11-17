'<Snippet4>
' Example showing event handling with Handles and WithEvents
Public Class EventPublisher
    Public Event SomethingHappened()
    
    Public Sub CauseEvent()
        ' Raise the event when something interesting happens
        RaiseEvent SomethingHappened()
    End Sub
End Class

Public Class EventSubscriber
    ' Declare a WithEvents variable
    Dim WithEvents eventObj As New EventPublisher
    
    ' Handle the event using Handles clause
    Public Sub ProcessHappen() Handles eventObj.SomethingHappened
        ' Insert code to handle somethingHappened event.
        Console.WriteLine("Event handled using Handles clause!")
    End Sub
    
    Public Sub TriggerEvent()
        eventObj.CauseEvent()
    End Sub
End Class
'</Snippet4>

'<Snippet5>
' Example showing event handling with AddHandler
Public Class Timer
    Public Event TimerElapsed(ByVal message As String)
    
    Public Sub Start()
        ' Simulate timer elapsed
        RaiseEvent TimerElapsed("Timer has elapsed!")
    End Sub
End Class

Public Class Application
    Private appTimer As New Timer()
    
    Sub New()
        ' Use AddHandler to dynamically associate event handler
        AddHandler appTimer.TimerElapsed, AddressOf OnTimerElapsed
    End Sub

    Private Sub OnTimerElapsed(ByVal message As String)
        ' Insert code to handle timer elapsed event
        Console.WriteLine($"Handling timer event: {message}")
    End Sub
    
    Public Sub StartTimer()
        appTimer.Start()
    End Sub
End Class
'</Snippet5>

' Demo program to show both event handling approaches
Module Program
    Sub Main()
        ' Demonstrate Handles approach
        Console.WriteLine("=== Demonstrating Handles approach ===")
        Dim subscriber As New EventSubscriber()
        subscriber.TriggerEvent()
        
        ' Demonstrate AddHandler approach
        Console.WriteLine("=== Demonstrating AddHandler approach ===")
        Dim app As New Application()
        app.StartTimer()
        
        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()
    End Sub
End Module
