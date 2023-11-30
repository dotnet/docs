Imports System.Text.Json
Imports System.Text.Json.Serialization

Namespace SystemTextJsonSamples

    Public NotInheritable Class RoundtripEnumAsString

        Public Shared Sub Run()
            Dim jsonString As String
            Dim weatherForecast As WeatherForecastWithEnum = WeatherForecastFactories.CreateWeatherForecastWithEnum()
            weatherForecast.DisplayPropertyValues()

            Dim options As JsonSerializerOptions = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast, options)
            Console.WriteLine($"JSON with enum as number:{jsonString}")

            ' <Serialize>
            options = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            options.Converters.Add(New JsonStringEnumConverter(JsonNamingPolicy.CamelCase))
            jsonString = JsonSerializer.Serialize(weatherForecast, options)
            ' </Serialize>
            Console.WriteLine($"JSON with enum as string:{jsonString}")

            ' <Deserialize>
            options = New JsonSerializerOptions
            options.Converters.Add(New JsonStringEnumConverter(JsonNamingPolicy.CamelCase))
            weatherForecast = JsonSerializer.Deserialize(Of WeatherForecastWithEnum)(jsonString, options)
            ' </Deserialize>
            weatherForecast.DisplayPropertyValues()
        End Sub

    End Class

End Namespace
