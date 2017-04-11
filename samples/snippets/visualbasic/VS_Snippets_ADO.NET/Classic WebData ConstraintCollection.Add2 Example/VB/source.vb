Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
 Private Sub AddUniqueConstraint(table As DataTable)
     table.Constraints.Add("idConstraint", table.Columns("id"), True)
 End Sub
' </Snippet1>
End Class
