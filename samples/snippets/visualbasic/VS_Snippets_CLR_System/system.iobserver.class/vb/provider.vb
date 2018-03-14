Imports System.Collections.Generic

' <Snippet6>
Public Class LocationTracker : Implements IObservable(Of Location)

   Public Sub New()
      observers = New List(Of IObserver(Of Location))
   End Sub

   ' <Snippet13>
   Private observers As List(Of IObserver(Of Location))

   Public Function Subscribe(ByVal observer As System.IObserver(Of Location)) As System.IDisposable _
                            Implements System.IObservable(Of Location).Subscribe
      If Not observers.Contains(observer) Then
         observers.Add(observer)
      End If
      Return New Unsubscriber(observers, observer)
   End Function

   Private Class Unsubscriber : Implements IDisposable
      Private _observers As List(Of IObserver(Of Location))
      Private _observer As IObserver(Of Location)

      Public Sub New(ByVal observers As List(Of IObserver(Of Location)), ByVal observer As IObserver(Of Location))
         Me._observers = observers
         Me._observer = observer
      End Sub

      Public Sub Dispose() Implements IDisposable.Dispose
         If _observer IsNot Nothing AndAlso _observers.Contains(_observer) Then
            _observers.Remove(_observer)
         End If
      End Sub
   End Class
   ' </Snippet13>

   Public Sub TrackLocation(ByVal loc As Nullable(Of Location))
      For Each observer In observers
         If Not loc.HasValue Then
            observer.OnError(New LocationUnknownException())
         Else
            observer.OnNext(loc.Value)
         End If
      Next
   End Sub

   Public Sub EndTransmission()
      For Each observer In observers.ToArray()
         If observers.Contains(observer) Then observer.OnCompleted()
      Next
      observers.Clear()
   End Sub
End Class
' </Snippet6>

' <Snippet5>
Public Structure Location
   Dim lat, lon As Double

   Public Sub New(ByVal latitude As Double, ByVal longitude As Double)
      Me.lat = latitude
      Me.lon = longitude
   End Sub

   Public ReadOnly Property Latitude As Double
      Get
         Return Me.lat
      End Get
   End Property

   Public ReadOnly Property Longitude As Double
      Get
         Return Me.lon
      End Get
   End Property
End Structure
' </Snippet5>

' <Snippet7>
Public Class LocationUnknownException : Inherits Exception
   Friend Sub New()
   End Sub
End Class
' </Snippet7>
