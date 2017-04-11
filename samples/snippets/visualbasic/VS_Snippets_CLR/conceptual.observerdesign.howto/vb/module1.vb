Module Module1
   Sub Main()
      Dim provider As New TemperatureMonitor()
      Dim observer1 As New TemperatureReporter()
      observer1.Subscribe(provider)
      Dim observer2 As New TemperatureReporter()
      observer2.Subscribe(provider)
      provider.GetTemperature()
   End Sub
End Module
