Imports System.IO
Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class JsonDocumentDataAccess

        Public Shared Sub Run()
            Dim inputFileName As String = "Grades.json"
            Dim jsonString As String = File.ReadAllText(inputFileName)

            AverageGrades(jsonString)
            AverageGrades_Alternative(jsonString)
        End Sub

        Private Shared Sub AverageGrades(jsonString As String)
            ' <AverageGrades1>
            Dim sum As Double = 0
            Dim count As Integer = 0
            Using document As JsonDocument = JsonDocument.Parse(jsonString)
                Dim root As JsonElement = document.RootElement
                Dim studentsElement As JsonElement = root.GetProperty("Students")
                For Each student As JsonElement In studentsElement.EnumerateArray()
                    Dim gradeElement As JsonElement = Nothing
                    If student.TryGetProperty("Grade", gradeElement) Then
                        sum += gradeElement.GetDouble()
                    Else
                        sum += 70
                    End If
                    count += 1
                Next
            End Using

            Dim average As Double = sum / count
            Console.WriteLine($"Average grade : {average}")
            ' </AverageGrades1>
        End Sub

        Private Shared Sub AverageGrades_Alternative(jsonString As String)
            ' <AverageGrades2>
            Dim sum As Double = 0
            Dim count As Integer = 0
            Using document As JsonDocument = JsonDocument.Parse(jsonString)
                Dim root As JsonElement = document.RootElement
                Dim studentsElement As JsonElement = root.GetProperty("Students")

                count = studentsElement.GetArrayLength()

                For Each student As JsonElement In studentsElement.EnumerateArray()
                    Dim gradeElement As JsonElement = Nothing
                    If student.TryGetProperty("Grade", gradeElement) Then
                        sum += gradeElement.GetDouble()
                    Else
                        sum += 70
                    End If
                Next
            End Using

            Dim average As Double = sum / count
            Console.WriteLine($"Average grade : {average}")
            ' </AverageGrades2>
        End Sub

    End Class

End Namespace
