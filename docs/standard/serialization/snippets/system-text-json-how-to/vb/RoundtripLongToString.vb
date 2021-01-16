Imports System.Text.Json

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    Public NotInheritable Class RoundtripLongToString
        'Public Shared Sub Run()
        '    ' Serialize to create input JSON
        '    Dim weatherForecast As WeatherForecastWithLong = WeatherForecastFactories.CreateWeatherForecastWithLong()
        '    Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions With
        '    {
        '    .WriteIndented = True}
        '    Dim jsonString As String = JsonSerializer.Serialize(weatherForecast, serializeOptions)
        '    Console.WriteLine($"JSON output:{jsonString}")

        '    weatherForecast = JsonSerializer.Deserialize(Of WeatherForecastWithLong)(jsonString)
        '    weatherForecast.DisplayPropertyValues()
        'End Sub
    End Class
End Namespace
