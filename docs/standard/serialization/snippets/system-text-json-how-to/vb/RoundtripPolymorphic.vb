Imports System.Collections.Generic
Imports System.Text.Json

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    Public NotInheritable Class RoundtripPolymorphic
        'Public Shared Sub Run()
        '    Dim jsonString As String
        '    Dim people = PersonFactories.CreatePeople()
        '    people.ForEach(Sub(p) p.DisplayPropertyValues())

        '    ' <Register>
        '    Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions
        '    serializeOptions.Converters.Add(New PersonConverterWithTypeDiscriminator)
        '    ' </Register>
        '    serializeOptions.WriteIndented = True
        '    jsonString = JsonSerializer.Serialize(people, serializeOptions)
        '    Console.WriteLine($"JSON output:{jsonString}")

        '    ' <Deserialize>
        '    Dim deserializeOptions As JsonSerializerOptions = New JsonSerializerOptions
        '    deserializeOptions.Converters.Add(New PersonConverterWithTypeDiscriminator)
        '    people = JsonSerializer.Deserialize(Of List(Of Person))(jsonString, deserializeOptions)
        '    ' </Deserialize>
        '    people.ForEach(Sub(p) p.DisplayPropertyValues())
        'End Sub
    End Class
End Namespace
