'Imports System.Diagnostics
'Imports System.Text.Json
'Imports System.Text.Json.Serialization

'Namespace SystemTextJsonSamples
'    '<Obsolete("Ignore", False)>
'    'Public Class ImmutablePointConverter
'    '    Inherits JsonConverter(Of ImmutablePoint)
'    '    Private ReadOnly _xName As JsonEncodedText = JsonEncodedText.Encode("X")
'    '    Private ReadOnly _yName As JsonEncodedText = JsonEncodedText.Encode("Y")
'    '    Private ReadOnly _intConverter As JsonConverter(Of Integer)

'    '    Public Sub New(options As JsonSerializerOptions)
'    '        Dim TempVar As Boolean = TypeOf options?.GetConverter(GetType(Integer)) Is JsonConverter(Of Integer)
'    '        Dim intConverter As JsonConverter(Of Integer) = CType((options?.GetConverter(GetType(Integer))), JsonConverter(Of Integer))
'    '        If Not TempVar Then Throw New InvalidOperationException
'    '        _intConverter = intConverter
'    '    End Sub
'    '    'Public Overrides Function Read(
'    '    ByRef reader As Utf8JsonReader,
'    '    typeToConvert As Type,
'    '    options As JsonSerializerOptions) As ImmutablePoint
'    '    If reader.TokenType <> JsonTokenType.StartObject Then
'    '        Throw New JsonException
'    '    End If

'    '    Dim x As Integer? = CType(Nothing, Integer?)
'    '    Dim y As Integer? = CType(Nothing, Integer?)

'    '    ' Get the first property.
'    '    reader.Read()
'    '    If reader.TokenType <> JsonTokenType.PropertyName Then
'    '        Throw New JsonException
'    '    End If

'    '    If reader.ValueTextEquals(_xName.EncodedUtf8Bytes) Then
'    '        x = ReadProperty(reader, options)
'    '    ElseIf reader.ValueTextEquals(_yName.EncodedUtf8Bytes) Then
'    '        y = ReadProperty(reader, options)
'    '    Else
'    '        Throw New JsonException
'    '    End If

'    '    ' Get the second property.
'    '    reader.Read()
'    '    If reader.TokenType <> JsonTokenType.PropertyName Then
'    '        Throw New JsonException
'    '    End If

'    '    If x.HasValue AndAlso reader.ValueTextEquals(_yName.EncodedUtf8Bytes) Then
'    '        y = ReadProperty(reader, options)
'    '    ElseIf y.HasValue AndAlso reader.ValueTextEquals(_xName.EncodedUtf8Bytes) Then
'    '        x = ReadProperty(reader, options)
'    '    Else
'    '        Throw New JsonException
'    '    End If

'    '    reader.Read()

'    '    If reader.TokenType <> JsonTokenType.EndObject Then
'    '        Throw New JsonException
'    '    End If

'    '    Return New ImmutablePoint(x.GetValueOrDefault(), y.GetValueOrDefault())
'    'End Function
'    'Private Function ReadProperty(ByRef reader As Utf8JsonReader, options As JsonSerializerOptions) As Integer
'    '    Debug.Assert(reader.TokenType = JsonTokenType.PropertyName)

'    '    reader.Read()
'    '    Return _intConverter.Read(reader, GetType(Integer), options)
'    'End Function
'    Private Sub WriteProperty(writer As Utf8JsonWriter, name As JsonEncodedText, intValue As Integer, options As JsonSerializerOptions)
'            writer.WritePropertyName(name)
'            _intConverter.Write(writer, intValue, options)
'        End Sub
'        Public Overrides Sub Write(
'            writer As Utf8JsonWriter,
'            point As ImmutablePoint,
'            options As JsonSerializerOptions)
'            writer.WriteStartObject()
'            WriteProperty(writer, _xName, point.X, options)
'            WriteProperty(writer, _yName, point.Y, options)
'            writer.WriteEndObject()
'        End Sub
'    End Class
'End Namespace
