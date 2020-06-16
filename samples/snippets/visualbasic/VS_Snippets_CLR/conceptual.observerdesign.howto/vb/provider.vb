' <Snippet7>
Imports System.Threading
' <Snippet3>
' <Snippet2>
Imports System.Collections.Generic


Public Class TemperatureMonitor : Implements IObservable(Of Temperature)
    ' </Snippet2>
    Dim observers As List(Of IObserver(Of Temperature))

    Public Sub New()
        observers = New List(Of IObserver(Of Temperature))
    End Sub
    ' </Snippet3>

    ' <Snippet4>
    Private Class Unsubscriber : Implements IDisposable
        Private _observers As List(Of IObserver(Of Temperature))
        Private _observer As IObserver(Of Temperature)

        Public Sub New(ByVal observers As List(Of IObserver(Of Temperature)), ByVal observer As IObserver(Of Temperature))
            Me._observers = observers
            Me._observer = observer
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            If _observer IsNot Nothing Then _observers.Remove(_observer)
        End Sub
    End Class
    ' </Snippet4>

    ' <Snippet5>
    Public Function Subscribe(ByVal observer As System.IObserver(Of Temperature)) As System.IDisposable Implements System.IObservable(Of Temperature).Subscribe
        If Not observers.Contains(observer) Then
            observers.Add(observer)
        End If
        Return New Unsubscriber(observers, observer)
    End Function
    ' </Snippet5>

    ' <Snippet6>
    Public Sub GetTemperature()
        ' Create an array of sample data to mimic a temperature device.
        Dim temps() As Nullable(Of Decimal) = {14.6D, 14.65D, 14.7D, 14.9D, 14.9D, 15.2D, 15.25D, 15.2D,
                                              15.4D, 15.45D, Nothing}
        ' Store the previous temperature, so notification is only sent after at least .1 change.
        Dim previous As Nullable(Of Decimal)
        Dim start As Boolean = True

        For Each temp In temps
            System.Threading.Thread.Sleep(2500)

            If temp.HasValue Then
                If start OrElse Math.Abs(temp.Value - previous.Value) >= 0.1 Then
                    Dim tempData As New Temperature(temp.Value, Date.Now)
                    For Each observer In observers
                        observer.OnNext(tempData)
                    Next
                    previous = temp
                    If start Then start = False
                End If
            Else
                For Each observer In observers.ToArray()
                    If observer IsNot Nothing Then observer.OnCompleted()
                Next
                observers.Clear()
                Exit For
            End If
        Next
    End Sub
    ' </Snippet6>
End Class
' </Snippet7>
