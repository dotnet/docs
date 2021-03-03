Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class DeserializeCaseInsensitive

        Public Shared Sub Run()
            Dim jsonString As String = "{
  ""date"": ""2019-08-01T00:00:00-07:00"",
  ""temperatureCelsius"": 25,
  ""summary"": ""Hot""
}"
            Console.WriteLine($"JSON input:{jsonString}")

            ' <Deserialize>
            Dim options As JsonSerializerOptions = New JsonSerializerOptions With {
                .PropertyNameCaseInsensitive = True
            }
            Dim weatherForecast1 = JsonSerializer.Deserialize(Of WeatherForecast)(jsonString, options)
            ' </Deserialize>
            weatherForecast1.DisplayPropertyValues()
        End Sub

    End Class

End Namespace
