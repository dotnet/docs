Imports System.Text.Json

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    'Public NotInheritable Class ConvertDictionaryTkeyEnumTValue
    '    Public Shared Sub Run()
    '        Dim jsonString As String

    '        Dim weatherForecast = WeatherForecastFactories.CreateWeatherForecastWithEnumDictionary()

    '        ' <Register>
    '        Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions With {.WriteIndented = True}
    '        serializeOptions.Converters.Add(New DictionaryTKeyEnumTValueConverter)
    '        ' </Register>
    '        jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions)
    '        Console.WriteLine($"JSON output:{jsonString}")

    '        ' <Deserialize>
    '        Dim deserializeOptions As JsonSerializerOptions = New JsonSerializerOptions
    '        deserializeOptions.Converters.Add(New DictionaryTKeyEnumTValueConverter)
    '        weatherForecast = JsonSerializer.Deserialize(Of WeatherForecastWithEnumDictionary)(jsonString, deserializeOptions)
    '        ' </Deserialize>
    '        weatherForecast.DisplayPropertyValues()
    '    End Sub
    'End Class
End Namespace
