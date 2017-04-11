imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub RemoveTables()
    ' Presuming a DataGrid is displaying more than one table, 
    ' get its DataSet.
    Dim thisDataSet As DataSet = CType(DataGrid1.DataSource, DataSet)
    Do While thisDataSet.Tables.Count > 0
       Dim table As DataTable = thisDataSet.Tables(0)
       If thisDataSet.Tables.CanRemove(table) Then
          thisDataSet.Tables.Remove(table)
       End If
    Loop
End Sub
' </Snippet1>

End Class
