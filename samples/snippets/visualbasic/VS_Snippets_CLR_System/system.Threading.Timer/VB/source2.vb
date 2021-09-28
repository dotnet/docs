' <snippet2>
Imports System.Threading

Module Program

    Private Timer As Timer

    Sub Main(args As String())

        Dim StateObj As New TimerState
        StateObj.Counter = 0

        Timer = New Timer(New TimerCallback(AddressOf TimerTask), StateObj, 1000, 2000)

        While StateObj.Counter <= 10
            Task.Delay(1000).Wait()
        End While

        Timer.Dispose()
        Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}: done.")
    End Sub

    Private Sub TimerTask(ByVal StateObj As Object)

        Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}: starting a new callback.")

        Dim State As TimerState = CType(StateObj, TimerState)
        Interlocked.Increment(State.Counter)
    End Sub

    Private Class TimerState
        Public Counter As Integer
    End Class
End Module
' </snippet2>
