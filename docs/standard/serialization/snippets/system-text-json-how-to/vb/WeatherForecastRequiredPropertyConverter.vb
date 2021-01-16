'Imports System.Text.Json
'Imports System.Text.Json.Serialization

'Namespace SystemTextJsonSamples
'    '<Obsolete("Ignore", False)>
'    Public Class WeatherForecastRequiredPropertyConverter
'        Inherits JsonConverter(Of WeatherForecast)
'        'Public Overrides Function Read(
'        '    ByRef reader As Utf8JsonReader,
'        '    type1 As Type,
'        '    options As JsonSerializerOptions) As WeatherForecast
'        '    ' Don't pass in options when recursively calling Deserialize.
'        '    Dim forecast As WeatherForecast = JsonSerializer.Deserialize(Of WeatherForecast)(reader)
'        '    If forecast.Date = Nothing Then Throw New JsonException("Required property not received in the JSON")
'        '    Return forecast
'        'End Function
'        Public Overrides Sub Write(
'            writer As Utf8JsonWriter,
'            forecast As WeatherForecast, options As JsonSerializerOptions)
'            ' Don't pass in options when recursively calling Serialize.
'            JsonSerializer.Serialize(writer, forecast)
'        End Sub
'    End Class
'End Namespace
