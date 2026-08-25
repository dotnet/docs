' <All>
' <Subscribe>
' <ClassDeclaration>
Namespace Global.TemperatureSample

    Public NotInheritable Class TemperatureReporter
        Implements IObserver(Of Temperature)
        ' </ClassDeclaration>

        Private _unsubscriber As IDisposable
        Private _last As Temperature?

        Public Sub Subscribe(provider As IObservable(Of Temperature))
            ArgumentNullException.ThrowIfNull(provider)
            _unsubscriber = provider.Subscribe(Me)
        End Sub
        ' </Subscribe>

        ' <Unsubscribe>
        Public Sub Unsubscribe()
            _unsubscriber?.Dispose()
        End Sub
        ' </Unsubscribe>

        ' <ObserverMethods>
        Public Sub OnCompleted() Implements IObserver(Of Temperature).OnCompleted
            Console.WriteLine("Additional temperature data won't be transmitted.")
        End Sub

        ' OnError is informational; observers shouldn't treat it as an exception to handle.
        Public Sub OnError(error_ As Exception) Implements IObserver(Of Temperature).OnError
        End Sub

        Public Sub OnNext(value As Temperature) Implements IObserver(Of Temperature).OnNext
            Console.WriteLine($"The temperature is {value.Degrees}°C at {value.Date:g}")

            If _last.HasValue Then
                Dim previous = _last.Value
                Dim elapsed = value.Date.ToUniversalTime() - previous.Date.ToUniversalTime()
                Console.WriteLine($"   Change: {value.Degrees - previous.Degrees}° in {elapsed:g}")
            End If

            _last = value
        End Sub
        ' </ObserverMethods>
    End Class

End Namespace
' </All>
