Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
Private Sub GetConstraint(table As DataTable)
    Dim i As Integer
    For i = 0 To table.Constraints.Count - 1
        Console.WriteLine(table.Constraints(i).ConstraintName)
        Console.WriteLine(table.Constraints(i).GetType())
    Next i
 End Sub
' </Snippet1>
End Class
