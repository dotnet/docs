Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class SerializeCamelCaseDictionaryKeys

        Public Shared Sub Run()
            Dim jsonString As String
            Dim weatherForecast As WeatherForecastWithDictionary = WeatherForecastFactories.CreateWeatherForecastWithDictionary()
            weatherForecast.DisplayPropertyValues()

            ' <Serialize>
            Dim options As JsonSerializerOptions = New JsonSerializerOptions With {
                .DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast, options)
            ' </Serialize>
            Console.WriteLine($"JSON output:{jsonString}")

            ' <Deserialize>
            weatherForecast = JsonSerializer.Deserialize(Of WeatherForecastWithDictionary)(jsonString)
            ' </Deserialize>
            weatherForecast.DisplayPropertyValues()
        End Sub

    End Class

End Namespace
