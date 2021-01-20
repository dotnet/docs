Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class DeserializeIgnoreNull

        Public Shared Sub Run()
            Dim jsonString As String = "{
  ""Date"": ""2019-08-01T00:00:00-07:00"",
  ""TemperatureCelsius"": 25,
  ""Summary"": null
}"
            Console.WriteLine($"JSON input:{jsonString}")

            ' Deserialize default behavior
            Dim weatherForecast = JsonSerializer.Deserialize(Of WeatherForecastWithDefault)(jsonString)
            weatherForecast.DisplayPropertyValues()

            ' <Deserialize>
            Dim options As JsonSerializerOptions = New JsonSerializerOptions With {
                .IgnoreNullValues = True
            }
            weatherForecast = JsonSerializer.Deserialize(Of WeatherForecastWithDefault)(jsonString, options)
            ' </Deserialize>
            weatherForecast.DisplayPropertyValues()
        End Sub

    End Class

End Namespace
