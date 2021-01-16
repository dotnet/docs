'Imports System.Collections.Generic
'Imports System.Diagnostics
'Imports System.Reflection
'Imports System.Text.Json
'Imports System.Text.Json.Serialization

'Namespace SystemTextJsonSamples
'    Public Class JsonConverterFactoryForStackOfT
'        Inherits JsonConverterFactory
'        Public Overrides Function CanConvert(typeToConvert As Type) As Boolean
'            Return typeToConvert.IsGenericType _
'                        AndAlso typeToConvert.GetGenericTypeDefinition() Is GetType(Stack())
'        End Function
'        Public Overrides Function CreateConverter( _
'            typeToConvert As Type, options As JsonSerializerOptions) As JsonConverter
'            Debug.Assert(typeToConvert.IsGenericType AndAlso _
'                typeToConvert.GetGenericTypeDefinition() Is GetType(Stack()))

'            Dim elementType As Type = typeToConvert.GetGenericArguments()(0)

'            Dim converter As JsonConverter = CType(Activator.CreateInstance(
'                GetType(JsonConverterForStackOfT(Of Object)).MakeGenericType(New Type() {elementType}),
'                BindingFlags.Instance Or BindingFlags.[Public],
'                binder:=Nothing,
'                args:=Nothing,
'                culture:=Nothing), JsonConverter)

'            Return converter
'        End Function
'    End Class



'    Public Class JsonConverterForStackOfT(Of T)
'        Inherits JsonConverter(Of Stack(Of T))
'        '<Obsolete("Ignore", False)>
'        'Public Overrides Function Read(
'        '    ByRef reader As Utf8JsonReader, typeToConvert As Type, options As JsonSerializerOptions) As Stack(Of T)
'        '    If reader.TokenType <> JsonTokenType.StartArray Then
'        '        Throw New JsonException
'        '    End If
'        '    reader.Read()

'        '    Dim elements As Stack(Of T) = New Stack(Of T)

'        '    While reader.TokenType <> JsonTokenType.EndArray
'        '        elements.Push(JsonSerializer.Deserialize(Of T)(reader, options))

'        '        reader.Read()
'        '    End While

'        '    Return elements
'        'End Function
'        Public Overrides Sub Write( _
'            writer As Utf8JsonWriter, value As Stack(Of T), options As JsonSerializerOptions)
'            writer.WriteStartArray()

'            Dim reversed As Stack(Of T) = New Stack(Of T)(value)

'            For Each item As T In reversed
'                JsonSerializer.Serialize(writer, item, options)
'            Next

'            writer.WriteEndArray()
'        End Sub
'    End Class
'End Namespace
