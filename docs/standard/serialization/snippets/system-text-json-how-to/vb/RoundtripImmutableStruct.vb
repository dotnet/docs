Imports System.Text.Json

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    Public NotInheritable Class RoundtripImmutableStruct
        'Public Shared Sub Run()
        '    Dim jsonString As String
        '    Dim point1 As New ImmutablePoint(1, 2)
        '    Dim point2 As New ImmutablePoint(3, 4)
        '    Dim points As List(Of ImmutablePoint) = New List(Of ImmutablePoint) From {
        '        point1,
        '        point2}

        '    Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions With
        '    {
        '    .WriteIndented = True}
        '    jsonString = JsonSerializer.Serialize(points, serializeOptions)
        '    Console.WriteLine($"JSON output:{jsonString}")

        '    Dim deserializeOptions As JsonSerializerOptions = New JsonSerializerOptions
        '    deserializeOptions.Converters.Add(New ImmutablePointConverter(deserializeOptions))
        '    points = JsonSerializer.Deserialize(Of List(Of ImmutablePoint))(jsonString, deserializeOptions)
        '    Console.WriteLine("Deserialized object values")
        '    For Each point As ImmutablePoint In points
        '        Console.WriteLine($"X,Y = {point.X},{point.Y}")
        '    Next
        'End Sub
    End Class
End Namespace
