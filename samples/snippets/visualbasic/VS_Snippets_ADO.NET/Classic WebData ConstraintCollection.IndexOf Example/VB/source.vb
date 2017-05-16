Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
Private Sub RemoveConstraint _
    (constraints As ConstraintCollection, constraint As Constraint)

    Try
        If constraints.Contains(constraint.ConstraintName) Then
            If constraints.CanRemove(constraint) Then
                constraints.RemoveAt _
                (constraints.IndexOf(constraint.ConstraintName))
            End If
        End If

    Catch ex As Exception
	' Process exception and return.
        Console.WriteLine(ex.Message)
    End Try
End Sub
' </Snippet1>
End Class
