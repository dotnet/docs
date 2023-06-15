Imports System.IO
Imports System.Text
Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class Utf8WriterToStream

        Public Shared Sub Run()
            ' <Serialize>
            Dim options As JsonWriterOptions = New JsonWriterOptions With {
                .Indented = True
            }

            Dim stream As MemoryStream = New MemoryStream
            Dim writer As Utf8JsonWriter = New Utf8JsonWriter(stream, options)

            writer.WriteStartObject()
            writer.WriteString("date", DateTimeOffset.UtcNow)
            writer.WriteNumber("temp", 42)
            writer.WriteEndObject()
            writer.Flush()

            Dim json As String = Encoding.UTF8.GetString(stream.ToArray())
            Console.WriteLine(json)
            ' </Serialize>

            Console.WriteLine()
        End Sub

    End Class

End Namespace
