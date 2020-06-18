' <Snippet12>
' <Snippet9>
' <Snippet8>
Public Class TemperatureReporter : Implements IObserver(Of Temperature)
    ' </Snippet8>

    Private unsubscriber As IDisposable
    Private first As Boolean = True
    Private last As Temperature

    Public Overridable Sub Subscribe(ByVal provider As IObservable(Of Temperature))
        unsubscriber = provider.Subscribe(Me)
    End Sub
    ' </Snippet9>

    ' <Snippet10>
    Public Overridable Sub Unsubscribe()
        unsubscriber.Dispose()
    End Sub
    ' </Snippet10>

    ' <Snippet11>
    Public Overridable Sub OnCompleted() Implements System.IObserver(Of Temperature).OnCompleted
        Console.WriteLine("Additional temperature data will not be transmitted.")
    End Sub

    Public Overridable Sub OnError(ByVal [error] As System.Exception) Implements System.IObserver(Of Temperature).OnError
        ' Do nothing.
    End Sub

    Public Overridable Sub OnNext(ByVal value As Temperature) Implements System.IObserver(Of Temperature).OnNext
        Console.WriteLine("The temperature is {0}°C at {1:g}", value.Degrees, value.Date)
        If first Then
            last = value
            first = False
        Else
            Console.WriteLine("   Change: {0}° in {1:g}", value.Degrees - last.Degrees,
                                                          value.Date.ToUniversalTime - last.Date.ToUniversalTime)
        End If
    End Sub
    ' </Snippet11>
End Class
' </Snippet12>
