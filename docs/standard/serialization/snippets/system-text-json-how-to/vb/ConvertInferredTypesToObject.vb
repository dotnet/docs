Imports System.Text.Json

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    Public NotInheritable Class ConvertInferredTypesToObject
        'Public Shared Sub Run()
        '    Dim jsonString As String

        '    ' Serialize to create input JSON
        '    Dim weatherForecast = WeatherForecastFactories.CreateWeatherForecast()
        '    Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions With
        '    {
        '    .WriteIndented = True}
        '    serializeOptions.WriteIndented = True
        '    jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions)
        '    Console.WriteLine($"JSON input:{jsonString}")

        '    ' Deserialize without converter
        '    ' Properties are JsonElement type.
        '    Dim weatherForecastWithObjectProperties1 As WeatherForecastWithObjectProperties = JsonSerializer.Deserialize(Of WeatherForecastWithObjectProperties)(jsonString)
        '    weatherForecastWithObjectProperties1.DisplayPropertyValues()

        '    ' <Register>
        '    Dim deserializeOptions As JsonSerializerOptions = New JsonSerializerOptions
        '    deserializeOptions.Converters.Add(New ObjectToInferredTypesConverter)
        '    ' </Register>
        '    weatherForecastWithObjectProperties1 = JsonSerializer.Deserialize(Of WeatherForecastWithObjectProperties)(jsonString, deserializeOptions)
        '    weatherForecastWithObjectProperties1.DisplayPropertyValues()
        'End Sub
    End Class
End Namespace
