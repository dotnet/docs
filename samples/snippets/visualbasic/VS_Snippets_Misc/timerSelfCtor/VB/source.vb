'<Snippet1>
Imports System
Imports System.Threading

Public Class Example
    Public Shared Sub Main()
        ' Create an instance of the Example class, and start two
        ' timers.
        Dim ex As New Example()
        ex.StartTimer(2000)
        ex.StartTimer(1000)

        Console.WriteLine("Press Enter to end the program.")
        Console.ReadLine()
    End Sub

    Public Sub StartTimer(ByVal dueTime As Integer)
        Dim t As New Timer(AddressOf TimerProc)
        t.Change(dueTime, 0)
    End Sub

    Private Sub TimerProc(ByVal state As Object)
        ' The state object is the Timer object.
        Dim t As Timer = CType(state, Timer)
        t.Dispose()
        Console.WriteLine("The timer callback executes.")
    End Sub
End Class
'</Snippet1>