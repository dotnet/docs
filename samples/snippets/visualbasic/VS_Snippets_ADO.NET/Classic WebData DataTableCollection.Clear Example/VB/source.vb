imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub ClearTables()
   ' Get the DataSet of a DataGrid control.
   Dim dataSet As DataSet = CType(DataGrid1.DataSource, DataSet)
   Dim tables As DataTableCollection = dataSet.Tables

   ' Clear the collection.
   tables.Clear
End Sub
' </Snippet1>

End Class
