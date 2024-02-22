Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class ConvertPolymorphic

        Public Shared Sub Run()
            Dim jsonString As String
            Dim weatherForecastDerived = WeatherForecastFactories.CreateWeatherForecastDerived()
            Dim weatherForecast1 As WeatherForecast = weatherForecastDerived
            weatherForecast1.DisplayPropertyValues()

            Console.WriteLine("Base class generic type - derived class properties omitted")
            ' <SerializeDefault>
            Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast1, serializeOptions)
            ' </SerializeDefault>

            Console.WriteLine($"JSON output:{jsonString}")

            Console.WriteLine("Object generic type parameter - derived class properties included")
            ' <SerializeObject>
            serializeOptions = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(Of Object)(weatherForecast1, serializeOptions)
            ' </SerializeObject>
            Console.WriteLine($"JSON output:{jsonString}")

            Console.WriteLine("GetType() type parameter - derived class properties included")
            ' <SerializeGetType>
            serializeOptions = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast1, weatherForecast1.[GetType](), serializeOptions)
            ' </SerializeGetType>
            Console.WriteLine($"JSON output:{jsonString}")
        End Sub

    End Class

End Namespace
