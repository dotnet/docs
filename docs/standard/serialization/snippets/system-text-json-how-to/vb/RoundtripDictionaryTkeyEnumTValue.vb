Imports System.Text.Json

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    Public NotInheritable Class RoundtripDictionaryTkeyEnumTValue
        'Public Shared Sub Run()
        '    Dim jsonString As String

        '    Dim weatherForecast As WeatherForecastWithEnumDictionary = WeatherForecastFactories.CreateWeatherForecastWithEnumDictionary()

        '    ' <Register>
        '    Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions
        '    serializeOptions.Converters.Add(New DictionaryTKeyEnumTValueConverter)
        '    ' </Register>
        '    serializeOptions.WriteIndented = True
        '    jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions)
        '    Console.WriteLine($"JSON output:{jsonString}")

        '    ' <Deserialize>
        '    Dim deserializeOptions As JsonSerializerOptions = New JsonSerializerOptions
        '    deserializeOptions.Converters.Add(New DictionaryTKeyEnumTValueConverter)
        '    weatherForecast = JsonSerializer.Deserialize(Of WeatherForecastWithEnumDictionary)(
        '        jsonString, deserializeOptions)
        '    ' </Deserialize>
        '    weatherForecast.DisplayPropertyValues()
        'End Sub
    End Class
End Namespace
