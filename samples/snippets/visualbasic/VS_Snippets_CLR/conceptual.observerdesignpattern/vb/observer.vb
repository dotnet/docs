' <Snippet4>
Public Class ArrivalsMonitor : Implements IObserver(Of BaggageInfo)
    Private name As String
    Private flightInfos As New List(Of String)
    Private cancellation As IDisposable
    Private fmt As String = "{0,-20} {1,5}  {2, 3}"

    Public Sub New(ByVal name As String)
        If String.IsNullOrEmpty(name) Then Throw New ArgumentNullException("The observer must be assigned a name.")

        Me.name = name
    End Sub

    Public Overridable Sub Subscribe(ByVal provider As BaggageHandler)
        cancellation = provider.Subscribe(Me)
    End Sub

    Public Overridable Sub Unsubscribe()
        cancellation.Dispose()
        flightInfos.Clear()
    End Sub

    Public Overridable Sub OnCompleted() Implements System.IObserver(Of BaggageInfo).OnCompleted
        flightInfos.Clear()
    End Sub

    ' No implementation needed: Method is not called by the BaggageHandler class.
    Public Overridable Sub OnError(ByVal e As System.Exception) Implements System.IObserver(Of BaggageInfo).OnError
        ' No implementation.
    End Sub

    ' Update information.
    Public Overridable Sub OnNext(ByVal info As BaggageInfo) Implements System.IObserver(Of BaggageInfo).OnNext
        Dim updated As Boolean = False

        ' Flight has unloaded its baggage; remove from the monitor.
        If info.Carousel = 0 Then
            Dim flightsToRemove As New List(Of String)
            Dim flightNo As String = String.Format("{0,5}", info.FlightNumber)
            For Each flightInfo In flightInfos
                If flightInfo.Substring(21, 5).Equals(flightNo) Then
                    flightsToRemove.Add(flightInfo)
                    updated = True
                End If
            Next
            For Each flightToRemove In flightsToRemove
                flightInfos.Remove(flightToRemove)
            Next
            flightsToRemove.Clear()
        Else
            ' Add flight if it does not exist in the collection.
            Dim flightInfo As String = String.Format(fmt, info.From, info.FlightNumber, info.Carousel)
            If Not flightInfos.Contains(flightInfo) Then
                flightInfos.Add(flightInfo)
                updated = True
            End If
        End If
        If updated Then
            flightInfos.Sort()
            Console.WriteLine("Arrivals information from {0}", Me.name)
            For Each flightInfo In flightInfos
                Console.WriteLine(flightInfo)
            Next
            Console.WriteLine()
        End If
    End Sub
End Class
' </Snippet4>
