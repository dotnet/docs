Imports System
Imports System.Data.Objects.DataClasses

Module Module1

    Sub Main()
        '<snippet4>
        Using context As New SchoolEntities()
            Dim students = From s In context.People _
                Where s.EnrollmentDate IsNot Nothing _
                Select New With {.name = s.LastName, _
                                .avgGrade = AvgStudentGrade(s.PersonID)}

            For Each student In students
                Console.WriteLine("{0}: {1}", _
                                    student.name, _
                                    student.avgGrade)
            Next
        End Using
        '</snippet4>
    End Sub

    '<snippet3>
    <EdmFunction("SchoolModel.Store", "AvgStudentGrade")>
    Public Function AvgStudentGrade(ByVal studentId As Integer) _
        As Nullable(Of Decimal)
        Throw New NotSupportedException("Direct calls are not supported.")
    End Function
    '</snippet3>
End Module
