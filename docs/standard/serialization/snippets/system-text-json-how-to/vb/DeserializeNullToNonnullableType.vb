Imports System.Text.Json

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    Public NotInheritable Class DeserializeNullToNonnullableType
        'Public Shared Sub Run()
        '    Dim jsonString As String
        '    Dim wf = WeatherForecastFactories.CreateWeatherForecast()

        '    Dim options As JsonSerializerOptions = New JsonSerializerOptions With {.WriteIndented = True}
        '    options.Converters.Add(New DateTimeOffsetNullHandlingConverter)
        '    jsonString = JsonSerializer.Serialize(wf, options)
        '    Console.WriteLine($"JSON with valid Date:{jsonString}")

        '    wf = JsonSerializer.Deserialize(Of WeatherForecast)(jsonString, options)
        '    wf.DisplayPropertyValues()

        '    jsonString = "{""Date"": null,""TemperatureCelsius"": 25,""Summary"":""Hot""}"
        '    Console.WriteLine($"JSON with null Date:{jsonString}")

        '    ' The null-date JSON deserializes with error if the converter isn't used.
        '    Try
        '        wf = JsonSerializer.Deserialize(Of WeatherForecast)(jsonString)
        '    Catch ex As JsonException
        '        Console.WriteLine($"Exception thrown: {ex.Message}")
        '    End Try

        '    Console.WriteLine("Deserialize with converter")
        '    wf = JsonSerializer.Deserialize(Of WeatherForecast)(jsonString, options)
        '    wf.DisplayPropertyValues()
        'End Sub
    End Class
End Namespace
