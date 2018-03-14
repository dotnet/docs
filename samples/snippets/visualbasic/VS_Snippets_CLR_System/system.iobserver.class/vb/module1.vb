' <Snippet9>
Module Module1
   Dim provider As LocationTracker

   Sub Main()
      ' Define a provider and two observers.
      provider = New LocationTracker()
      Dim reporter1 As New LocationReporter("FixedGPS")
      reporter1.Subscribe(provider)
      Dim reporter2 As New LocationReporter("MobileGPS")
      reporter2.Subscribe(provider)

      provider.TrackLocation(New Location(47.6456, -122.1312))
      reporter1.Unsubscribe()
      provider.TrackLocation(New Location(47.6677, -122.1199))
      provider.TrackLocation(Nothing)
      provider.EndTransmission()
   End Sub
End Module
' The example displays output similar to the following:
'       FixedGPS: The current location is 47.6456, -122.1312
'       MobileGPS: The current location is 47.6456, -122.1312
'       MobileGPS: The current location is 47.6677, -122.1199
'       MobileGPS: The location cannot be determined.
'       The Location Tracker has completed transmitting data to MobileGPS.
' </Snippet9>
