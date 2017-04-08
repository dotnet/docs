imports System
imports System.Xml
imports System.Data
imports System.Data.OleDb
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub GetColumns()
    Dim dataColumns() As DataColumn
    Dim relation As DataRelation
    Dim i As Integer 
    ' Get the DataRelation from a DataSet.
    For Each relation In DataSet1.Relations
       If relation.GetType.ToString = _
         "System.Data.ForeignKeyConstraint" Then
         dataColumns = relation.ParentColumns
            For i = 0 To dataColumns.GetUpperBound(0)
               Console.WriteLine(dataColumns(i).ColumnName)
            Next i
       End If
    Next
 End Sub
' </Snippet1>

End Class
