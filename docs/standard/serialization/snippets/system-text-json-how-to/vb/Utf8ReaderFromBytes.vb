'Imports System.Text.Json

'Namespace SystemTextJsonSamples
'    '<Obsolete("Ignore", False)>
'    Public NotInheritable Class Utf8ReaderFromBytes
'        Public Shared Sub Run()
'            Dim weatherForecast1 As WeatherForecast = WeatherForecastFactories.CreateWeatherForecast()
'            Dim jsonUtf8Bytes As Byte() = JsonSerializer.SerializeToUtf8Bytes(
'                weatherForecast1,
'                New JsonSerializerOptions With
'{
'                .WriteIndented = True})

'            ' <Deserialize>
'            Dim options As JsonReaderOptions = New JsonReaderOptions With
'            {
'            .AllowTrailingCommas = True,
'            .CommentHandling = JsonCommentHandling.Skip}
'            Dim reader As Utf8JsonReader = New Utf8JsonReader(jsonUtf8Bytes, options)

'            While reader.Read()
'                Console.Write(reader.TokenType)

'                Select Case reader.TokenType
'                    Case JsonTokenType.PropertyName, JsonTokenType.[String]
'                        Dim text As String = reader.GetString()
'                        Console.Write(" ")
'                        Console.Write(text)
'                        Exit Select

'                    Case JsonTokenType.Number
'                        Dim intValue As Integer = reader.GetInt32()
'                        Console.Write(" ")
'                        Console.Write(intValue)
'                        Exit Select

'                        ' Other token types elided for brevity
'                End Select
'                Console.WriteLine()
'            End While
'            ' </Deserialize>
'        End Sub
'    End Class
'End Namespace
