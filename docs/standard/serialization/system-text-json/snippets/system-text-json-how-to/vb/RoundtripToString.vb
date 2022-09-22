Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class RoundtripToString

        Public Shared Sub Run()
            Dim weatherForecast As WeatherForecastWithPOCOs = WeatherForecastFactories.CreateWeatherForecastWithPOCOs()
            weatherForecast.DisplayPropertyValues()

            ' <Serialize>
            Dim jsonString As String
            ' </Serialize>

            ' <SerializeWithGenericParameter>
            jsonString = JsonSerializer.Serialize(Of WeatherForecastWithPOCOs)(weatherForecast)
            ' </SerializeWithGenericParameter>

            Console.WriteLine($"JSON output:{jsonString}")

            ' <SerializePrettyPrint>
            Dim options As JsonSerializerOptions = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast, options)
            ' </SerializePrettyPrint>
            Console.WriteLine($"Pretty-printed JSON output:{jsonString}")

            ' <Deserialize>
            weatherForecast = JsonSerializer.Deserialize(Of WeatherForecastWithPOCOs)(jsonString)
            ' </Deserialize>
            weatherForecast.DisplayPropertyValues()
        End Sub

    End Class

End Namespace
