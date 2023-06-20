Imports System.Text.Json

Namespace SystemTextJsonSamples
    Public Class RoundTripDateOnly
        Public Shared Sub Run()
            Console.WriteLine(
                "Serialize SeriesDataPoint class to a JSON string, then deserialize it back object.")

            ' <RoundtripDateOnly>
            Dim originalData As New SeriesDataPoint With {
                .Id = Guid.NewGuid(),
                .Value = 3.791D,
                .DateValue = New DateOnly(2002, 1, 13),
                .Time = New TimeOnly(5, 3, 1)
            }
            Dim serialized As String = JsonSerializer.Serialize(originalData)

            Console.WriteLine($"Resulting JSON: {serialized}")

            Dim deserializedData As SeriesDataPoint =
                JsonSerializer.Deserialize(Of SeriesDataPoint)(serialized)
            Dim valuesAreTheSame As Boolean = (originalData.DateValue = deserializedData.DateValue AndAlso
                originalData.Time = deserializedData.Time AndAlso
                originalData.Id = deserializedData.Id AndAlso
                originalData.Value = deserializedData.Value)

            Console.WriteLine(
                $"Original object has the same values as the deserialized object: {valuesAreTheSame}")
            ' </RoundtripDateOnly>
        End Sub
    End Class

    ' <SeriesDataPoint>
    Public NotInheritable Class SeriesDataPoint
        Public Property Id As Guid
        Public Property Value As Decimal
        Public Property DateValue As DateOnly?
        Public Property Time As TimeOnly?
    End Class
    ' </SeriesDataPoint>
End Namespace
