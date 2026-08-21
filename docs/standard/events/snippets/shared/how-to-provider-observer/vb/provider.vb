' <All>
' <ObserverList>
' <ClassDeclaration>
Imports System.Threading
Imports System.Threading.Tasks

Namespace Global.TemperatureSample

    Public NotInheritable Class TemperatureMonitor
        Implements IObservable(Of Temperature)
        ' </ClassDeclaration>

        Private ReadOnly _observers As New List(Of IObserver(Of Temperature))()
        Private ReadOnly _sync As New Object()
        ' </ObserverList>

        ' <Unsubscriber>
        Private NotInheritable Class Unsubscriber
            Implements IDisposable

            Private ReadOnly _observers As List(Of IObserver(Of Temperature))
            Private ReadOnly _observer As IObserver(Of Temperature)
            Private ReadOnly _sync As Object

            Public Sub New(observers As List(Of IObserver(Of Temperature)),
                           observer As IObserver(Of Temperature),
                           sync As Object)
                _observers = observers
                _observer = observer
                _sync = sync
            End Sub

            Public Sub Dispose() Implements IDisposable.Dispose
                SyncLock _sync
                    _observers.Remove(_observer)
                End SyncLock
            End Sub
        End Class
        ' </Unsubscriber>

        ' <Subscribe>
        Public Function Subscribe(observer As IObserver(Of Temperature)) As IDisposable _
            Implements IObservable(Of Temperature).Subscribe

            ArgumentNullException.ThrowIfNull(observer)

            SyncLock _sync
                If Not _observers.Contains(observer) Then
                    _observers.Add(observer)
                End If
            End SyncLock

            Return New Unsubscriber(_observers, observer, _sync)
        End Function
        ' </Subscribe>

        ' <Notify>
        Public Async Function GetTemperatureAsync(Optional cancellationToken As CancellationToken = Nothing) As Task
            ' Sample data that mimics a temperature device. A Nothing value signals the end of transmission.
            Dim temps As Decimal?() = {
                14.6D, 14.65D, 14.7D, 14.9D, 14.9D, 15.2D,
                15.25D, 15.2D, 15.4D, 15.45D, Nothing
            }

            Dim previous As Decimal? = Nothing

            For Each temp As Decimal? In temps
                Await Task.Delay(TimeSpan.FromSeconds(2.5), cancellationToken)

                If temp.HasValue Then
                    ' Notify only after at least a 0.1° change.
                    If Not previous.HasValue OrElse Math.Abs(temp.Value - previous.Value) >= 0.1D Then
                        NotifyAll(New Temperature(temp.Value, Date.Now))
                        previous = temp
                    End If
                Else
                    CompleteAll()
                    Exit For
                End If
            Next
        End Function

        Private Sub NotifyAll(data As Temperature)
            Dim snapshot As IObserver(Of Temperature)()
            SyncLock _sync
                snapshot = _observers.ToArray()
            End SyncLock

            For Each observer In snapshot
                observer.OnNext(data)
            Next
        End Sub

        Private Sub CompleteAll()
            Dim snapshot As IObserver(Of Temperature)()
            SyncLock _sync
                snapshot = _observers.ToArray()
                _observers.Clear()
            End SyncLock

            For Each observer In snapshot
                observer.OnCompleted()
            Next
        End Sub
        ' </Notify>
    End Class

End Namespace
' </All>
