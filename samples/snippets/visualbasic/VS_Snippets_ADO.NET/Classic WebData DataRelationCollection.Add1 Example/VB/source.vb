Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
Private Sub AddRelation()
    Dim table As New DataTable()
    Dim column1 As DataColumn = table.Columns.Add("Column1")
    Dim column2 As DataColumn = table.Columns.Add("Column2")
    table.ChildRelations.Add("New Relation", column1, column2)
End Sub
' </Snippet1>
End Class
