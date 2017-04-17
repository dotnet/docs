' Visual Basic .NET Document
Option Strict On

Imports System.Collections.Generic
Imports System.Threading 

' <Snippet1>
Public Enum LocationStatus As Integer
   Started = 1
   EnRoute = 2
   Finished = 3   
End Enum

Public Structure Location
   Public ReadOnly Latitude As Decimal
   Public ReadOnly Longitude As Decimal
   Public ReadOnly DateAndTime As Date
   Public ReadOnly Status As LocationStatus
         
   Public Sub New(lat As Decimal, lon As Decimal, dateAndTime As Date, status As LocationStatus)
      Me.Latitude = lat
      Me.Longitude = lon
      Me.DateAndTime = dateAndTime
      Me.Status = status
   End Sub   
End Structure
' </Snippet1>

' <Snippet3>
Public Class LocationSimulator : Implements IObservable(Of Location)
   Dim observers As New List(Of IObserver(Of Location))
   Dim _location, _lastLocation, _startLocation As Location
   
   Public Shared Function SetStartingLocation() As LocationSimulator
      Return New LocationSimulator(42.2857d, -83.7213d, LocationStatus.Started)
   End Function
         
   Private Sub New(latitude As Decimal, longitude As Decimal, status As LocationStatus)
      _location = New Location(latitude, longitude, DateTime.UtcNow, status)
      _lastLocation = location   
      If status = LocationStatus.Started Then
         _startLocation = _location
      End If
   End Sub
   
   Public ReadOnly Property Location As Location
      Get
         Return Me._location               
      End Get
   End Property
   
   Public Function GetCurrentLocation() As Location
      Dim rnd As New Random()
      Dim newLat As Decimal = location.Latitude + rnd.Next(-1, 2)
      Dim newLong As Decimal = location.Longitude + rnd.Next(-1, 2)
      ' Assume arrival if the difference in latitude is 3.   
      _lastLocation = _location
      Dim status As LocationStatus = If(Math.Abs(_startLocation.Latitude - newLat) >= 3, _
                  LocationStatus.Finished, LocationStatus.EnRoute)
      _location = New Location(_location.Latitude + rnd.Next(-1, 2),
                               _location.Longitude + rnd.Next(-1, 2), 
                               Date.UtcNow, status)
      If Not _location.Equals(_lastLocation) Then
         ' Notify observers.
         For Each observer In observers
            observer.OnNext(Me.Location)
            If _location.Status = LocationStatus.Finished Then
               observer.OnCompleted() 
            End If               
         Next
      End If      
      Return Me.Location   
   End Function
   
   Public Function Subscribe(observer As IObserver(Of Location)) As IDisposable _
                   Implements IObservable(Of Location).Subscribe
      observers.Add(observer)
      ' Announce current location to new observer.
      observer.OnNext(Me.Location)
      Return TryCast(observer, IDisposable)
   End Function
End Class
' </Snippet3>

' <Snippet2>
Public Class LocationDisplay : Implements IObserver(Of Location)
   Public Sub OnNext(value As Location) _
              Implements IObserver(Of Location).OnNext
      Console.WriteLine("{3}At {0}, Latitude = {1:N4}, Longitude = {2:N4}", value.DateAndTime, value.Latitude, value.Longitude,
                        If(value.Status = LocationStatus.Started, "Starting ", ""))
   End Sub
   
   Public Sub OnError(ex As Exception) _ 
              Implements IObserver(Of Location).OnError
      Console.WriteLine("Unable to determine the current location.")           
   End Sub
   
   Public Sub OnCompleted() _
              Implements IObserver(Of Location).OnCompleted
      Console.WriteLine("Finished tracking the current location.")           
   End Sub       
End Class
' </Snippet2>

' <Snippet4>
Module Example
   Public Sub Main()
       Dim simulator As LocationSimulator = LocationSimulator.SetStartingLocation()
         
       ' Subscribe with class that implements IObserver<Location>
       Dim d As IDisposable = simulator.Subscribe(New LocationDisplay())
       Dim loc As Location
       Do
          loc = simulator.GetCurrentLocation()      
          Thread.Sleep(2500)
       Loop While loc.Status <> LocationStatus.Finished  
   End Sub
End Module
' </Snippet4>

