Imports System.Text.Json

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    Public NotInheritable Class DeserializeInferredTypesToObject
        'Public Shared Sub Run()
        '    Dim jsonString As String

        '    ' Serialize to create input JSON
        '    Dim weatherForecast1 As WeatherForecast = WeatherForecastFactories.CreateWeatherForecast()
        '    Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions With
        '    {
        '    .WriteIndented = True}
        '    jsonString = JsonSerializer.Serialize(weatherForecast1, serializeOptions)
        '    Console.WriteLine($"JSON input:{jsonString}")

        '    ' Deserialize without converter
        '    ' Properties are JsonElement type.
        '    Dim weatherForecastWithObjectProperties As WeatherForecastWithObjectProperties = JsonSerializer.Deserialize(Of WeatherForecastWithObjectProperties)(jsonString)
        '    weatherForecastWithObjectProperties.DisplayPropertyValues()

        '    ' <Register>
        '    Dim deserializeOptions As JsonSerializerOptions = New JsonSerializerOptions
        '    deserializeOptions.Converters.Add(New ObjectToInferredTypesConverter)
        '    ' </Register>
        '    weatherForecastWithObjectProperties = JsonSerializer.Deserialize(Of WeatherForecastWithObjectProperties)(jsonString, deserializeOptions)
        '    weatherForecastWithObjectProperties.DisplayPropertyValues()
        'End Sub
    End Class
End Namespace
