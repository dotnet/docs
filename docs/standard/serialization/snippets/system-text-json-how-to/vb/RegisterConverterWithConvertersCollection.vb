Imports System.Text.Json

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    Public NotInheritable Class RegisterConverterWithConverterscollection
        'Public Shared Sub Run()
        '    Dim jsonString As String
        '    Dim weatherForecast1 As WeatherForecast = WeatherForecastFactories.CreateWeatherForecast()
        '    weatherForecast1.DisplayPropertyValues()

        '    ' <Serialize>
        '    Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions With
        '    {
        '    .WriteIndented = True}
        '    serializeOptions.Converters.Add(New DateTimeOffsetConverter)

        '    jsonString = JsonSerializer.Serialize(weatherForecast1, serializeOptions)
        '    ' </Serialize>
        '    Console.WriteLine($"JSON output:{jsonString}")

        '    ' <Deserialize>
        '    Dim deserializeOptions As JsonSerializerOptions = New JsonSerializerOptions
        '    deserializeOptions.Converters.Add(New DateTimeOffsetConverter)
        '    weatherForecast1 = JsonSerializer.Deserialize(Of WeatherForecast)(jsonString, deserializeOptions)
        '    ' </Deserialize>
        '    weatherForecast1.DisplayPropertyValues()
        'End Sub
    End Class
End Namespace
