Imports System.Text.Json

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    'Public NotInheritable Class DeserializeRequiredPropertyUsingAttributeRegistration
    '    Public Shared Sub Run()
    '        Dim jsonString As String
    '        Dim wf = WeatherForecastFactories.CreateWeatherForecastAttrReg()

    '        Dim options As JsonSerializerOptions = New JsonSerializerOptions With
    '        {
    '        .WriteIndented = True}
    '        jsonString = JsonSerializer.Serialize(wf, options)
    '        Console.WriteLine($"JSON with Date:{jsonString}")

    '        wf = JsonSerializer.Deserialize(Of WeatherForecastWithRequiredPropertyConverterAttribute)(
    '            jsonString, options)
    '        wf.DisplayPropertyValues()

    '        jsonString = "{""TemperatureCelsius"": 25,""Summary"":""Hot""}"
    '        Console.WriteLine($"JSON without Date:{jsonString}")

    '        Console.WriteLine("Deserialize with converter")
    '        Try
    '            wf = JsonSerializer.Deserialize(Of WeatherForecastWithRequiredPropertyConverterAttribute)(
    '    jsonString, options)
    '        Catch ex As JsonException
    '            Console.WriteLine($"Exception thrown: {ex.Message}")
    '        End Try
    '        ' wf object is unchanged if exception is thrown.
    '        wf.DisplayPropertyValues()
    '    End Sub
    'End Class
End Namespace
