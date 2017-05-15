'<Snippet1>
Imports System.Device.Location
Module ResolveAddressSync
    '<Snippet2>

    Public Sub ResolveAddressSync()
        Dim watcher As GeoCoordinateWatcher
        watcher = New System.Device.Location.GeoCoordinateWatcher(GeoPositionAccuracy.High)
        Dim started As Boolean = False
        watcher.MovementThreshold = 1.0     'set to one meter
        started = watcher.TryStart(False, TimeSpan.FromMilliseconds(1000))

        Dim resolver As CivicAddressResolver = New CivicAddressResolver()
        If started Then
            If Not watcher.Position.Location.IsUnknown Then
                Dim address As CivicAddress = resolver.ResolveAddress(watcher.Position.Location)
                If Not address.IsUnknown Then
                    Console.WriteLine("Country: {0}, Zip: {1}",
                                address.CountryRegion,
                                address.PostalCode)
                Else
                    Console.WriteLine("Address unknown.")
                End If
            End If
        Else
            Console.WriteLine("GeoCoordinateWatcher timed out on start.")
        End If
    End Sub

    '</Snippet2>

    Public Sub Main()

        ResolveAddressSync()
        Console.WriteLine("Enter any key to quit.")
        Console.ReadLine()
    End Sub

End Module
'</Snippet1>
