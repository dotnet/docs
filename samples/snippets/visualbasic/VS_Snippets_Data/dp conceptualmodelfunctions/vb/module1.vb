Imports System.Data.Objects.DataClasses

Module Module1

    Sub Main()
        A()
        B()
    End Sub

    '<snippet2>
    <EdmFunction("SchoolModel", "YearsSince")>
    Public Function YearsSince(ByVal date1 As DateTime) _
        As Integer
        Throw New NotSupportedException("Direct calls are not supported.")
    End Function
    '</snippet2>

    Public Function A()
        '<snippet3>
        Using context As New SchoolEntities()
            ' Retrieve instructors hired more than 10 years ago.
            Dim instructors = From p In context.People _
                Where YearsSince(CType(p.HireDate, DateTime?)) > 10 _
                Select p

            For Each instructor In instructors
                Console.WriteLine(instructor.LastName)
            Next
        End Using
        '</snippet3>
    End Function

    Public Function B()
        Using context As New SchoolEntities()
            ' Retrieve instructors hired more than 10 years ago.
            Dim instructors = From p In context.People _
                Where YearsSince(CType(p.HireDate, DateTime?)) > 10 _
                Select p

            For Each instructor In instructors
                Console.WriteLine(instructor.LastName)
            Next
        End Using
    End Function
End Module
