Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class SerializeExcludePropertiesByAttribute

        Public Shared Sub Run()
            Dim jsonString As String
            Dim weatherForecast As WeatherForecastWithIgnoreAttribute = WeatherForecastFactories.CreateWeatherForecastWithIgnoreAttribute()
            weatherForecast.DisplayPropertyValues()

            ' <Serialize>
            Dim options As JsonSerializerOptions = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast, options)
            ' </Serialize>
            Console.WriteLine(jsonString)
            Console.WriteLine()
        End Sub

    End Class

End Namespace
