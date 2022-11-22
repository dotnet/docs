Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class SerializePolymorphic

        Public Shared Sub Run()
            Dim jsonString As String
            Dim weatherForecastDerived = WeatherForecastFactories.CreateWeatherForecastDerived()
            Dim weatherForecast1 As WeatherForecast = weatherForecastDerived
            weatherForecast1.DisplayPropertyValues()

            Console.WriteLine("Base class generic type - derived class properties omitted")
            ' <SerializeDefault>
            Dim options As JsonSerializerOptions = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast1, options)
            ' </SerializeDefault>

            Console.WriteLine($"JSON output:{jsonString}")

            Console.WriteLine("Object generic type parameter - derived class properties included")
            ' <SerializeObject>
            options = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(Of Object)(weatherForecast1, options)
            ' </SerializeObject>
            Console.WriteLine($"JSON output:{jsonString}")

            Console.WriteLine("GetType() type parameter - derived class properties included")
            ' <SerializeGetType>
            options = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast1, weatherForecast1.[GetType](), options)
            ' </SerializeGetType>
            Console.WriteLine($"JSON output:{jsonString}")

            Console.WriteLine("Extra properties on interface implementations included only for object properties")
            ' <SerializeInterface>
            Dim forecasts1 As New Forecasts With {
                .Monday = New Forecast With {
                    .[Date] = Date.Parse("2020-01-06"),
                    .TemperatureCelsius = 10,
                    .Summary = "Cool",
                    .WindSpeed = 8
                },
                .Tuesday = New Forecast With {
                    .[Date] = Date.Parse("2020-01-07"),
                    .TemperatureCelsius = 11,
                    .Summary = "Rainy",
                    .WindSpeed = 10
                }
            }

            options = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(forecasts1, options)
            ' </SerializeInterface>
            Console.WriteLine($"{jsonString}")

            Dim weatherForecastWithPrevious1 As WeatherForecastWithPrevious = WeatherForecastFactories.CreateWeatherForecastWithPrevious()
            Dim weatherForecastWithPreviousAsObject1 As WeatherForecastWithPreviousAsObject = WeatherForecastFactories.CreateWeatherForecastWithPreviousAsObject()

            Console.WriteLine("Second level derived class properties included only for object properties")
            ' <SerializeSecondLevel>
            options = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecastWithPreviousAsObject1, options)
            ' </SerializeSecondLevel>
            Console.WriteLine($"JSON output with WindSpeed:{jsonString}")
            jsonString = JsonSerializer.Serialize(
                weatherForecastWithPrevious1,
                options)
            Console.WriteLine($"JSON output without WindSpeed:{jsonString}")

            Dim weatherForecastWithCity As WeatherForecastBase = WeatherForecastFactories.CreateWeatherForecastWithCity()
            Dim weatherForecastBase As WeatherForecastBase = weatherForecastWithCity
            weatherForecastBase.DisplayPropertyValues()

            Console.WriteLine("Polymorphic serialization of derived class properties")
            ' <SerializeWithAttributeAnnotations>
            options = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(WeatherForecastBase, options)
            ' </SerializeWithAttributeAnnotations>
            Console.WriteLine($"JSON output:\n{jsonString}\n")
        End Sub

    End Class

End Namespace
