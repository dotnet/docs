Imports System.IO
Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class RoundtripToFile

        Public Shared Sub Run()
            Dim jsonString As String
            Dim fileName As String = "WeatherForecast.json"
            Dim weatherForecast1 As WeatherForecast = WeatherForecastFactories.CreateWeatherForecast()
            weatherForecast1.DisplayPropertyValues()

            ' <Serialize>
            jsonString = JsonSerializer.Serialize(weatherForecast1)
            File.WriteAllText(fileName, jsonString)
            ' </Serialize>
            Console.WriteLine($"The result is in {fileName}")

            ' <Deserialize>
            jsonString = File.ReadAllText(fileName)
            weatherForecast1 = JsonSerializer.Deserialize(Of WeatherForecast)(jsonString)
            ' </Deserialize>
            weatherForecast1.DisplayPropertyValues()
        End Sub

    End Class

End Namespace
