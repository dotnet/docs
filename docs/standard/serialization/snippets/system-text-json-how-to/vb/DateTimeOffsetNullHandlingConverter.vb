Imports System.Text.Json
Imports System.Text.Json.Serialization

Namespace SystemTextJsonSamples
    <Obsolete("Ignore obsolete", False)>
    Public Class DateTimeOffsetNullHandlingConverter
        Inherits JsonConverter(Of DateTimeOffset)
        Public Overrides Function Read(
            ByRef reader As Utf8JsonReader,
            typeToConvert As Type,
            options As JsonSerializerOptions) As DateTimeOffset
            Return If(reader.TokenType = JsonTokenType.Null, CType(Nothing, DateTimeOffset) _
                , reader.GetDateTimeOffset())
        End Function
        Public Overrides Sub Write(
            writer As Utf8JsonWriter,
            dateTimeValue As DateTimeOffset,
            options As JsonSerializerOptions)
            writer.WriteStringValue(dateTimeValue)
        End Sub
    End Class
End Namespace
