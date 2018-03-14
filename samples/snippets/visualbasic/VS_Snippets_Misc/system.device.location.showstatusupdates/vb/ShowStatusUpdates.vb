'<Snippet1>
Imports System.Device.Location
Module GetLocationEvent

    Sub ShowStatusUpdates()
        Dim Watcher As GeoCoordinateWatcher
        Watcher = New GeoCoordinateWatcher()
        watcher.Start()
        AddHandler Watcher.StatusChanged, AddressOf watcher_StatusChanged

        Console.WriteLine("Enter any key to quit.")
        Console.ReadLine()
    End Sub

    Sub watcher_StatusChanged(ByVal sender As Object, ByVal e As GeoPositionStatusChangedEventArgs)
        Select Case e.Status
            Case GeoPositionStatus.Initializing
                Console.WriteLine("Working on location fix")
            Case GeoPositionStatus.Ready
                Console.WriteLine("Have location")
            Case GeoPositionStatus.NoData
                Console.WriteLine("No data")
            Case GeoPositionStatus.Disabled
                Console.WriteLine("Disabled")
        End Select
    End Sub

    Public Sub Main()
        ShowStatusUpdates()
    End Sub
End Module
'</Snippet1>
