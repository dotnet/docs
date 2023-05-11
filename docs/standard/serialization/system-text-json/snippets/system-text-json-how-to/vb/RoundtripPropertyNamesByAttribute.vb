Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class RoundtripPropertyNamesByAttribute

        Public Shared Sub Run()
            Dim jsonString As String
            Dim weatherForecast As WeatherForecastWithPropertyNameAttribute = WeatherForecastFactories.CreateWeatherForecastWithPropertyNameAttribute()
            weatherForecast.DisplayPropertyValues()

            ' <Serialize>
            Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions)
            ' </Serialize>
            Console.WriteLine($"JSON output:{jsonString}")

            ' <Deserialize>
            weatherForecast = JsonSerializer.Deserialize(Of WeatherForecastWithPropertyNameAttribute)(jsonString)
            weatherForecast.DisplayPropertyValues()
            ' </Deserialize>
        End Sub

    End Class

End Namespace
