Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class DeserializeCommasComments

        Public Shared Sub Run()
            Dim jsonString As String = "{
  ""Date"": ""2019-08-01T00:00:00-07:00"",
  ""TemperatureC"": 25, // Fahrenheit 77
  ""Summary"": ""Hot"", /* Zharko */
  // Comments on
  /* separate lines */
}"
            Console.WriteLine($"JSON input:{jsonString}")

            ' <Deserialize>
            Dim options As JsonSerializerOptions = New JsonSerializerOptions With {
                .ReadCommentHandling = JsonCommentHandling.Skip,
                .AllowTrailingCommas = True
            }
            Dim weatherForecast1 = JsonSerializer.Deserialize(Of WeatherForecast)(jsonString, options)
            ' </Deserialize>
            weatherForecast1.DisplayPropertyValues()
        End Sub

    End Class

End Namespace
