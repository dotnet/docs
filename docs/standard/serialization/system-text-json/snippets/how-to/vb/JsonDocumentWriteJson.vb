Imports System.IO
Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class JsonDocumentWriteJson

        Public Shared Sub Run()
            Dim inputFileName As String = "Grades.json"
            Dim outputFileName As String = "GradesOutput.json"

            ' <Serialize>
            Dim jsonString As String = File.ReadAllText(inputFileName)

            Dim writerOptions As JsonWriterOptions = New JsonWriterOptions With {
                .Indented = True
            }

            Dim documentOptions As JsonDocumentOptions = New JsonDocumentOptions With {
                .CommentHandling = JsonCommentHandling.Skip
            }

            Dim fs As FileStream = File.Create(outputFileName)
            Dim writer As Utf8JsonWriter = New Utf8JsonWriter(fs, options:=writerOptions)
            Dim document As JsonDocument = JsonDocument.Parse(jsonString, documentOptions)

            Dim root As JsonElement = document.RootElement

            If root.ValueKind = JsonValueKind.[Object] Then
                writer.WriteStartObject()
            Else
                Return
            End If

            For Each [property] As JsonProperty In root.EnumerateObject()
                [property].WriteTo(writer)
            Next

            writer.WriteEndObject()

            writer.Flush()
            ' </Serialize>
            Console.WriteLine($"Output file is {outputFileName}")
        End Sub

    End Class

End Namespace
