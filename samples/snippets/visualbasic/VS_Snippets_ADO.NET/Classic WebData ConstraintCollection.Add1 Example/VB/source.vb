Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
 Private Sub AddUniqueConstraint(table As DataTable)
     Dim columns(1) As DataColumn
     columns(0) = table.Columns("ID")
     columns(1) = table.Columns("Name")
     table.Constraints.Add("idNameConstraint", columns, True)
 End Sub
' </Snippet1>
End Class
