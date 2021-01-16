'Imports System.Globalization
'Imports System.Text.Json
'Imports System.Text.Json.Serialization

'Namespace SystemTextJsonSamples
'    '<Obsolete("Ignore", False)>
'    Public Class DateTimeOffsetConverter
'        Inherits JsonConverter(Of DateTimeOffset)
'        'Public Overrides Function Read(
'        '    ByRef reader As Utf8JsonReader,
'        '    typeToConvert As Type,
'        '    options As JsonSerializerOptions) As DateTimeOffset
'        '    Return DateTimeOffset.ParseExact(reader.GetString(),
'        '        "MM/dd/yyyy", CultureInfo.InvariantCulture)
'        'End Function
'        Public Overrides Sub Write(
'            writer As Utf8JsonWriter,
'            dateTimeValue As DateTimeOffset,
'            options As JsonSerializerOptions)
'            writer.WriteStringValue(dateTimeValue.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture))
'        End Sub
'    End Class
'End Namespace
