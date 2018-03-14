'<Snippet1>
Imports System.Device.Location
Module GetLocationProperty
    '<Snippet2>
    Public Sub GetLocationPropertyHandleUnknown()
        Dim watcher As New System.Device.Location.GeoCoordinateWatcher()
        watcher.TryStart(False, TimeSpan.FromMilliseconds(1000))
        If watcher.Position.Location.IsUnknown <> True Then
            Dim coord As GeoCoordinate = watcher.Position.Location
            Console.WriteLine("Lat: {0}, Long: {1}", coord.Latitude, coord.Longitude)
        Else
            Console.WriteLine("Unknown latitude and longitude.")
        End If
    End Sub
    '</Snippet2>

    Public Sub Main()
        GetLocationPropertyHandleUnknown()
        Console.ReadLine()
    End Sub

End Module
'</Snippet1>
