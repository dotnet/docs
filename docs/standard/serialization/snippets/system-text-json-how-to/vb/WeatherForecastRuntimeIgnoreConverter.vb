'Imports System.Text.Json
'Imports System.Text.Json.Serialization

'Namespace SystemTextJsonSamples
'    '<Obsolete("Ignore", False)>
'    Public Class WeatherForecastRuntimeIgnoreConverter
'        Inherits JsonConverter(Of WeatherForecast)
'        'Public Overrides Function Read(
'        '    ByRef reader As Utf8JsonReader,
'        '    typeToConvert As Type,
'        '    options As JsonSerializerOptions) As WeatherForecast
'        '    If reader.TokenType <> JsonTokenType.StartObject Then
'        '        Throw New JsonException
'        '    End If

'        '    Dim wf As New WeatherForecast

'        '    While reader.Read()
'        '        If reader.TokenType = JsonTokenType.EndObject Then
'        '            Return wf
'        '        End If

'        '        If reader.TokenType = JsonTokenType.PropertyName Then
'        '            Dim propertyName1 As String = reader.GetString()
'        '            reader.Read()
'        '            Select Case propertyName1
'        '                Case "Date"
'        '                    Dim [date] As DateTimeOffset = reader.GetDateTimeOffset()
'        '                    wf.[Date] = [date]
'        '                Case "TemperatureCelsius"
'        '                    Dim temperatureCelsius As Integer = reader.GetInt32()
'        '                    wf.TemperatureCelsius = temperatureCelsius
'        '                Case "Summary"
'        '                    Dim summary As String = reader.GetString()
'        '                    wf.Summary = If(String.IsNullOrWhiteSpace(summary), "N/A", summary)
'        '            End Select
'        '        End If
'        '    End While

'        '    Throw New JsonException
'        'End Function
'        Public Overrides Sub Write(writer As Utf8JsonWriter, wf As WeatherForecast, options As JsonSerializerOptions)
'            writer.WriteStartObject()

'            writer.WriteString("Date", wf.[Date])
'            writer.WriteNumber("TemperatureCelsius", wf.TemperatureCelsius)
'            If Not String.IsNullOrWhiteSpace(wf.Summary) AndAlso wf.Summary <> "N/A" Then
'                writer.WriteString("Summary", wf.Summary)
'            End If

'            writer.WriteEndObject()
'        End Sub
'    End Class
'End Namespace
