Imports System.Text.Json

Namespace NonStringKeyDictionary

    Public NotInheritable Class Program

        Public Shared Sub Main()
            Dim numbers As New Dictionary(Of Integer, String) From {
                {0, "zero"},
                {1, "one"},
                {34, "thirty four"},
                {55, "fifty five"}
            }

            Dim options As New JsonSerializerOptions With {
                .WriteIndented = True
            }

            Dim json As String = JsonSerializer.Serialize(numbers, options)

            Console.WriteLine($"Output JSON: {json}")

            Dim dictionary1 As Dictionary(Of Integer, String) = JsonSerializer.Deserialize(Of Dictionary(Of Integer, String))(json)

            Console.WriteLine($"dictionary[55]: {dictionary1(55)}")
        End Sub

    End Class

End Namespace

' Produces output like the following example:
'
'Output JSON: {
'  "0": "zero",
'  "1": "one",
'  "34": "thirty four",
'  "55": "fifty five"
'}
'dictionary[55]: fifty five
