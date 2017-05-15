'<Snippet1>
Imports System.Device.Location
Module ResolveCivicAddressAsync
    '<Snippet2>

    Public Sub ResolveCivicAddressAsync()
        Dim watcher As GeoCoordinateWatcher
        watcher = New System.Device.Location.GeoCoordinateWatcher(GeoPositionAccuracy.High)
        Dim started As Boolean = False
        watcher.MovementThreshold = 1.0     'set to one meter
        started = watcher.TryStart(False, TimeSpan.FromMilliseconds(1000))
        If started Then
            Dim resolver As CivicAddressResolver = New CivicAddressResolver()
            AddHandler resolver.ResolveAddressCompleted, AddressOf resolver_ResolveAddressCompleted
            If Not watcher.Position.Location.IsUnknown Then
                resolver.ResolveAddressAsync(watcher.Position.Location)
            End If
        End If

        watcher.Start()

    End Sub

    Sub resolver_ResolveAddressCompleted(ByVal sender As Object, ByVal e As ResolveAddressCompletedEventArgs)
        If Not e.Address.IsUnknown Then
            Console.WriteLine("Country: {0}, Zip: {1}",
                           e.Address.CountryRegion,
                           e.Address.PostalCode)
        Else
            Console.WriteLine("Unknown address.")
        End If
    End Sub

    '</Snippet2>

    Public Sub Main()

        ResolveCivicAddressAsync()
        Console.WriteLine("Enter any key to quit.")
        Console.ReadLine()
    End Sub

End Module
'</Snippet1>
