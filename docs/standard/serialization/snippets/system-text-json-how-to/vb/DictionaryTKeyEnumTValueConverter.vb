'Imports System.Reflection
'Imports System.Text.Json
'Imports System.Text.Json.Serialization

'Namespace SystemTextJsonSamples

'    '<Obsolete("Ignore", False)>
'    Public Class DictionaryTKeyEnumTValueConverter
'        Inherits JsonConverterFactory

'        Public Overrides Function CanConvert(typeToConvert As Type) As Boolean
'            If Not typeToConvert.IsGenericType Then
'                Return False
'            End If

'            If typeToConvert.GetGenericTypeDefinition() IsNot GetType(Dictionary(Of ,)) Then
'                Return False
'            End If

'            Return typeToConvert.GetGenericArguments()(0).IsEnum
'        End Function

'        Public Overrides Function CreateConverter(
'            type1 As Type,
'            options As JsonSerializerOptions) As JsonConverter
'            Dim keyType As Type = type1.GetGenericArguments()(0)
'            Dim valueType As Type = type1.GetGenericArguments()(1)

'            Dim converter As JsonConverter = CType(Activator.CreateInstance(
'                GetType(DictionaryEnumConverterInner(Of ,)).MakeGenericType(
'                    New Type() {keyType, valueType}),
'                BindingFlags.Instance Or BindingFlags.[Public],
'                binder:=Nothing,
'                args:=New Object() {options},
'                culture:=Nothing), JsonConverter)

'            Return converter
'        End Function

'        Private Class DictionaryEnumConverterInner(Of TKey As Structure, TValue)
'            Inherits JsonConverter(Of Dictionary(Of TKey, TValue))
'            Private ReadOnly _valueConverter As JsonConverter(Of TValue)
'            Private ReadOnly _keyType As Type
'            Private ReadOnly _valueType As Type

'            Public Sub New(options As JsonSerializerOptions)
'                ' For performance, use the existing converter if available.
'                _valueConverter = CType(options _
'                    .GetConverter(GetType(TValue)), JsonConverter(Of TValue))

'                ' Cache the key and value types.
'                _keyType = GetType(TKey)
'                _valueType = GetType(TValue)
'            End Sub

'            'Public Overrides Function Read(
'            '    ByRef reader As Utf8JsonReader,
'            '    typeToConvert As Type,
'            '    options As JsonSerializerOptions) As Dictionary(Of TKey, TValue)
'            '    If reader.TokenType <> JsonTokenType.StartObject Then
'            '        Throw New JsonException
'            '    End If

'            '    Dim dictionary1 As Dictionary(Of TKey, TValue) = New Dictionary(Of TKey, TValue)

'            '    While reader.Read()
'            '        If reader.TokenType = JsonTokenType.EndObject Then
'            '            Return dictionary1
'            '        End If

'            '        ' Get the key.
'            '        If reader.TokenType <> JsonTokenType.PropertyName Then
'            '            Throw New JsonException
'            '        End If

'            '        Dim propertyName As String = reader.GetString()
'            '        Dim key As TKey = Nothing

'            '        If Not [Enum].TryParse(propertyName, ignoreCase:=False, key) AndAlso
'            '            Not [Enum].TryParse(propertyName, ignoreCase:=True, key) Then
'            '            Throw New JsonException($"Unable to convert """"{propertyName}"""" to Enum """"{_keyType}""."".")
'            '        End If

'            '        ' Get the value.
'            '        Dim value As TValue
'            '        If _valueConverter IsNot Nothing Then
'            '            reader.Read()
'            '            value = _valueConverter.Read(reader, _valueType, options)
'            '        Else
'            '            value = JsonSerializer.Deserialize(Of TValue)(reader, options)
'            '        End If

'            '        ' Add to dictionary.
'            '        dictionary1.Add(key, value)
'            '    End While

'            '    Throw New JsonException
'            'End Function

'            Public Overrides Sub Write(
'                writer As Utf8JsonWriter,
'                dictionary1 As Dictionary(Of TKey, TValue),
'                options As JsonSerializerOptions)
'                writer.WriteStartObject()
'                ' TODO: Visual Basic does not support For Each Variable statement.
'                ' Original statement:
'                ' foreach ((TKey key, TValue value) in dictionary)
'                '                 {
'                '                     var propertyName = key.ToString();
'                '                     writer.WritePropertyName
'                '                         (options.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);
'                '
'                '                     if (_valueConverter != null)
'                '                     {
'                '                         _valueConverter.Write(writer, value, options);
'                '                     }
'                '                     else
'                '                     {
'                '                         JsonSerializer.Serialize(writer, value, options);
'                '                     }
'                '                 }

'                writer.WriteEndObject()
'            End Sub

'        End Class

'    End Class

'End Namespace
