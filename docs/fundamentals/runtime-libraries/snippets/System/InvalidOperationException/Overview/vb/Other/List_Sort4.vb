' Visual Basic .NET Document
Option Strict On

' <Snippet15>
Imports System.Collections.Generic

Public Class Person12
    Public Sub New(fName As String, lName As String)
        FirstName = fName
        LastName = lName
    End Sub

    Public Property FirstName As String
    Public Property LastName As String
End Class

Module Example12
    Public Sub Main()
        Dim people As New List(Of Person12)()

        people.Add(New Person12("John", "Doe"))
        people.Add(New Person12("Jane", "Doe"))
        people.Sort(AddressOf PersonComparison)
        For Each person In people
            Console.WriteLine("{0} {1}", person.FirstName, person.LastName)
        Next
    End Sub

    Public Function PersonComparison(x As Person12, y As Person12) As Integer
        Return String.Format("{0} {1}", x.LastName, x.FirstName).
             CompareTo(String.Format("{0} {1}", y.LastName, y.FirstName))
    End Function
End Module
' The example displays the following output:
'       Jane Doe
'       John Doe
' </Snippet15>
