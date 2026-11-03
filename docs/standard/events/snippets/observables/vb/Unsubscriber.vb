Namespace Example

    Friend NotInheritable Class Unsubscriber(Of T)
        Implements IDisposable

        Private ReadOnly _lock As Object
        Private ReadOnly _observers As ISet(Of IObserver(Of T))
        Private ReadOnly _observer As IObserver(Of T)

        Friend Sub New(lock As Object, observers As ISet(Of IObserver(Of T)), observer As IObserver(Of T))
            _lock = lock
            _observers = observers
            _observer = observer
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            SyncLock _lock
                _observers.Remove(_observer)
            End SyncLock
        End Sub
    End Class

End Namespace
