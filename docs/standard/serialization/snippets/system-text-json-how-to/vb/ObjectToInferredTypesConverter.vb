'Imports System.Text.Json
'Imports System.Text.Json.Serialization

'Namespace SystemTextJsonSamples
'    '<Obsolete("Ignore", False)>
'    Public Class ObjectToInferredTypesConverter
'        Inherits JsonConverter(Of Object)
'        'Public Overrides Function Read(
'        '    ByRef reader As Utf8JsonReader,
'        '    typeToConvert As Type,
'        '    options As JsonSerializerOptions) As Object

'        '    Dim l As Long
'        '    If reader.TokenType = JsonTokenType.Number Then
'        '        If reader.TryGetInt64(l) Then
'        '            Return l
'        '        Else
'        '            Return reader.GetDouble()
'        '        End If
'        '    End If
'        '    If reader.TokenType = JsonTokenType.String Then
'        '            Dim datetime As Date
'        '            If reader.TryGetDateTime(datetime) Then
'        '                Return datetime
'        '            End If
'        '            Return reader.GetString()
'        '        End If
'        '        Select Case reader.TokenType
'        '        Case = JsonTokenType.True
'        '            Return True
'        '        Case = JsonTokenType.False
'        '            Return False
'        '    End Select

'        '    Return JsonDocument.ParseValue(reader).RootElement.Clone()
'        'End Function
'        Public Overrides Sub Write(
'            writer As Utf8JsonWriter,
'            objectToWrite As Object,
'            options As JsonSerializerOptions)
'            Throw New InvalidOperationException("Should not get here.")
'        End Sub
'    End Class
'End Namespace
