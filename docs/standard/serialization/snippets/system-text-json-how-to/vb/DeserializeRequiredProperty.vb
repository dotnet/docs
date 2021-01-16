Imports System.Text.Json

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    Public NotInheritable Class DeserializeRequiredProperty
        'Public Shared Sub Run()
        '    Dim jsonString As String
        '    Dim wf = WeatherForecastFactories.CreateWeatherForecast()

        '    Dim options As JsonSerializerOptions = New JsonSerializerOptions With {.WriteIndented = True}
        '    options.Converters.Add(New WeatherForecastRequiredPropertyConverter)
        '    jsonString = JsonSerializer.Serialize(wf, options)
        '    Console.WriteLine($"JSON with Date:{jsonString}")

        '    wf = JsonSerializer.Deserialize(Of WeatherForecast)(jsonString, options)
        '    wf.DisplayPropertyValues()

        '    jsonString = "{""TemperatureCelsius"": 25,""Summary"":""Hot""}"
        '    Console.WriteLine($"JSON without Date:{jsonString}")

        '    ' The missing-date JSON deserializes without error if the converter isn't used.
        '    Console.WriteLine("Deserialize without converter")
        '    wf = JsonSerializer.Deserialize(Of WeatherForecast)(jsonString)
        '    wf.DisplayPropertyValues()

        '    Console.WriteLine("Deserialize with converter")
        '    Try
        '        wf = JsonSerializer.Deserialize(Of WeatherForecast)(jsonString, options)
        '    Catch ex As JsonException
        '        Console.WriteLine($"Exception thrown: {ex.Message}")
        '    End Try
        '    ' wf object is unchanged if exception is thrown.
        '    wf.DisplayPropertyValues()
        'End Sub
    End Class
End Namespace
