Imports System.Text.Json

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    Public NotInheritable Class RoundtripCallbacks
        'Public Shared Sub Run()
        '    Dim jsonString As String
        '    Dim wf = WeatherForecastFactories.CreateWeatherForecast()
        '    wf.DisplayPropertyValues()

        '    ' <Serialize>
        '    Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions With {.WriteIndented = True}
        '    serializeOptions.Converters.Add(New WeatherForecastCallbacksConverter)

        '    jsonString = JsonSerializer.Serialize(wf, serializeOptions)
        '    ' </Serialize>

        '    Console.WriteLine($"JSON output:{jsonString}")

        '    ' <Deserialize>
        '    Dim deserializeOptions As JsonSerializerOptions = New JsonSerializerOptions
        '    deserializeOptions.Converters.Add(New WeatherForecastCallbacksConverter)
        '    wf = JsonSerializer.Deserialize(Of WeatherForecast)(jsonString, deserializeOptions)
        '    ' <Deserialize>

        '    wf.DisplayPropertyValues()
        'End Sub
    End Class
End Namespace
