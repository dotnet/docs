' <Usings>
Imports System.Text.Encodings.Web
Imports System.Text.Json
Imports System.Text.Unicode

' </Usings>

Namespace SystemTextJsonSamples

    Public NotInheritable Class SerializeCustomEncoding

        Public Shared Sub Run()
            Dim jsonString As String
            Dim weatherForecast1 As WeatherForecast = WeatherForecastFactories.CreateWeatherForecastCyrillic()
            weatherForecast1.DisplayPropertyValues()

            Console.WriteLine("Default serialization - non-ASCII escaped")
            Dim options As JsonSerializerOptions = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast1, options)
            Console.WriteLine(jsonString)
            Console.WriteLine()

            Console.WriteLine("Serialize language sets unescaped")
            ' <LanguageSets>
            options = New JsonSerializerOptions With {
                .Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast1, options)
            ' </LanguageSets>
            Console.WriteLine(jsonString)
            Console.WriteLine()

            Console.WriteLine("Serialize selected unescaped characters")
            ' <SelectedCharacters>
            Dim encoderSettings As TextEncoderSettings = New TextEncoderSettings
            encoderSettings.AllowCharacters(ChrW(&H436), ChrW(&H430))
            encoderSettings.AllowRange(UnicodeRanges.BasicLatin)
            options = New JsonSerializerOptions With {
                .Encoder = JavaScriptEncoder.Create(encoderSettings),
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast1, options)
            ' </SelectedCharacters>
            Console.WriteLine(jsonString)
            Console.WriteLine()

            Console.WriteLine("Serialize using unsafe relaxed encoder")
            ' <UnsafeRelaxed>
            options = New JsonSerializerOptions With {
                .Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast1, options)
            ' </UnsafeRelaxed>
            Console.WriteLine(jsonString)
        End Sub

    End Class

End Namespace
