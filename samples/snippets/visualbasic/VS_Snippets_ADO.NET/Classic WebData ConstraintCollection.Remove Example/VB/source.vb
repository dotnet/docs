Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
' <Snippet1>
Private Sub RemoveConstraint(table As DataTable, _
    constraint As Constraint)

    If table.Constraints.Contains(constraint.ConstraintName) Then
        If table.Constraints.CanRemove(constraint) Then
            table.Constraints.Remove(constraint)
        End If
    End If
End Sub
' </Snippet1>
End Class
