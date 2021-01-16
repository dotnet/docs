'Imports System.Text.Json
'Imports System.Text.Json.Serialization

'Namespace SystemTextJsonSamples
'    '<Obsolete("Ignore", False)>
'    Public Class TemperatureConverter
'        Inherits JsonConverter(Of Temperature)
'        'Public Overrides Function Read(
'        '    ByRef reader As Utf8JsonReader,
'        '    typeToConvert As Type,
'        '    options As JsonSerializerOptions) As Temperature
'        '    Return Temperature.Parse(reader.GetString())
'        'End Function
'        Public Overrides Sub Write(
'            writer As Utf8JsonWriter,
'            temperature1 As Temperature,
'            options As JsonSerializerOptions)
'            writer.WriteStringValue(temperature1.ToString())
'        End Sub
'    End Class
'End Namespace
