Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class RoundtripCamelCasePropertyNames

        Public Shared Sub Run()
            Dim jsonString As String
            Dim weatherForecast As WeatherForecastWithPropertyNameAttribute = WeatherForecastFactories.CreateWeatherForecastWithPropertyNameAttribute()
            weatherForecast.DisplayPropertyValues()

            ' <Serialize>
            Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions With {
                .PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions)
            ' </Serialize>
            Console.WriteLine($"JSON output:{jsonString}")

            ' <Deserialize>
            Dim deserializeOptions As JsonSerializerOptions = New JsonSerializerOptions With {
                .PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }
            weatherForecast = JsonSerializer.Deserialize(Of WeatherForecastWithPropertyNameAttribute)(
                    jsonString, deserializeOptions)
            ' </Deserialize>
            weatherForecast.DisplayPropertyValues()
        End Sub

    End Class

End Namespace
