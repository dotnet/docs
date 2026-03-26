Module Program
    Sub Main()
        Dim sensor As New Sensor()
        ' <SubscribeEvent>
        AddHandler sensor.TemperatureChanged, AddressOf Sensor_TemperatureChanged
        ' </SubscribeEvent>
    End Sub

    ' <HandleEvent>
    Sub Sensor_TemperatureChanged(sender As Object, e As SensorEventArgs)
        Console.WriteLine("Sensor {0}: temperature changed to {1}.", e.SensorId, e.Value)
    End Sub
    ' </HandleEvent>
End Module

