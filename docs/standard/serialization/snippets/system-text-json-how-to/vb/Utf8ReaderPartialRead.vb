'Imports System.IO
'Imports System.Text
'Imports System.Text.Json

'Namespace SystemTextJsonSamples
'    '<Obsolete("Ignore", False)>
'    Public NotInheritable Class Utf8ReaderPartialRead
'        Public Shared Sub Run()
'            Dim jsonString As String = "{
'                ""Date"": ""2019-08-01T00:00:00-07:00"",
'                ""Temperature"": 25,
'                ""TemperatureRanges"": {
'                    ""Cold"": { ""High"": 20, ""Low"": -10 },
'                    ""Hot"": { ""High"": 60, ""Low"": 20 }
'                },
'                ""Summary"": ""Hot"",
'            }""date"": ""2019-08-01T00:00:00-07:00"",
'                ""Temperature"": 25,
'                ""TemperatureRanges"": {
'                    ""Cold"": { ""High"": 20, ""Low"": -10 },
'                    ""Hot"": { ""High"": 60, ""Low"": 20 }
'                },
'                ""Summary"": ""Hot"",
'            }"

'            Dim bytes As Byte() = Encoding.UTF8.GetBytes(jsonString)
'            Dim stream As MemoryStream = New MemoryStream(bytes)

'            Dim buffer As Byte() = New Byte(4095) {}

'            ' Fill the buffer.
'            ' For this snippet, we're assuming the stream is open and has data.
'            ' If it might be closed or empty, check if the return value is 0.
'            stream.Read(buffer)

'            Dim reader As Utf8JsonReader = New Utf8JsonReader(buffer, isFinalBlock:=False, state:=Nothing)
'            Console.WriteLine($"String in buffer is: {Encoding.UTF8.GetString(buffer)}")

'            ' Search for "Summary" property name
'            While reader.TokenType <> JsonTokenType.PropertyName OrElse Not reader.ValueTextEquals("Summary")
'                If Not reader.Read() Then
'                    ' Not enough of the JSON is in the buffer to complete a read.
'                    GetMoreBytesFromStream(stream, buffer, reader)
'                End If
'            End While

'            ' Found the "Summary" property name.
'            Console.WriteLine($"String in buffer is: {Encoding.UTF8.GetString(buffer)}")
'            While Not reader.Read()
'                ' Not enough of the JSON is in the buffer to complete a read.
'                GetMoreBytesFromStream(stream, buffer, reader)
'            End While
'            ' Display value of Summary property, that is, "Hot".
'            Console.WriteLine($"Got property value: {reader.GetString()}")
'        End Sub
'        Private Shared Sub GetMoreBytesFromStream(
'            stream As MemoryStream, ByRef buffer As Byte(), ByRef reader As Utf8JsonReader)
'            Dim bytesRead As Integer
'            If reader.BytesConsumed < buffer.Length Then
'                Dim leftover As ReadOnlySpan(Of Byte) = buffer.AsSpan(CInt(Fix(reader.BytesConsumed)))

'                If leftover.Length = buffer.Length Then
'                    Array.Resize(buffer, buffer.Length * 2)
'                    Console.WriteLine($"Increased buffer size to {buffer.Length}")
'                End If

'                leftover.CopyTo(buffer)
'                bytesRead = stream.Read(buffer.AsSpan(leftover.Length))
'            Else
'                bytesRead = stream.Read(buffer)
'            End If
'            Console.WriteLine($"String in buffer is: {Encoding.UTF8.GetString(buffer)}")
'            reader = New Utf8JsonReader(buffer, isFinalBlock:=bytesRead = 0, reader.CurrentState)
'        End Sub
'    End Class
'End Namespace
