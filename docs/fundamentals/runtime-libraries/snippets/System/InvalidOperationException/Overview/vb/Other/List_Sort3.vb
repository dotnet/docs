' Visual Basic .NET Document
Option Strict On

' <Snippet14>
Imports System.Collections.Generic

Public Class Person11
    Public Sub New(fName As String, lName As String)
        FirstName = fName
        LastName = lName
    End Sub

    Public Property FirstName As String
    Public Property LastName As String
End Class

Public Class PersonComparer : Implements IComparer(Of Person11)
    Public Function Compare(x As Person11, y As Person11) As Integer _
          Implements IComparer(Of Person11).Compare
        Return String.Format("{0} {1}", x.LastName, x.FirstName).
             CompareTo(String.Format("{0} {1}", y.LastName, y.FirstName))
    End Function
End Class

Module Example11
    Public Sub Main()
        Dim people As New List(Of Person11)()

        people.Add(New Person11("John", "Doe"))
        people.Add(New Person11("Jane", "Doe"))
        people.Sort(New PersonComparer())
        For Each person In people
            Console.WriteLine("{0} {1}", person.FirstName, person.LastName)
        Next
    End Sub
End Module
' The example displays the following output:
'       Jane Doe
'       John Doe
' </Snippet14>

