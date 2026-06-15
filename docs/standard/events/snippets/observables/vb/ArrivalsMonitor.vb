Imports System.Threading

Namespace Example

    Public Class ArrivalsMonitor
        Implements IObserver(Of BaggageInfo)

        Private ReadOnly _name As String
        Private ReadOnly _lock As New Object()
        Private ReadOnly _flights As New List(Of String)()
        Private ReadOnly _format As String = "{0,-20} {1,5}  {2, 3}"
        Private _cancellation As IDisposable

        Public Sub New(name As String)
            If String.IsNullOrEmpty(name) Then
                Throw New ArgumentException("Value cannot be null or empty.", NameOf(name))
            End If
            _name = name
        End Sub

        Public Overridable Sub Subscribe(provider As BaggageHandler)
            _cancellation = provider.Subscribe(Me)
        End Sub

        Public Overridable Sub Unsubscribe()
            Dim previous = Interlocked.Exchange(_cancellation, Nothing)
            previous?.Dispose()

            SyncLock _lock
                _flights.Clear()
            End SyncLock
        End Sub

        Public Overridable Sub OnCompleted() Implements IObserver(Of BaggageInfo).OnCompleted
            SyncLock _lock
                _flights.Clear()
            End SyncLock
        End Sub

        ' No implementation needed: Method is not called by the BaggageHandler class.
        Public Overridable Sub OnError([error] As Exception) Implements IObserver(Of BaggageInfo).OnError
            ' No implementation.
        End Sub

        ' Update information.
        Public Overridable Sub OnNext(info As BaggageInfo) Implements IObserver(Of BaggageInfo).OnNext
            Dim updated As Boolean = False

            SyncLock _lock
                ' Flight has unloaded its baggage; remove from the monitor.
                If info.Carousel = 0 Then
                    Dim flightNumber As String = String.Format("{0,5}", info.FlightNumber)
                    For index As Integer = _flights.Count - 1 To 0 Step -1
                        Dim flightInfo As String = _flights(index)
                        If flightInfo.Substring(21, 5).Equals(flightNumber) Then
                            updated = True
                            _flights.RemoveAt(index)
                        End If
                    Next
                Else
                    ' Add flight if it doesn't exist in the collection.
                    Dim flightInfo As String = String.Format(_format, info.From, info.FlightNumber, info.Carousel)
                    If Not _flights.Contains(flightInfo) Then
                        _flights.Add(flightInfo)
                        updated = True
                    End If
                End If

                If updated Then
                    _flights.Sort()
                    Console.WriteLine($"Arrivals information from {_name}")
                    For Each flightInfo As String In _flights
                        Console.WriteLine(flightInfo)
                    Next

                    Console.WriteLine()
                End If
            End SyncLock
        End Sub
    End Class

End Namespace
