Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
Private Sub GetConstraint(table As DataTable)
    If table.Constraints.Contains("CustomersOrdersConstraint") Then
        Dim constraint As Constraint = _
            table.Constraints("CustomersOrdersConstraint")
    End If
End Sub
' </Snippet1>
End Class
