'<Snippet1>
Imports System.Device.Location
Module GetLocationEvent
    '<Snippet2>
    Public Class CLocation
        Private WithEvents watcher As GeoCoordinateWatcher
        Public Sub GetLocationDataEvent()
            watcher = New System.Device.Location.GeoCoordinateWatcher()
            AddHandler watcher.PositionChanged, AddressOf watcher_PositionChanged
            watcher.Start()

        End Sub

        Private Sub watcher_PositionChanged(ByVal sender As Object, ByVal e As GeoPositionChangedEventArgs(Of GeoCoordinate))
            PrintPosition(e.Position.Location.Latitude, e.Position.Location.Longitude)
            ' Stop receiving updates after the first one.
            watcher.Stop()
        End Sub

        Private Sub PrintPosition(ByVal Latitude As Double, ByVal Longitude As Double)
            Console.WriteLine("Latitude: {0}, Longitude {1}", Latitude, Longitude)
        End Sub
    End Class

    '</Snippet2>

    Public Sub Main()
        Dim myLocation As New CLocation()
        myLocation.GetLocationDataEvent()
        Console.WriteLine("Enter any key to quit.")
        Console.ReadLine()
    End Sub

End Module
'</Snippet1>
