Imports Observables.Example
Imports System.Threading

Module Program
    Sub Main(args As String())
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
