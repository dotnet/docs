'Imports System.Text.Json
'Imports System.Text.Json.Serialization

'Namespace SystemTextJsonSamples
'    '<Obsolete("Ignore", False)>
'    Public Class WeatherForecastRequiredPropertyConverterForAttributeRegistration
'        Inherits JsonConverter(Of WeatherForecastWithRequiredPropertyConverterAttribute)
'        'Public Overrides Function Read(
'        '    ByRef reader As Utf8JsonReader,
'        '    type1 As Type,
'        '    options As JsonSerializerOptions) As WeatherForecastWithRequiredPropertyConverterAttribute
'        '    ' OK to pass in options when recursively calling Deserialize.
'        '    Dim forecast As WeatherForecastWithRequiredPropertyConverterAttribute = JsonSerializer.Deserialize(Of WeatherForecastWithoutRequiredPropertyConverterAttribute)(
'        '            reader,
'        '            options)
'        '    If forecast.Date = Nothing Then Throw New JsonException("Required property not received in the JSON")
'        '    Return forecast
'        'End Function
'        Public Overrides Sub Write(
'            writer As Utf8JsonWriter,
'            forecast As WeatherForecastWithRequiredPropertyConverterAttribute,
'            options As JsonSerializerOptions)
'            Dim weatherForecastWithoutConverterAttributeOnClass As New WeatherForecastWithoutRequiredPropertyConverterAttribute With
'                {
'            .[Date] = forecast.[Date],
'            .TemperatureCelsius = forecast.TemperatureCelsius,
'            .Summary = forecast.Summary}

'            ' OK to pass in options when recursively calling Serialize.
'            JsonSerializer.Serialize(
'                writer,
'                weatherForecastWithoutConverterAttributeOnClass,
'                options)
'        End Sub
'    End Class
'End Namespace
