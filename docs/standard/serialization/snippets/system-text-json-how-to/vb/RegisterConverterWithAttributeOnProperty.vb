Imports System.Text.Json

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    Public NotInheritable Class RegisterConverterWithAttributeOnProperty

        'Public Shared Sub Run()
        '    Dim jsonString As String
        '    Dim weatherForecast As WeatherForecastWithConverterAttribute = WeatherForecastFactories.CreateWeatherForecastWithConverterAttribute()
        '    weatherForecast.DisplayPropertyValues()

        '    ' <Serialize>
        '    Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions With
        '    {
        '    .WriteIndented = True}
        '    jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions)
        '    ' </Serialize>
        '    Console.WriteLine($"JSON output:{jsonString}")

        '    ' <Deserialize>
        '    weatherForecast = JsonSerializer.Deserialize(Of WeatherForecastWithConverterAttribute)(jsonString)
        '    ' </Deserialize>
        '    weatherForecast.DisplayPropertyValues()
        'End Sub
    End Class
End Namespace
