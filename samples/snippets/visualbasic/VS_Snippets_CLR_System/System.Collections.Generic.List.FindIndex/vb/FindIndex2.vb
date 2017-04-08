' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections.Generic

Public Class Employee : Implements IComparable
   Public Property Name As String
   Public Property Id As Integer
   
   Public Function CompareTo(o As Object) As Integer _
         Implements IComparable.CompareTo
      Dim e As Employee = TryCast(o, Employee)
      If e Is Nothing Then
         Throw New ArgumentException("o is not an Employee object.")
      End If

      Return Name.CompareTo(e.Name)
   End Function
End Class

Public Class EmployeeSearch
   Dim _s As String
   
   Public Sub New(s As String)
      _s = s
   End Sub
   
   Public Function StartsWith(e As Employee) As Boolean
      Return e.Name.StartsWith(_s, StringComparison.InvariantCultureIgnoreCase)
   End Function
End Class

Module Example
   Public Sub Main()
      Dim employees As New List(Of Employee)()
      employees.AddRange( { New Employee() With { .Name = "Frank", .Id = 2 },
                            New Employee() With { .Name = "Jill", .Id = 3 },
                            New Employee() With { .Name = "Dave", .Id = 5 },
                            New Employee() With { .Name = "Jack", .Id = 8 },
                            New Employee() With { .Name = "Judith", .Id = 12 },
                            New Employee() With { .Name = "Robert", .Id = 14 },
                            New Employee() With { .Name = "Adam", .Id = 1 } } )
      employees.Sort()

      Dim es As New EmployeeSearch("J")
      Console.WriteLine("'J' starts at index {0}",
                        employees.FindIndex(AddressOf es.StartsWith))
      es = New EmployeeSearch("Ju")
      Console.WriteLine("'Ju' starts at index {0}",
                        employees.FindIndex(AddressOf es.StartsWith))
   End Sub
End Module
' The example displays the following output:
'       'J' starts at index 3
'       'Ju' starts at index 5
' </Snippet2>
