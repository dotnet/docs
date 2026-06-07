Imports TemperatureSample

Module Program
    Sub Main()
        Dim provider As New TemperatureMonitor()
        Dim observer1 As New TemperatureReporter()
        Dim observer2 As New TemperatureReporter()

        observer1.Subscribe(provider)
        observer2.Subscribe(provider)

        provider.GetTemperatureAsync().GetAwaiter().GetResult()
    End Sub
End Module
