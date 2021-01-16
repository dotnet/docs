Imports System.Text.Json

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    NotInheritable Class RegisterConverterWithAttributeOnType
        Public Shared Sub Run()
            Dim jsonString As String
            Dim weatherForecast As WeatherForecastWithTemperatureStruct = WeatherForecastFactories.CreateWeatherForecastWithTemperatureStruct()
            weatherForecast.DisplayPropertyValues()

            ' <Serialize>
            Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions With
            {
            .WriteIndented = True}
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions)
            ' </Serialize>
            Console.WriteLine($"JSON output:{jsonString}")

            ' <Deserialize>
            weatherForecast = JsonSerializer.Deserialize(Of WeatherForecastWithTemperatureStruct)(jsonString)
            weatherForecast.DisplayPropertyValues()
            ' </Deserialize>
        End Sub
    End Class
End Namespace
