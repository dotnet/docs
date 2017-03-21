'<Snippet1>
Imports System.Device.Location
Module GetLocationProperty
    '<Snippet2>
    Public Sub GetLocationProperty()
        Dim watcher As New System.Device.Location.GeoCoordinateWatcher()
        watcher.TryStart(False, TimeSpan.FromMilliseconds(1000))

        Dim coord As GeoCoordinate = watcher.Position.Location

        If coord.IsUnknown <> True Then
            Console.WriteLine("Lat: {0}, Long: {1}", coord.Latitude, coord.Longitude)
        Else
            Console.WriteLine("Unknown latitude and longitude.")
        End If
    End Sub
    '</Snippet2>

    Public Sub Main()
        GetLocationProperty()
        Console.ReadLine()
    End Sub

End Module
'</Snippet1>
