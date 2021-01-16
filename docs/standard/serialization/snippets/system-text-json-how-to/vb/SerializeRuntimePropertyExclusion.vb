Imports System.Text.Json

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    Public NotInheritable Class SerializeRuntimePropertyExclusion
        'Public Shared Sub Run()
        '    Dim jsonString As String
        '    Dim wf = WeatherForecastFactories.CreateWeatherForecast()
        '    wf.DisplayPropertyValues()

        '    Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions With {.WriteIndented = True}
        '    serializeOptions.Converters.Add(New WeatherForecastRuntimeIgnoreConverter)
        '    jsonString = JsonSerializer.Serialize(wf, serializeOptions)
        '    Console.WriteLine($"JSON output:{jsonString}")

        '    wf.Summary = "N/A"
        '    wf.DisplayPropertyValues()
        '    jsonString = JsonSerializer.Serialize(wf, serializeOptions)
        '    Console.WriteLine($"JSON output:{jsonString}")

        '    Dim deserializeOptions As JsonSerializerOptions = New JsonSerializerOptions
        '    deserializeOptions.Converters.Add(New WeatherForecastRuntimeIgnoreConverter)
        '    wf = JsonSerializer.Deserialize(Of WeatherForecast)(jsonString, deserializeOptions)
        '    wf.DisplayPropertyValues()
        'End Sub
    End Class
End Namespace
