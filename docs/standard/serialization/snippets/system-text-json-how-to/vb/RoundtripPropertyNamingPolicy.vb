Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class RoundtripPropertyNamingPolicy

        Public Shared Sub Run()
            Dim jsonString As String
            Dim weatherForecast1 As WeatherForecast = WeatherForecastFactories.CreateWeatherForecast()
            weatherForecast1.DisplayPropertyValues()

            ' <Serialize>
            Dim options As JsonSerializerOptions = New JsonSerializerOptions With {
                .PropertyNamingPolicy = New UpperCaseNamingPolicy,
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast1, options)
            ' </Serialize>
            Console.WriteLine($"JSON output:{jsonString}")

            ' <Deserialize>
            options = New JsonSerializerOptions With {
                .PropertyNamingPolicy = New UpperCaseNamingPolicy
            }
            weatherForecast1 = JsonSerializer.Deserialize(Of WeatherForecast)(jsonString, options)
            ' </Deserialize>
            weatherForecast1.DisplayPropertyValues()
        End Sub

    End Class

End Namespace
