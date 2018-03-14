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
 Private Sub GetRelatedTables()
    Dim relation As DataRelation
    Dim dataTable As DataTable
    
    ' Get the DataRelation from a DataSet.
    For Each relation In DataSet1.Relations
       If relation.GetType.ToString = _
        "System.Data.ForeignKeyConstraint" Then
          dataTable = relation.ParentTable
          Console.WriteLine(dataTable.TableName, _
            dataTable.Columns.Count, dataTable.Rows.Count)
       End If
    Next
 End Sub
' </Snippet1>

End Class
