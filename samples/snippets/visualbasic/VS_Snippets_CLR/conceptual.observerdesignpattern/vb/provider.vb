' <Snippet1>
Public Class BaggageInfo
    Private flightNo As Integer
    Private origin As String
    Private location As Integer

    Friend Sub New(ByVal flight As Integer, ByVal from As String, ByVal carousel As Integer)
        Me.flightNo = flight
        Me.origin = from
        Me.location = carousel
    End Sub

    Public ReadOnly Property FlightNumber As Integer
        Get
            Return Me.flightNo
        End Get
    End Property

    Public ReadOnly Property From As String
        Get
            Return Me.origin
        End Get
    End Property

    Public ReadOnly Property Carousel As Integer
        Get
            Return Me.location
        End Get
    End Property
End Class
' </Snippet1>

' <Snippet2>
Public Class BaggageHandler : Implements IObservable(Of BaggageInfo)

    Private observers As List(Of IObserver(Of BaggageInfo))
    Private flights As List(Of BaggageInfo)

    Public Sub New()
        observers = New List(Of IObserver(Of BaggageInfo))
        flights = New List(Of BaggageInfo)
    End Sub

    Public Function Subscribe(ByVal observer As IObserver(Of BaggageInfo)) As IDisposable _
                    Implements IObservable(Of BaggageInfo).Subscribe
        ' Check whether observer is already registered. If not, add it
        If Not observers.Contains(observer) Then
            observers.Add(observer)
            ' Provide observer with existing data.
            For Each item In flights
                observer.OnNext(item)
            Next
        End If
        Return New Unsubscriber(Of BaggageInfo)(observers, observer)
    End Function

    ' Called to indicate all baggage is now unloaded.
    Public Sub BaggageStatus(ByVal flightNo As Integer)
        BaggageStatus(flightNo, String.Empty, 0)
    End Sub

    Public Sub BaggageStatus(ByVal flightNo As Integer, ByVal from As String, ByVal carousel As Integer)
        Dim info As New BaggageInfo(flightNo, from, carousel)

        ' Carousel is assigned, so add new info object to list.
        If carousel > 0 And Not flights.Contains(info) Then
            flights.Add(info)
            For Each observer In observers
                observer.OnNext(info)
            Next
        ElseIf carousel = 0 Then
            ' Baggage claim for flight is done
            Dim flightsToRemove As New List(Of BaggageInfo)
            For Each flight In flights
                If info.FlightNumber = flight.FlightNumber Then
                    flightsToRemove.Add(flight)
                    For Each observer In observers
                        observer.OnNext(info)
                    Next
                End If
            Next
            For Each flightToRemove In flightsToRemove
                flights.Remove(flightToRemove)
            Next
            flightsToRemove.Clear()
        End If
    End Sub

    Public Sub LastBaggageClaimed()
        For Each observer In observers
            observer.OnCompleted()
        Next
        observers.Clear()
    End Sub
End Class
' </Snippet2>

' <Snippet3>
Friend Class Unsubscriber(Of BaggageInfo) : Implements IDisposable
    Private _observers As List(Of IObserver(Of BaggageInfo))
    Private _observer As IObserver(Of BaggageInfo)

    Friend Sub New(ByVal observers As List(Of IObserver(Of BaggageInfo)), ByVal observer As IObserver(Of BaggageInfo))
        Me._observers = observers
        Me._observer = observer
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If _observers.Contains(_observer) Then
            _observers.Remove(_observer)
        End If
    End Sub
End Class
' </Snippet3>


