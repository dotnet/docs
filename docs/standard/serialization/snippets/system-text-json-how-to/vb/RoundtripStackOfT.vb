Imports System.Collections.Generic
Imports System.Text.Json

Namespace SystemTextJsonSamples
    Public NotInheritable Class RoundtripStackOfT
        'Public Shared Sub Run()
        '    Console.WriteLine("Deserialize JSON string [1, 2, 3], then serialize it back to JSON.")
        '    Dim stack1 As Stack(Of Integer) = JsonSerializer.Deserialize(Of Stack(Of Integer))("[1, 2, 3]")
        '    Dim serialized As String = JsonSerializer.Serialize(stack1)
        '    Console.WriteLine($"Result is in reverse order: {serialized}")

        '    Console.WriteLine("Deserialize JSON string [1, 2, 3] with custom converter, then serialize it back to JSON.")
        '    ' <Register>
        '    Dim options As JsonSerializerOptions = New JsonSerializerOptions
        '    options.Converters.Add(New JsonConverterFactoryForStackOfT)
        '    ' </Register>
        '    stack1 = JsonSerializer.Deserialize(Of Stack(Of Integer))("[1, 2, 3]", options)
        '    serialized = JsonSerializer.Serialize(stack1, options)
        '    Console.WriteLine($"Result is in same order: {serialized}")
        'End Sub
    End Class
End Namespace
