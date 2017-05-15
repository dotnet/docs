Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
' <Snippet1>
 Private Sub PrintConstraintNames(myTable As DataTable)
     Dim cs As Constraint
     For Each cs In  myTable.Constraints
         Console.WriteLine(cs.ConstraintName)
     Next cs
 End Sub
' </Snippet1>
End Class
