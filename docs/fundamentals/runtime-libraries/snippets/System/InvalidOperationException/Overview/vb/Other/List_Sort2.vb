' Visual Basic .NET Document
Option Strict On

' <Snippet13>
Imports System.Collections.Generic

Public Class Person : Implements IComparable(Of Person)
   Public Sub New(fName As String, lName As String)
      FirstName = fName
      LastName = lName
   End Sub
   
   Public Property FirstName As String
   Public Property LastName As String
   
   Public Function CompareTo(other As Person) As Integer _
          Implements IComparable(Of Person).CompareTo
      Return String.Format("{0} {1}", LastName, FirstName).
            CompareTo(String.Format("{0} {1}", other.LastName, other.FirstName))    
   End Function
End Class

Module Example10
    Public Sub Main()
        Dim people As New List(Of Person)()

        people.Add(New Person("John", "Doe"))
        people.Add(New Person("Jane", "Doe"))
        people.Sort()
        For Each person In people
            Console.WriteLine("{0} {1}", person.FirstName, person.LastName)
        Next
    End Sub
End Module
' The example displays the following output:
'       Jane Doe
'       John Doe
' </Snippet13>
