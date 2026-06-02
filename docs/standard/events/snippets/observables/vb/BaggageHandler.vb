Namespace Example

    Public NotInheritable Class BaggageHandler
        Implements IObservable(Of BaggageInfo)

        Private ReadOnly _lock As New Object()
        Private ReadOnly _observers As New HashSet(Of IObserver(Of BaggageInfo))()
        Private ReadOnly _flights As New HashSet(Of BaggageInfo)()

        Public Function Subscribe(observer As IObserver(Of BaggageInfo)) As IDisposable Implements IObservable(Of BaggageInfo).Subscribe
            Dim snapshot As BaggageInfo()

            SyncLock _lock
                ' Check whether observer is already registered. If not, add it.
                If Not _observers.Add(observer) Then
                    Return New Unsubscriber(Of BaggageInfo)(_lock, _observers, observer)
                End If

                ' Snapshot existing data while holding the lock.
                snapshot = _flights.ToArray()
            End SyncLock

            ' Provide observer with existing data outside the lock.
            For Each item As BaggageInfo In snapshot
                observer.OnNext(item)
            Next

            Return New Unsubscriber(Of BaggageInfo)(_lock, _observers, observer)
        End Function

        ' Called to indicate all baggage is now unloaded.
        Public Sub BaggageStatus(flightNumber As Integer)
            BaggageStatus(flightNumber, String.Empty, 0)
        End Sub

        Public Sub BaggageStatus(flightNumber As Integer, from As String, carousel As Integer)
            Dim info As New BaggageInfo(flightNumber, from, carousel)
            Dim snapshot As IObserver(Of BaggageInfo)()

            ' Carousel is assigned, so add new info object to list.
            If carousel > 0 Then
                SyncLock _lock
                    If Not _flights.Add(info) Then
                        Return
                    End If

                    snapshot = _observers.ToArray()
                End SyncLock

                For Each observer As IObserver(Of BaggageInfo) In snapshot
                    observer.OnNext(info)
                Next
            ElseIf carousel = 0 Then
                ' Baggage claim for flight is done.
                SyncLock _lock
                    If _flights.RemoveWhere(
                        Function(flight) flight.FlightNumber = info.FlightNumber) = 0 Then
                        Return
                    End If

                    snapshot = _observers.ToArray()
                End SyncLock

                For Each observer As IObserver(Of BaggageInfo) In snapshot
                    observer.OnNext(info)
                Next
            End If
        End Sub

        Public Sub LastBaggageClaimed()
            Dim snapshot As IObserver(Of BaggageInfo)()

            SyncLock _lock
                snapshot = _observers.ToArray()
                _observers.Clear()
            End SyncLock

            For Each observer As IObserver(Of BaggageInfo) In snapshot
                observer.OnCompleted()
            Next
        End Sub
    End Class

End Namespace
