' <Snippet5>
Module Example
    Public Sub Main()
        Dim provider As New BaggageHandler()
        Dim observer1 As New ArrivalsMonitor("BaggageClaimMonitor1")
        Dim observer2 As New ArrivalsMonitor("SecurityExit")

        provider.BaggageStatus(712, "Detroit", 3)
        observer1.Subscribe(provider)
        provider.BaggageStatus(712, "Kalamazoo", 3)
        provider.BaggageStatus(400, "New York-Kennedy", 1)
        provider.BaggageStatus(712, "Detroit", 3)
        observer2.Subscribe(provider)
        provider.BaggageStatus(511, "San Francisco", 2)
        provider.BaggageStatus(712)
        observer2.Unsubscribe()
        provider.BaggageStatus(400)
        provider.LastBaggageClaimed()
    End Sub
End Module
' The example displays the following output:
'      Arrivals information from BaggageClaimMonitor1
'      Detroit                712    3
'
'      Arrivals information from BaggageClaimMonitor1
'      Detroit                712    3
'      Kalamazoo              712    3
'
'      Arrivals information from BaggageClaimMonitor1
'      Detroit                712    3
'      Kalamazoo              712    3
'      New York-Kennedy       400    1
'
'      Arrivals information from SecurityExit
'      Detroit                712    3
'
'      Arrivals information from SecurityExit
'      Detroit                712    3
'      Kalamazoo              712    3
'
'      Arrivals information from SecurityExit
'      Detroit                712    3
'      Kalamazoo              712    3
'      New York-Kennedy       400    1
'
'      Arrivals information from BaggageClaimMonitor1
'      Detroit                712    3
'      Kalamazoo              712    3
'      New York-Kennedy       400    1
'      San Francisco          511    2
'
'      Arrivals information from SecurityExit
'      Detroit                712    3
'      Kalamazoo              712    3
'      New York-Kennedy       400    1
'      San Francisco          511    2
'
'      Arrivals information from BaggageClaimMonitor1
'      New York-Kennedy       400    1
'      San Francisco          511    2
'
'      Arrivals information from SecurityExit
'      New York-Kennedy       400    1
'      San Francisco          511    2
'
'      Arrivals information from BaggageClaimMonitor1
'      San Francisco          511    2
' </Snippet5>
