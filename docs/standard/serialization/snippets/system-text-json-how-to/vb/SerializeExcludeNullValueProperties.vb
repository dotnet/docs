Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class SerializeExcludeNullValueProperties

        Public Shared Sub Run()
            Dim jsonString As String
            Dim weatherForecast1 As WeatherForecast = WeatherForecastFactories.CreateWeatherForecast()
            weatherForecast1.Summary = Nothing
            weatherForecast1.DisplayPropertyValues()

            ' <Serialize>
            Dim options As JsonSerializerOptions = New JsonSerializerOptions With {
                .IgnoreNullValues = True,
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast1, options)
            ' </Serialize>
            Console.WriteLine(jsonString)
            Console.WriteLine()
        End Sub

    End Class

End Namespace
